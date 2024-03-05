using System;
using System.Collections.Generic;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Reflection.Abstract
{
    /// <summary>
    /// <see cref="SubPart"/> is a class that any <see cref="Collectable"/> may include in itself. 
    /// This class is not allowed to have any <see cref="AccessModifiableAttribute"/> 
    /// because all properties should be public, accessible and modifiable from the outside.
    /// </summary>
    public abstract class SubPart : Primitive
    {
        /// <summary>
        /// Optionable <see cref="Collectable"/> parent of this <see cref="SubPart"/> class.
        /// </summary>
        private Collectable Parent { get; set; }

        /// <summary>
        /// Returns object array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <param name="type"><see cref="eGetInfoType"/> enum value 
        /// that tells what objects type should be returned.</param>
        /// <returns>Array of strings.</returns>
        public override object[] GetAccessibles(eGetInfoType type)
        {
            var list = new List<object>();
            foreach (var property in GetType().GetProperties())
            {
                switch (type)
                {
                    case eGetInfoType.PROPERTY_NAMES:
                        list.Add(property.Name);
                        break;
                    case eGetInfoType.PROPERTY_INFOS:
                        list.Add(property);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="propertyName">Field name to get the value from.</param>
        public override string GetValue(string propertyName)
        {
            var property = GetType().GetProperty(propertyName);
            return property?.GetValue(this)?.ToString();
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
        /// <param name="error">Error occured in case setting value fails.</param>
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
    }
}