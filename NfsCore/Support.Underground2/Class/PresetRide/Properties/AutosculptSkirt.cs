using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private sbyte _autoSculptSkirt;

        /// <summary>
        /// Autosculpt skirt value of the preset ride. Range: 0-30, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string AutosculptSkirt
        {
            get => _autoSculptSkirt == -1 ? BaseArguments.NULL : _autoSculptSkirt.ToString();
            set
            {
                if (value == BaseArguments.NULL)
                    _autoSculptSkirt = -1;
                else
                {
                    if (!byte.TryParse(value, out var result) || result > 30)
                        throw new ArgumentOutOfRangeException(nameof(value),
                            "This value should be in range 0 to 30, or NULL, or CAPPED.");
                    _autoSculptSkirt = (sbyte) result;
                }

                Modified = true;
            }
        }
    }
}