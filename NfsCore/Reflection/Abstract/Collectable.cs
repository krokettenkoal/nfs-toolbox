using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using NfsCore.Global;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Interface;
using NfsCore.Utils;

namespace NfsCore.Reflection.Abstract
{
    /// <summary>
    /// <see cref="Collectable"/> class is a default collection of properties and fields of any 
    /// global type, which information can be accessed and modified through those properties. 
    /// It inherits from <see cref="Primitive"/> class and <see cref="ICastable{TypeID}"/> 
    /// interface and implements/overrides most of their methods.
    /// </summary>
    public abstract class Collectable : Primitive, ICastable<Collectable>
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        [AccessModifiable]
        public string CollectionName
        {
            get => CollName;
            set
            {
                ValidateCollectionName(value);
                CollName = value;
            }
        }

        public bool Deletable { get; set; } = true;
        public virtual GameINT GameINT => GameINT.None;
        public BasicBase Database { get; }
        public string GameSTR => GameINT.ToString();

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey => Bin.Hash(CollectionName);

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey => Vlt.Hash(CollectionName);

        protected string CollName;

        /// <summary>
        /// Returns array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <returns>Array of strings.</returns>
        public override object[] GetAccessibles(eGetInfoType type)
        {
            var list = new List<object>();
            foreach (var property in GetType().GetProperties())
            {
                if (!Attribute.IsDefined(property, typeof(AccessModifiableAttribute))) continue;
                if (type == eGetInfoType.PROPERTY_NAMES)
                    list.Add(property.Name);
                else
                    list.Add(property);
            }

            return list.ToArray();
        }

        public SubPart GetSubPart(string name, string node)
        {
            var property = GetType().GetProperty(name);
            if (property == null) return null;
            if (property.GetCustomAttributes(typeof(ExpandableAttribute), true)
                .Select(obj => obj as ExpandableAttribute).Any(attrib => attrib?.Name == node))
            {
                return (SubPart) property.GetValue(this);
            }

            return null;
        }

        public bool GetSubPart(string name, string node, out SubPart part)
        {
            part = null;
            var property = GetType().GetProperty(name);
            if (property == null) return false;
            if (property.GetCustomAttributes(typeof(ExpandableAttribute), true)
                .Select(obj => obj as ExpandableAttribute)
                .All(attrib => attrib?.Name != node)) return false;
            part = (SubPart) property.GetValue(this);
            return true;
        }

        /// <summary>
        /// Gets all nodes and subnodes from the class.
        /// </summary>
        /// <returns>Array of virtual nodes that can be used to build treeview.</returns>
        public virtual List<VirtualNode> GetAllNodes()
        {
            var list = new List<VirtualNode>();
            foreach (var property in GetType().GetProperties())
            {
                foreach (var obj in property.GetCustomAttributes(typeof(ExpandableAttribute), true))
                {
                    var attrib = obj as ExpandableAttribute;
                    var node = list.Find(c => c.NodeName == attrib?.Name);
                    if (node == null)
                    {
                        node = new VirtualNode(attrib?.Name);
                        list.Add(node);
                    }

                    node.SubNodes.Add(new VirtualNode(property.Name));
                }
            }

            list.Sort((x, y) => string.Compare(x.NodeName, y.NodeName, StringComparison.Ordinal));
            return list;
        }

        public virtual IEnumerable<object> GetSubnodeAttribs(string nodeName, eGetInfoType type)
        {
            var property = GetType().GetProperty(nodeName);
            if (property == null) return null;
            var result = new List<object>();
            foreach (var field in property.PropertyType.GetProperties())
            {
                if (type == eGetInfoType.PROPERTY_NAMES)
                    result.Add(field.Name);
                else
                    result.Add(field);
            }

            return result.ToArray();
        }

        public virtual string GetValueOfInternalObject(string nodeName, string field)
        {
            var property = GetType().GetProperty(nodeName);
            if (property == null) return null;
            return !Attribute.IsDefined(property, typeof(ExpandableAttribute))
                ? null
                : (string) property.PropertyType.GetMethod("GetValue")
                    ?.Invoke(property.GetValue(this), new object[] {field});
        }

        /// <summary>
        /// Checks if this class contains property with name specified that has AccessModifiable attribute.
        /// </summary>
        /// <param name="propertyName">Name of the property to check.</param>
        /// <returns>True if property exists and has AccessModifiable attribute; false otherwise.</returns>
        public virtual bool ContainsAccessModifiable(string propertyName)
        {
            var property = GetType().GetProperty(propertyName);
            return property != null && Attribute.IsDefined(property, typeof(AccessModifiableAttribute));
        }

        /// <summary>
        /// Sets value at a field of an internal object, if such exists.
        /// </summary>
        /// <param name="paths">Parameters of the path to object, including property name and value to set.</param>
        public virtual bool SetValueOfInternalObject(params string[] paths)
        {
            var subRoute = paths[0];
            var nodeName = paths[1];
            var propertyName = paths[2];
            var value = paths[3];

            var property = GetType().GetProperty(nodeName);
            if (property == null) return false;
            foreach (var obj in property.GetCustomAttributes(typeof(ExpandableAttribute), true))
            {
                var attrib = obj as ExpandableAttribute;
                if (attrib?.Name == subRoute)
                    goto LABEL_CHANGE_VAL;
            }

            return false;

            LABEL_CHANGE_VAL:
            if (!typeof(ISetValue).IsAssignableFrom(property.PropertyType))
                return false;
            var method = property.PropertyType.GetMethod("SetValue", BindingFlags.Public |
                                                                     BindingFlags.Instance, null,
                CallingConventions.Any,
                new[] {typeof(string), typeof(object)}, null);

            var val = property.GetValue(this);
            if (method == null || val == null)
                return false;

            return (bool) method.Invoke(val, new object[] {propertyName, value})!;
        }

        /// <summary>
        /// Sets value at a field of an internal object, if such exists.
        /// </summary>
        /// <param name="error">A reference to a string where any error messages are written to</param>
        /// <param name="paths">Parameters of the path to object, including property name and value to set.</param>
        public virtual bool SetValueOfInternalObject(ref string error, params string[] paths)
        {
            var subRoute = paths[0];
            var nodeName = paths[1];
            var propertyName = paths[2];
            var value = paths[3];

            var property = GetType().GetProperty(nodeName);
            if (property == null)
            {
                error = $"Node named {nodeName} could not be found.";
                return false;
            }

            foreach (var obj in property.GetCustomAttributes(typeof(ExpandableAttribute), true))
            {
                var attrib = obj as ExpandableAttribute;
                if (attrib?.Name == subRoute)
                    goto LABEL_CHANGE_VAL;
            }

            error = $"Sub-route named {subRoute} could not be found.";
            return false;

            LABEL_CHANGE_VAL:
            if (!typeof(ISetValue).IsAssignableFrom(property.PropertyType))
                return false;
            var method = property.PropertyType.GetMethod("SetValue", BindingFlags.Public |
                                                                     BindingFlags.Instance, null,
                CallingConventions.Any,
                new[] {typeof(string), typeof(object), typeof(string).MakeByRefType()}, null);
            var objs = new object[] {propertyName, value, null};
            var val = property.GetValue(this);
            if (method == null || val == null)
                return false;

            var result = (bool) method.Invoke(val, objs)!;
            if (objs[2] != null) error = objs[2].ToString();
            return result;
        }

        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="propertyName">Field name to get the value from.</param>
        /// <returns>String value of a field name.</returns>
        public override string GetValue(string propertyName)
        {
            var result = GetType().GetProperty(propertyName);
            return result == null ? null : result.GetValue(this)?.ToString();
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="propertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public override bool SetValue(string propertyName, object value)
        {
            try
            {
                var property = GetType().GetProperty(propertyName);
                if (property == null) return false;
                if (!Attribute.IsDefined(property, typeof(AccessModifiableAttribute)))
                    throw new FieldAccessException("This field is either non-modifiable or non-accessible");
                property.SetValue(this,
                    property.PropertyType.IsEnum
                        ? System.Enum.Parse(property.PropertyType, value.ToString() ?? string.Empty)
                        : Cast.ReinterpretCast(value, property.PropertyType));
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="propertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        /// <param name="error">A reference to a string where any error messages are written to</param>
        public override bool SetValue(string propertyName, object value, ref string error)
        {
            try
            {
                var property = GetType().GetProperty(propertyName);
                if (property == null)
                {
                    error = $"Field named {propertyName} does not exist.";
                    return false;
                }

                if (!Attribute.IsDefined(property, typeof(AccessModifiableAttribute)))
                    throw new FieldAccessException("This field is either non-modifiable or non-accessible");
                property.SetValue(this,
                    property.PropertyType.IsEnum
                        ? System.Enum.Parse(property.PropertyType, value.ToString() ?? string.Empty)
                        : Cast.ReinterpretCast(value, property.PropertyType));
                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }

        public abstract Collectable MemoryCast(string collectionName);

        protected virtual void ValidateCollectionName(string collectionName)
        {
        }
    }
}