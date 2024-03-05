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
    public class Root<T> where T : Collectable
    {
        public List<T> Collections { get; } = new();
        public string ThisName { get; }
        public int Length => Collections.Count;
        private int MaxCNameLength { get; }
        internal int CNameOffsetAt { get; }
        private int BaseClassSize { get; }
        private bool Resizable { get; }
        private BasicBase Database { get; }

        private readonly bool _importable;

        public Root(string name, int maxlength, int offsetAt, int baseSize, bool resizable, bool importable,
            BasicBase data)
        {
            ThisName = name;
            MaxCNameLength = maxlength;
            CNameOffsetAt = offsetAt;
            BaseClassSize = baseSize;
            Resizable = resizable;
            _importable = importable;
            Database = data;
        }

        #region Collection Access

        public T this[string collectionName] => FindCollection(collectionName);
        public T this[int index] => index < Length ? Collections[index] : null;

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

        public T FindCollection(string collectionName)
        {
            return Collections.Find(c => c.CollectionName == (collectionName ?? string.Empty));
        }

        public T FindCollection(uint key, eKeyType type)
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

        public T FindClassWithValue(string field, object value)
        {
            try
            {
                return Collections.FirstOrDefault(obj => obj.GetType().GetProperty(field)?.GetValue(obj) == value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool TryGetCollection(string collectionName, out T collection)
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
            var property = typeof(T).GetProperty(field);
            if (property == null) return false;
            return Attribute.IsDefined(property, typeof(StaticModifiableAttribute)) &&
                   Collections.Select(collection => collection.SetValue(field, value)).All(pass => pass);
        }

        public bool TrySetStaticValue(string field, string value, out string error)
        {
            error = null;
            var property = typeof(T).GetProperty(field);
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
                var ctor = typeof(T).GetConstructor(new[] {typeof(string), Database.GetType()});
                if (ctor == null) return false;
                var instance = (T) ctor.Invoke(new object[] {value, Database});
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

                var ctor = typeof(T).GetConstructor(new[] {typeof(string), Database.GetType()});
                if (ctor == null)
                {
                    error = $"Class with CollectionName {value} does not have a constructor.";
                    return false;
                }

                var instance = (T) ctor.Invoke(new object[] {value, Database});
                Collections.Add(instance);
                return true;
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }

        public bool TryRemoveCollection(string value)
        {
            if (!Resizable) return false;
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (!TryGetCollection(value, out var cla)) return false;
            return cla.Deletable && Collections.Remove(cla);
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

        public bool TryCloneCollection(string value, string copyFrom)
        {
            try
            {
                if (!Resizable) return false;
                if (string.IsNullOrWhiteSpace(value)) return false;
                if (MaxCNameLength != -1 && value.Length > MaxCNameLength) return false;
                if (FindCollection(value) != null) return false;
                if (!TryGetCollection(copyFrom, out var cla)) return false;

                var instance = (T) cla.MemoryCast(value);
                Collections.Add(instance);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryCloneCollection(string value, string copyFrom, out string error)
        {
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

                if (!TryGetCollection(copyFrom, out var cla))
                {
                    error = $"Class with CollectionName {copyFrom} does not exist.";
                    return false;
                }

                var instance = (T) cla.MemoryCast(value);
                Collections.Add(instance);
                return true;
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }

        public unsafe bool TryImportCollection(byte[] data)
        {
            if (!_importable) return false;
            if (data.Length != BaseClassSize) return false;

            fixed (byte* dataPtrT = &data[0])
            {
                var collectionName = ScriptX.NullTerminatedString(dataPtrT);
                if (FindCollection(collectionName) != null) return false;

                var ctor = typeof(T).GetConstructor(new[]{typeof(IntPtr), typeof(string), Database.GetType()});
                if (ctor == null) return false;
                var instance = (T) ctor.Invoke(new object[]{(IntPtr) dataPtrT, collectionName, Database});
                Collections.Add(instance);
            }

            return true;
        }

        public unsafe bool TryImportCollection(byte[] data, out string error)
        {
            error = null;
            if (!_importable)
            {
                error = "Class collection specified is not importable.";
                return false;
            }

            if (data.Length != BaseClassSize)
            {
                error = $"Size of the class imported is {data.Length} bytes, while should be {BaseClassSize} bytes.";
                return false;
            }

            fixed (byte* dataPtrT = &data[0])
            {
                var collectionName = ScriptX.NullTerminatedString(dataPtrT);
                if (FindCollection(collectionName) != null)
                {
                    error = $"Class with CollectionName {collectionName} already exists.";
                    return false;
                }

                var ctor = typeof(T).GetConstructor(new[]{typeof(IntPtr), typeof(string), Database.GetType()});
                if (ctor == null)
                {
                    error = $"Class with CollectionName {collectionName} does not have a constructor.";
                    return false;
                }

                var instance = (T) ctor.Invoke(new object[]{(IntPtr) dataPtrT, collectionName, Database});
                Collections.Add(instance);
            }

            return true;
        }

        public bool TryExportCollection(string value, string filepath)
        {
            if (!_importable) return false;
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (!TryGetCollection(value, out var cla)) return false;
            if (!Directory.Exists(Path.GetDirectoryName(filepath))) return false;

            var arr = (byte[]) cla.GetType()
                .GetMethod("Assemble")
                ?.Invoke(cla, Array.Empty<object>());

            if (arr == null) return false;
            using var bw = new BinaryWriter(File.Open(filepath, FileMode.Create));
            bw.Write(arr);
            return true;
        }

        public bool TryExportCollection(string value, string filepath, out string error)
        {
            error = null;
            if (!_importable)
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

            var arr = (byte[]) cla.GetType().GetMethod("Assemble")?.Invoke(cla, Array.Empty<object>());
            if (arr == null)
            {
                error = $"Unable to assemble class with CollectionName {value}.";
                return false;
            }

            using var bw = new BinaryWriter(File.Open(filepath, FileMode.Create));
            bw.Write(arr);
            return true;
        }

        #endregion

        #region Collection Reflection

        public object[] GetAccessibleProperties(string collectionName)
        {
            return !TryGetCollection(collectionName, out var cla)
                ? null
                : cla.GetAccessibles(eGetInfoType.PROPERTY_NAMES);
        }

        public Dictionary<string, CollectionAttrib> GetAttributeMap()
        {
            var map = new Dictionary<string, CollectionAttrib>();
            foreach (var coll in Collections)
            {
                var path = $"{ThisName}\\{coll.CollectionName}";
                var properties = coll.GetAccessibles(eGetInfoType.PROPERTY_INFOS);
                foreach (var property in properties)
                {
                    var attrib = new CollectionAttrib((PropertyInfo) property, coll);
                    var subPath = $"{path}\\{attrib.PropertyName}";
                    attrib.FullPath = subPath;
                    attrib.Directory = path;
                    map[subPath] = attrib;
                }

                var nodes = coll.GetAllNodes();
                foreach (var node in nodes)
                {
                    if (node.SubNodes == null) continue;
                    foreach (var subNode in node.SubNodes)
                    {
                        var name = coll.GetType().GetProperty(subNode.NodeName)?.GetValue(coll);
                        var attribs = coll.GetSubnodeAttribs(subNode.NodeName, eGetInfoType.PROPERTY_INFOS);
                        foreach (var attrib in attribs)
                        {
                            var field = new CollectionAttrib((PropertyInfo) attrib, name);
                            var subPath = $@"{path}\{node.NodeName}\{subNode.NodeName}\{field.PropertyName}";
                            field.FullPath = subPath;
                            map[subPath] = field;
                        }
                    }
                }
            }

            return map;
        }

        public IEnumerable<VirtualNode> GetAllNodes()
        {
            return Collections.Select(cla => new VirtualNode(cla.CollectionName) {SubNodes = cla.GetAllNodes()});
        }

        #endregion

        public override string ToString()
        {
            return $"Collection: {ThisName} | Count = {Length}";
        }
    }
}