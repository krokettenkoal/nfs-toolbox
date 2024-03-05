using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _vinylColor2;

        /// <summary>
        /// Second vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte VinylColor2
        {
            get => _vinylColor2;
            set
            {
                if (value > 80)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 80.");
                _vinylColor2 = value;
                Modified = true;
            }
        }
    }
}