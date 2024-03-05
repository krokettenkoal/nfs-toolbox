using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte _spoilerStyle = 0;
        private eSTypes _spoilerType = eSTypes.STOCK;
        private eBoolean _isAutoSculptSpoiler = eBoolean.False;
        private eBoolean _isCarbonFibreSpoiler = eBoolean.False;

        /// <summary>
        /// Spoiler style of the preset ride. Range: 0-29.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte SpoilerStyle
        {
            get => _spoilerStyle;
            set
            {
                if (value > 29)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 29.");
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
        /// True if spoiler is autosculpt, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsAutosculptSpoiler
        {
            get => _isAutoSculptSpoiler;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isAutoSculptSpoiler = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
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