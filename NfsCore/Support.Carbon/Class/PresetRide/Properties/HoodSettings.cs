using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte _hoodStyle = 0;
        private eBoolean _isAutoSculptHood = eBoolean.False;
        private eBoolean _isCarbonFibreHood = eBoolean.False;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-8.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte HoodStyle
        {
            get => _hoodStyle;
            set
            {
                if (value > 8)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 8.");
                _hoodStyle = value;
                Modified = true;
            }
        }

        /// <summary>
        /// True if hood is autosculpt, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsAutosculptHood
        {
            get => _isAutoSculptHood;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isAutoSculptHood = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
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