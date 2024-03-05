using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _autoSculptFrontBumper;

        /// <summary>
        /// Autosculpt front bumper value of the preset ride. Range: 0-10, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string AutosculptFrontBumper
        {
            get => _autoSculptFrontBumper == -1 ? BaseArguments.NULL : _autoSculptFrontBumper.ToString();
            set
            {
                if (value == BaseArguments.NULL)
                    _autoSculptFrontBumper = -1;
                else
                {
                    if (!byte.TryParse(value, out var result) || result > 10)
                        throw new ArgumentOutOfRangeException(nameof(value),
                            "This value should be in range 0 to 10, or NULL.");
                    _autoSculptFrontBumper = (sbyte) result;
                }

                Modified = true;
            }
        }
    }
}