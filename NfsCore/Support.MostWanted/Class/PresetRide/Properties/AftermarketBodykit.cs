using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private sbyte _aftermarketBodyKit;

        /// <summary>
        /// Aftermarket bodykit value of the preset ride. Range: 0-5, NULL.
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
                    if (!byte.TryParse(value, out var result) || result > 5)
                        throw new ArgumentOutOfRangeException(nameof(value),
                            "This value should be in range 0 to 5, or NULL.");
                    _aftermarketBodyKit = (sbyte) result;
                    Modified = true;
                }
            }
        }
    }
}