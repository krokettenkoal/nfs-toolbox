using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Database.Collection
{
    public class Root<TypeID>(
        string name,
        int maxlength,
        int offsetat,
        int basesize,
        bool resizable,
        bool importable,
        BasicBase data)
        where TypeID : Collectable, new()
    {
        public List<TypeID> Collections { get; set; } = [];
        public string ThisName { get; set; } = name;
        public int Length => Collections.Count;
        public int MaxCNameLength { get; } = maxlength;
        public int CNameOffsetAt { get; } = offsetat;
        public int BaseClassSize { get; } = basesize;
        public bool Resizable { get; } = resizable;
        public BasicBase Database { get; set; } = data;

        #region Collection Access

        public TypeID this[int index] => index < Length ? Collections[index] : null;

        public bool TryGetCollectionIndex(string collectionName, out int index)
        {
            for (index = 0; index < Length; ++index)
            {
                if (Collections[index].CollectionName == collectionName)
                    return true;
            }

            index = -1;
            return false;
        }

        public TypeID FindCollection(string collectionName)
        {
            return Collections.Find(c => c.CollectionName == (collectionName ?? string.Empty));
        }

        public TypeID FindCollection(uint key, eKeyType type)
        {
            switch (type)
            {
                case eKeyType.BINKEY:
                    var bin = Collections.Find(c => Bin.SmartHash(c.CollectionName) == key);
                    if (bin != null) return bin;
                    goto default;

                case eKeyType.VLTKEY:
                    var vlt = Collections.Find(c => Vlt.SmartHash(c.CollectionName) == key);
                    if (vlt != null) return vlt;
                    goto default;

                case eKeyType.CUSTOM:
                    throw new NotImplementedException();
                case eKeyType.DEFAULT:
                default:
                    return null;
            }
        }

        public TypeID FindClassWithValue(string field, object value)
        {
            return Collections.FirstOrDefault(obj => obj.GetType().GetProperty(field)?.GetValue(obj) == value);
        }

        public bool TryGetCollection(string collectionName, out TypeID collection)
        {
            collection = FindCollection(collectionName);
            return collection != null;
        }

        #endregion

        #region Collection Statics

        public bool TrySetClassValue(params string[] tokens)
        {
            return tokens.Length switch
            {
                3 => FindCollection(tokens[0]).SetValue(tokens[1], tokens[2]),
                5 => FindCollection(tokens[0]).SetValueOfInternalObject(tokens[1], tokens[2], tokens[3], tokens[4]),
                _ => false
            };
        }

        public bool TrySetClassValue(ref string error, params string[] tokens)
        {
            switch (tokens.Length)
            {
                case 3:
                    return FindCollection(tokens[0]).SetValue(tokens[1], tokens[2], ref error);
                case 5:
                    return FindCollection(tokens[0])
                        .SetValueOfInternalObject(ref error, tokens[1], tokens[2], tokens[3], tokens[4]);
                default:
                    error = "Invalid amount of parameters passed";
                    return false;
            }
        }

        public bool TrySetStaticValue(string field, string value)
        {
            // Works only for Collectable and StaticModifiable properties
            var property = typeof(TypeID).GetProperty(field);
            if (property == null) return false;
            return Attribute.IsDefined(property, typeof(StaticModifiableAttribute)) &&
                   Collections.Select(collection => collection.SetValue(field, value)).All(pass => pass);
        }

        public bool TrySetStaticValue(string field, string value, out string error)
        {
            error = null;
            var property = typeof(TypeID).GetProperty(field);
            if (property == null)
            {
                error = $"Field named {field} does not exist.";
                return false;
            }

            if (!Attribute.IsDefined(property, typeof(StaticModifiableAttribute)))
            {
                error = $"Field named {field} is not a static-modifiable field.";
                return false;
            }

            foreach (var collection in Collections)
            {
                var pass = collection.SetValue(field, value, ref error);
                if (!pass) return false;
            }

            return true;
        }

        #endregion

        #region Collection Methods

        public bool TryAddCollection(string value)
        {
            try
            {
                if (!Resizable) return false;
                if (string.IsNullOrWhiteSpace(value)) return false;
                if (MaxCNameLength != -1 && value.Length > MaxCNameLength) return false;
                if (FindCollection(value) != null) return false;
                var ctor = typeof(TypeID).GetConstructor([typeof(string), Database.GetType()]);
                if (ctor == null) return false;
                var instance = (TypeID) ctor.Invoke([value, Database]);
                Collections.Add(instance);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryAddCollection(string value, out string error)
        {
            TypeID instance = null;
            error = null;

            try
            {
                if (!Resizable)
                {
                    error = "Class collection specified is non-resizable.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    error = "CollectionName cannot be empty or whitespace.";
                    return false;
                }

                if (MaxCNameLength != -1 && value.Length > MaxCNameLength)
                {
                    error = $"Length of the value passed should not exceed {MaxCNameLength} characters.";
                    return false;
                }

                if (FindCollection(value) != null)
                {
                    error = $"Class with CollectionName {value} already exists.";
                    return false;
                }

                var ctor = typeof(TypeID).GetConstructor(new Type[] {typeof(string), Database.GetType()});
                instance = (TypeID) ctor.Invoke(new object[] {value, Database});
                Collections.Add(instance);
                return true;
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                instance = null;
                return false;
            }
        }

        public bool TryRemoveCollection(string value)
        {
            if (!Resizable) return false;
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (!TryGetCollection(value, out var cla)) return false;
            if (!cla.Deletable) return false;
            return Collections.Remove(cla);
        }

        public bool TryRemoveCollection(string value, out string error)
        {
            error = null;
            if (!Resizable)
            {
                error = "Class collection specified is non-resizable.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                error = "Class with empty or whitespace CollectionName does not exist.";
                return false;
            }

            if (!TryGetCollection(value, out var cla))
            {
                error = $"Class with CollectionName {value} does not exist.";
                return false;
            }

            if (!cla.Deletable)
            {
                error = $"This collection cannot be deleted because it is important to the game.";
                return false;
            }

            var done = Collections.Remove(cla);
            if (!done) error = $"Unable to remove class with CollectionName {value}.";
            return done;
        }

        public bool TryCloneCollection(string value, string copyfrom)
        {
            TypeID instance = null;

            try
            {
                if (!Resizable) return false;
                if (string.IsNullOrWhiteSpace(value)) return false;
                if (MaxCNameLength != -1 && value.Length > MaxCNameLength) return false;
                if (FindCollection(value) != null) return false;
                if (!TryGetCollection(copyfrom, out var cla)) return false;

                instance = (TypeID) cla.MemoryCast(value);
                Collections.Add(instance);
                return true;
            }
            catch (Exception)
            {
                instance = null;
                return false;
            }
        }

        public bool TryCloneCollection(string value, string copyfrom, out string error)
        {
            TypeID instance = null;
            error = null;

            try
            {
                if (!Resizable)
                {
                    error = "Class collection specified is non-resizable.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    error = "CollectionName cannot be empty or whitespace.";
                    return false;
                }

                if (MaxCNameLength != -1 && value.Length > MaxCNameLength)
                {
                    error = $"Length of the value passed should not exceed {MaxCNameLength} characters.";
                    return false;
                }

                if (FindCollection(value) != null)
                {
                    error = $"Class with CollectionName {value} already exists.";
                    return false;
                }

                if (!TryGetCollection(copyfrom, out var cla))
                {
                    error = $"Class with CollectionName {copyfrom} does not exist.";
                    return false;
                }

                instance = (TypeID) cla.MemoryCast(value);
                Collections.Add(instance);
                return true;
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                instance = null;
                return false;
            }
        }

        public unsafe bool TryImportCollection(byte[] data)
        {
            if (!importable) return false;
            if (data.Length != BaseClassSize) return false;

            var CName = string.Empty;
            fixed (byte* dataptr_t = &data[0])
            {
                CName = ScriptX.NullTerminatedString(dataptr_t);
                if (FindCollection(CName) != null) return false;

                var ctor = typeof(TypeID).GetConstructor(
                    new Type[] {typeof(IntPtr), typeof(string), Database.GetType()});
                var instance = (TypeID) ctor.Invoke(new object[] {(IntPtr) dataptr_t, CName, Database});
                Collections.Add(instance);
            }

            return true;
        }

        public unsafe bool TryImportCollection(byte[] data, out string error)
        {
            error = null;
            if (!importable)
            {
                error = "Class collection specified is not importable.";
                return false;
            }

            if (data.Length != BaseClassSize)
            {
                error = $"Size of the class imported is {data.Length} bytes, while should be {BaseClassSize} bytes.";
                return false;
            }

            var CName = string.Empty;
            fixed (byte* dataptr_t = &data[0])
            {
                CName = ScriptX.NullTerminatedString(dataptr_t);
                if (FindCollection(CName) != null)
                {
                    error = $"Class with CollectionName {CName} already exists.";
                    return false;
                }

                var ctor = typeof(TypeID).GetConstructor(
                    new Type[] {typeof(IntPtr), typeof(string), Database.GetType()});
                var instance = (TypeID) ctor.Invoke(new object[] {(IntPtr) dataptr_t, CName, Database});
                Collections.Add(instance);
            }

            return true;
        }

        public bool TryExportCollection(string value, string filepath)
        {
            if (!importable) return false;
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (!TryGetCollection(value, out var cla)) return false;
            if (!Directory.Exists(Path.GetDirectoryName(filepath))) return false;

            var arr = (byte[]) cla.GetType()
                .GetMethod("Assemble").Invoke(cla, new object[0] { });

            using (var bw = new BinaryWriter(File.Open(filepath, FileMode.Create)))
            {
                bw.Write(arr);
            }

            return true;
        }

        public bool TryExportCollection(string value, string filepath, out string error)
        {
            error = null;
            if (!importable)
            {
                error = "Class collection specified is not exportable.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                error = "CollectionName cannot be empty or whitespace.";
                return false;
            }

            if (!TryGetCollection(value, out var cla))
            {
                error = $"Class with CollectionName {value} does not exist.";
                return false;
            }

            if (!Directory.Exists(Path.GetDirectoryName(filepath)))
            {
                error = $"Directory of the file path {filepath} specified does not exist.";
                return false;
            }

            var arr = (byte[]) cla.GetType().GetMethod("Assemble").Invoke(cla, new object[0] { });

            using (var bw = new BinaryWriter(File.Open(filepath, FileMode.Create)))
            {
                bw.Write(arr);
            }

            return true;
        }

        #endregion

        #region Collection Reflection

        public object[] GetAccessibleProperties(string CName)
        {
            if (!TryGetCollection(CName, out var cla)) return null;
            else return cla.GetAccessibles(eGetInfoType.PROPERTY_NAMES);
        }

        public Dictionary<string, CollectionAttrib> GetAttributeMap()
        {
            var map = new Dictionary<string, CollectionAttrib>();
            foreach (var Class in Collections)
            {
                var path = $"{ThisName}\\{Class.CollectionName}";
                var properties = Class.GetAccessibles(eGetInfoType.PROPERTY_INFOS);
                foreach (var property in properties)
                {
                    var attrib = new CollectionAttrib((PropertyInfo) property, Class);
                    var subpath = $"{path}\\{attrib.PropertyName}";
                    attrib.FullPath = subpath;
                    attrib.Directory = path;
                    map[subpath] = attrib;
                }

                var nodes = Class.GetAllNodes();
                foreach (var node in nodes)
                {
                    if (node.SubNodes == null) continue;
                    foreach (var subnode in node.SubNodes)
                    {
                        var name = Class.GetType().GetProperty(subnode.NodeName).GetValue(Class);
                        var attribs = Class.GetSubnodeAttribs(subnode.NodeName, eGetInfoType.PROPERTY_INFOS);
                        foreach (var attrib in attribs)
                        {
                            var field = new CollectionAttrib((PropertyInfo) attrib, name);
                            var subpath = $"{path}\\{node.NodeName}\\{subnode.NodeName}\\{field.PropertyName}";
                            field.FullPath = subpath;
                            map[subpath] = field;
                        }
                    }
                }
            }

            return map;
        }

        public List<VirtualNode> GetAllNodes()
        {
            var list = new List<VirtualNode>(Length);
            foreach (var cla in Collections)
            {
                var node = new VirtualNode(cla.CollectionName);
                node.SubNodes = cla.GetAllNodes();
                list.Add(node);
            }

            return list;
        }

        #endregion

        public override string ToString()
        {
            return $"Collection: {ThisName} | Count = {Length}";
        }
    }
}