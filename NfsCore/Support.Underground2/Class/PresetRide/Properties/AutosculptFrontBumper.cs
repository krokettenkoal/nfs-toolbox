using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private sbyte _autosculptFrontBumper;

        /// <summary>
        /// Autosculpt front bumper value of the preset ride. Range: 0-30, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string AutosculptFrontBumper
        {
            get => _autosculptFrontBumper == -1 ? BaseArguments.NULL : _autosculptFrontBumper.ToString();
            set
            {
                if (value == BaseArguments.NULL)
                    _autosculptFrontBumper = -1;
                else
                {
                    if (!byte.TryParse(value, out var result) || result > 30)
                        throw new ArgumentOutOfRangeException(nameof(value),
                            "This value should be in range 0 to 30, or NULL.");
                    _autosculptFrontBumper = (sbyte) result;
                }

                Modified = true;
            }
        }
    }
}