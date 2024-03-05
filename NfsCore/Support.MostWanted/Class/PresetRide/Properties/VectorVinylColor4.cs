using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _vinylColor4;

        /// <summary>
        /// Fourth vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte VinylColor4
        {
            get => _vinylColor4;
            set
            {
                if (value > 80)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 80.");
                _vinylColor4 = value;
                Modified = true;
            }
        }
    }
}