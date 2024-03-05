using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _vinylColor1;

        /// <summary>
        /// First vinyl color of the preset ride. Range: 0-80.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte VinylColor1
        {
            get => _vinylColor1;
            set
            {
                if (value > 80)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 80.");
                _vinylColor1 = value;
                Modified = true;
            }
        }
    }
}