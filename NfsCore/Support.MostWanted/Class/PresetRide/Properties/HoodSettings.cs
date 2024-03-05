using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _hoodStyle = 0;
        private eBoolean _isCarbonFibreHood = eBoolean.False;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-32.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte HoodStyle
        {
            get => _hoodStyle;
            set
            {
                if (value > 32)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 32.");
                _hoodStyle = value;
                Modified = true;
            }
        }

        /// <summary>
        /// True if hood is carbonfibre, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsCarbonfibreHood
        {
            get => _isCarbonFibreHood;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isCarbonFibreHood = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }
    }
}