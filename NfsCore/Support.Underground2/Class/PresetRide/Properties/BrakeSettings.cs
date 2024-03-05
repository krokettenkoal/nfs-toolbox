using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte _frontBrakeStyle;
        private byte _rearBrakeStyle;

        /// <summary>
        /// Front brake style value of the preset ride. Range: 0-3.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte FrontBrakeStyle
        {
            get => _frontBrakeStyle;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 3.");
                _frontBrakeStyle = value;
                Modified = true;
            }
        }

        /// <summary>
        /// Rear brake style value of the preset ride. Range: 0-3.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RearBrakeStyle
        {
            get => _rearBrakeStyle;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 3.");
                _rearBrakeStyle = value;
                Modified = true;
            }
        }
    }
}