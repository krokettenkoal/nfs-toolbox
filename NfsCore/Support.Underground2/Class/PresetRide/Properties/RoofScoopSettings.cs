using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private byte _roofScoopStyle = 0;
        private eBoolean _isOffsetRoofScoop = eBoolean.False;
        private eBoolean _isDualRoofScoop = eBoolean.False;
        private eBoolean _isCarbonFibreRoofScoop = eBoolean.False;

        /// <summary>
        /// RoofScoop style value of the preset ride. Range: 0-17.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RoofScoopStyle
        {
            get => _roofScoopStyle;
            set
            {
                if (value > 17)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 18.");
                _roofScoopStyle = value;
                Modified = true;
            }
        }

        /// <summary>
        /// True if roof scoop is offset, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsOffsetRoofScoop
        {
            get => _isOffsetRoofScoop;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isOffsetRoofScoop = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if roof scoop is dual, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsDualRoofScoop
        {
            get => _isDualRoofScoop;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isDualRoofScoop = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if roof scoop is carbonfibre, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsCarbonfibreRoofScoop
        {
            get => _isCarbonFibreRoofScoop;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isCarbonFibreRoofScoop = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }
    }
}