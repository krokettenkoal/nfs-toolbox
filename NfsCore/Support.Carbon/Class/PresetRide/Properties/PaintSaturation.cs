using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private float _saturation;

        /// <summary>
        /// Saturation value of the paint of the preset ride. Range: (float)0-1.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float PaintSaturation
        {
            get => _saturation;
            set
            {
                if (value is > 1 or < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 1.");
                _saturation = value;
                Modified = true;
            }
        }
    }
}