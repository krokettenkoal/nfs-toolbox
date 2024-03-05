using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte _exhaustStyle;

        /// <summary>
        /// Exhaust style value of the preset ride. Range: 0-10.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte ExhaustStyle
        {
            get => _exhaustStyle;
            set
            {
                if (value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 10.");
                _exhaustStyle = value;
                Modified = true;
            }
        }
    }
}