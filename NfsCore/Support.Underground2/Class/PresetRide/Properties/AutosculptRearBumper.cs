using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private sbyte _autoSculptRearBumper;

        /// <summary>
        /// Autosculpt rear bumper value of the preset ride. Range: 0-30, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string AutosculptRearBumper
        {
            get => _autoSculptRearBumper == -1 ? BaseArguments.NULL : _autoSculptRearBumper.ToString();
            set
            {
                if (value == BaseArguments.NULL)
                    _autoSculptRearBumper = -1;
                else
                {
                    if (!byte.TryParse(value, out var result) || result > 30)
                        throw new ArgumentOutOfRangeException(nameof(value),
                            "This value should be in range 0 to 30, or NULL.");
                    _autoSculptRearBumper = (sbyte) result;
                }

                Modified = true;
            }
        }
    }
}