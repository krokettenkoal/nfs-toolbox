using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private sbyte _aftermarketBodyKit;
        private byte _cvMiscStyle;

        /// <summary>
        /// Aftermarket bodykit value of the preset ride. Range: 0-4, NULL.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string AftermarketBodykit
        {
            get => _aftermarketBodyKit == -1 ? BaseArguments.NULL : _aftermarketBodyKit.ToString();
            set
            {
                if (value == BaseArguments.NULL)
                    _aftermarketBodyKit = -1;
                else
                {
                    if (!byte.TryParse(value, out var result) || result > 4)
                        throw new ArgumentOutOfRangeException(nameof(value),
                            "This value should be in range 0 to 4, or NULL.");
                    _aftermarketBodyKit = (sbyte) result;
                }

                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public byte CVMiscStyle
        {
            get => _cvMiscStyle;
            set
            {
                if (value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 4.");
                _cvMiscStyle = value;
                Modified = true;
            }
        }
    }
}