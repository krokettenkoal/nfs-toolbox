using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private sbyte _exhaustStyle;
        private byte _exhaustSize;
        private eBoolean _isCenterExhaust = eBoolean.False;


        /// <summary>
        /// Exhaust style value of the preset ride. Possible values: 0-17, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string ExhaustStyle
        {
            get => _exhaustStyle == -1 ? BaseArguments.NULL : _exhaustStyle.ToString();
            set
            {
                if (value == BaseArguments.NULL)
                    _exhaustStyle = -1;
                else
                {
                    if (!byte.TryParse(value, out var result) || result > 17)
                        throw new ArgumentOutOfRangeException(nameof(value),
                            "This value should be in range 0 to 17, or NULL.");
                    _exhaustStyle = (sbyte) result;
                }

                Modified = true;
            }
        }

        /// <summary>
        /// Exhaust size value of the preset ride. Range: 0-100.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte ExhaustSize
        {
            get => _exhaustSize;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException();
                _exhaustSize = value;
                Modified = true;
            }
        }

        /// <summary>
        /// True if exhaust is centered, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsCenterExhaust
        {
            get => _isCenterExhaust;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _isCenterExhaust = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }
    }
}