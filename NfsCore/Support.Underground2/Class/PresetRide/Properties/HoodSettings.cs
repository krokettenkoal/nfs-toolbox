using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte _hoodStyle;
        private eBoolean _isCarbonFibreHood = eBoolean.False;
        private byte _underHoodStyle;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-28.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte HoodStyle
        {
            get => _hoodStyle;
            set
            {
                if (value > 28)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 28.");
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

        /// <summary>
        /// Under hood style value of the preset ride. Range: 21-25 or 0.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte UnderHoodStyle
        {
            get => _underHoodStyle;
            set
            {
                if (value != 0 && value is < 21 or > 25)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "This value should be in range 21 to 25 or 0.");
                _hoodStyle = value;
                Modified = true;
            }
        }
    }
}