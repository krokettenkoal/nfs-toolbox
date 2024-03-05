using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte _trunkAudioStyle;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-3.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte TrunkAudioStyle
        {
            get => _trunkAudioStyle;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 3.");
                _trunkAudioStyle = value;
                Modified = true;
            }
        }
    }
}