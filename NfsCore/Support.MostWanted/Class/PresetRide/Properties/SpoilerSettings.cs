using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private byte _spoilerStyle = 0;
        private eSTypes _spoilerType = eSTypes.STOCK;
        private eBoolean _isCarbonFibreSpoiler = eBoolean.False;

        /// <summary>
        /// Spoiler style of the preset ride. Range: 0-44.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte SpoilerStyle
        {
            get => _spoilerStyle;
            set
            {
                if (value > 44)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 44.");
                _spoilerStyle = value;
                Modified = true;
            }
        }

        /// <summary>
        /// Spoiler type of the preset ride. Range: STOCK, BASE, _HATCH, _PORSCHES, _CARRERA, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eSTypes SpoilerType
        {
            get => _spoilerType;
            set
            {
                if (Enum.IsDefined(typeof(eSTypes), value))
                {
                    _spoilerType = value;
                    Modified = true;
                }
                else
                    throw new MappingFailException();
            }
        }

        /// <summary>
        /// True if spoiler is carbonfibre, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsCarbonfibreSpoiler
        {
            get => _isCarbonFibreSpoiler;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isCarbonFibreSpoiler = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }
    }
}