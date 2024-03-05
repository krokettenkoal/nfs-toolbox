using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _rimBrand = BaseArguments.STOCK;
        private byte _rimStyle = 0;
        private byte _rimSize = 17;

        /// <summary>
        /// Rim brand value of the preset ride.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string RimBrand
        {
            get => _rimBrand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                switch (value)
                {
                    case BaseArguments.NULL:
                    case BaseArguments.STOCK:
                        _rimBrand = value;
                        break;
                    default:
                        if (!Map.RimBrands.Contains(value)) throw new MappingFailException();
                        _rimBrand = value;
                        break;
                }

                Modified = true;
            }
        }

        /// <summary>
        /// Rim style value of the preset ride. Range: 0-6.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RimStyle
        {
            get => _rimStyle;
            set
            {
                if (value < 7)
                    _rimStyle = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 6.");
                Modified = true;
            }
        }

        /// <summary>
        /// Rim size value of the preset ride. Range: 17-20.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RimSize
        {
            get => _rimSize;
            set
            {
                if (value is > 20 or < 17)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 17 to 20.");
                _rimSize = value;
                Modified = true;
            }
        }
    }
}