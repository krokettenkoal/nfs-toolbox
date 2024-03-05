using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Carbon.Class
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
                        if (Map.RimBrands.Contains(value))
                        {
                            _rimBrand = value;
                            break;
                        }

                        throw new MappingFailException();
                }

                Modified = true;
            }
        }

        /// <summary>
        /// Rim style value of the preset ride. Range: 0-10 for AUTOSCLPT rim brand, 0-6 otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RimStyle
        {
            get => _rimStyle;
            set
            {
                if (_rimBrand == Map.RimBrands[0] && value < 11)
                    _rimStyle = value;
                else if (value < 7)
                    _rimStyle = value;
                else
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 6 " +
                                                          "for aftermarket, or 0 to 10 for autosculpt.");
                Modified = true;
            }
        }

        /// <summary>
        /// Rim size value of the preset ride. Range: 17-21.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RimSize
        {
            get => _rimSize;
            set
            {
                if (value is > 21 or < 17)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 17 to 21.");
                _rimSize = value;
                Modified = true;
            }
        }
    }
}