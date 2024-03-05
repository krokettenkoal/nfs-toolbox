using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _autoSculptSkirt;

        /// <summary>
        /// Autosculpt skirt value of the preset ride. Range: 0-10, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string AutosculptSkirt
        {
            get
            {
                return _autoSculptSkirt switch
                {
                    -1 => BaseArguments.NULL,
                    -2 => "CAPPED",
                    _ => _autoSculptSkirt.ToString()
                };
            }
            set
            {
                switch (value)
                {
                    case BaseArguments.NULL:
                        _autoSculptSkirt = -1;
                        break;
                    case "CAPPED":
                        _autoSculptSkirt = -2;
                        break;
                    default:
                    {
                        if (!byte.TryParse(value, out var result) || result > 14)
                            throw new ArgumentOutOfRangeException(nameof(value),
                                "This value should be in range 0 to 14, or NULL, or CAPPED.");
                        _autoSculptSkirt = (sbyte) result;
                        break;
                    }
                }

                Modified = true;
            }
        }
    }
}