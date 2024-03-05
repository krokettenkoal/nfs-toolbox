using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte _headlightStyle = 0;
        private byte _brakeLightStyle = 0;

        /// <summary>
        /// Headlight style value of the preset ride. Range: 0-14.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte HeadlightStyle
        {
            get => _headlightStyle;
            set
            {
                if (value > 14)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 14.");
                _headlightStyle = value;
                Modified = true;
            }
        }

        /// <summary>
        /// RoofScoop style value of the preset ride. Range: 0-14.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte BrakelightStyle
        {
            get => _brakeLightStyle;
            set
            {
                if (value > 14)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 14.");
                _brakeLightStyle = value;
                Modified = true;
            }
        }
    }
}