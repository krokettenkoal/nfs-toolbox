using System;
using System.Reflection;

namespace NfsCore.Reflection.Abstract
{
    public class CollectionAttrib
    {
        public PropertyInfo Attribute { get; set; }
        public object Parent { get; set; }
        public string FullPath { get; set; }
        public string Directory { get; set; }
        public string PropertyName => Attribute.Name;
        public string Value => Attribute.GetValue(Parent)?.ToString();
        public Type PropertyType => Attribute.PropertyType;
        public MethodInfo Set => Attribute.GetSetMethod();

        public CollectionAttrib()
        {
        }

        public CollectionAttrib(PropertyInfo property, object parent)
        {
            Parent = parent;
            Attribute = property;
        }

        public override string ToString()
        {
            return $"{FullPath} | {PropertyType}";
        }
    }
}