using System.Linq;

namespace NfsCore.Reflection.Abstract
{
    public abstract class BaseCollectable
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public abstract string CollectionName { get; set; }

        /// <summary>
        /// Returns array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <returns>Array of strings.</returns>
        public virtual string[] GetAccessibles()
        {
            var list = (from property in GetType().GetProperties()
                where System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute))
                select property.Name).ToList();
            list.Sort();
            return list.ToArray();
        }

        /// <summary>
        /// Checks if the property is of enumerable type.
        /// </summary>
        /// <param name="property">Name of the property to check.</param>
        /// <returns>True if property is enum; false otherwise.</returns>
        public virtual bool OfEnumerableType(string property)
        {
            var propertyInfo = GetType().GetProperty(property);
            return propertyInfo != null && propertyInfo.PropertyType.IsEnum;
        }

        /// <summary>
        /// Returns all enumerable strings of the property.
        /// </summary>
        /// <param name="property">Name of the enumerable property.</param>
        /// <returns>Array of strings.</returns>
        public virtual string[] GetPropertyEnumerableTypes(string property)
        {
            return GetType().GetProperty(property)?.PropertyType.GetEnumNames();
        }

        /// <summary>
        /// Checks if this class contains property with name specified that has AccessModifiable attribute.
        /// </summary>
        /// <param name="propertyName">Name of the property to check.</param>
        /// <returns>True if property exists and has AccessModifiable attribute; false otherwise.</returns>
        public virtual bool ContainsAccessModifiable(string propertyName)
        {
            var property = GetType().GetProperty(propertyName);
            return property != null &&
                   System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute));
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
            foreach (var obj in property.GetCustomAttributes(typeof(Attributes.ExpandableAttribute), true))
            {
                var attrib = obj as Attributes.ExpandableAttribute;
                if (attrib?.Name == subRoute)
                    goto LABEL_CHANGE_VAL;
            }

            return false;

            LABEL_CHANGE_VAL:
            if (!typeof(Interface.ISetValue).IsAssignableFrom(property.PropertyType))
                return false;
            var method = property.PropertyType.GetMethod("SetValue", System.Reflection.BindingFlags.Public |
                                                                     System.Reflection.BindingFlags.Instance, null,
                System.Reflection.CallingConventions.Any,
                new[] {typeof(string), typeof(object)}, null);
            var val = property.GetValue(this);
            if (method == null || val == null)
                return false;

            return (bool) method.Invoke(val, new object[2] {propertyName, value})!;
        }

        /// <summary>
        /// Sets value at a field of an internal object, if such exists.
        /// </summary>
        /// <param name="error">Reference to a string where any error messages are written to</param>
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

            foreach (var obj in property.GetCustomAttributes(typeof(Attributes.ExpandableAttribute), true))
            {
                var attrib = obj as Attributes.ExpandableAttribute;
                if (attrib?.Name == subRoute)
                    goto LABEL_CHANGE_VAL;
            }

            error = $"Subroute named {subRoute} could not be found.";
            return false;

            LABEL_CHANGE_VAL:
            if (!typeof(Interface.ISetValue).IsAssignableFrom(property.PropertyType))
                return false;
            var method = property.PropertyType.GetMethod("SetValue", System.Reflection.BindingFlags.Public |
                                                                     System.Reflection.BindingFlags.Instance, null,
                System.Reflection.CallingConventions.Any,
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
        public virtual string GetValue(string propertyName)
        {
            return GetType().GetProperty(propertyName)?.GetValue(this)?.ToString();
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="propertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public virtual bool SetValue(string propertyName, object value)
        {
            try
            {
                var property = GetType().GetProperty(propertyName);
                if (property == null) return false;
                if (!System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                    throw new System.FieldAccessException("This field is either non-modifiable or non-accessible");
                if (property.PropertyType.IsEnum)
                {
                    property.SetValue(this, System.Enum.Parse(property.PropertyType, value.ToString() ?? string.Empty));
                }
                else
                {
                    property.SetValue(this, typeof(Utils.Cast)
                        .GetMethod("StaticCast")
                        ?.MakeGenericMethod(property.PropertyType)
                        .Invoke(null, new object[1] {value}));
                }

                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                //System.Console.WriteLine($"{e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="propertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        /// <param name="error">Reference to a string where any error messages are written to</param>
        public virtual bool SetValue(string propertyName, object value, ref string error)
        {
            try
            {
                var property = GetType().GetProperty(propertyName);
                if (property == null)
                {
                    error = $"Field named {propertyName} does not exist.";
                    return false;
                }

                if (!System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                    throw new System.FieldAccessException("This field is either non-modifiable or non-accessible");
                if (property.PropertyType.IsEnum)
                {
                    property.SetValue(this, System.Enum.Parse(property.PropertyType, value.ToString() ?? string.Empty));
                }
                else
                {
                    property.SetValue(this, typeof(Utils.Cast)
                        .GetMethod("StaticCast")
                        ?.MakeGenericMethod(value.GetType())
                        .Invoke(null, new object[1] {value}));
                }

                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }
    }
}