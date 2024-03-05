using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte _paintSwatch = 1;

        /// <summary>
        /// Gradient color value of the paint of the preset ride. Range: 0-90.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte PaintSwatch
        {
            get => _paintSwatch;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _paintSwatch = value;
                Modified = true;
            }
        }
    }
}