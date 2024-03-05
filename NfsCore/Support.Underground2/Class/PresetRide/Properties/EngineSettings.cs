using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte _engineStyle;

        /// <summary>
        /// Engine style value of the preset ride. Range: 0-3.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte EngineStyle
        {
            get => _engineStyle;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 3.");
                _engineStyle = value;
                Modified = true;
            }
        }
    }
}