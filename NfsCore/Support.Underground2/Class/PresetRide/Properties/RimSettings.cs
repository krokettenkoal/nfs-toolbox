using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private string _rimBrand = BaseArguments.STOCK;
        private byte _rimStyle = 0;
        private byte _rimSize = 18;
        private byte _rimOuterMax = 24;
        private eBoolean _isSpinningRim = eBoolean.False;

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
                        if (IsValidRimBrand(value))
                        {
                            _rimBrand = value;
                            SetValidRimStyle();
                            SetValidRimSize();
                            SetValidRimOuterMax();
                            SetValidSpinning();
                            break;
                        }

                        throw new MappingFailException();
                }

                Modified = true;
            }
        }

        /// <summary>
        /// Rim style value of the preset ride. Range varies for different brands.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RimStyle
        {
            get => _rimStyle;
            set
            {
                if (!IsValidRimStyle(value))
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "This value is outside of range of valid values.");
                _rimStyle = value;
                SetValidRimSize();
                SetValidRimOuterMax();
                SetValidSpinning();
                Modified = true;
            }
        }

        /// <summary>
        /// Rim size value of the preset ride. Range varies for different brands and styles.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RimSize
        {
            get => _rimSize;
            set
            {
                if (!IsValidRimSize(value))
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "This value is outside of range of valid values.");
                _rimSize = value;
                SetValidRimOuterMax();
                SetValidSpinning();
                Modified = true;
            }
        }

        /// <summary>
        /// Rim outer max value of the preset ride. Range varies for different brands, styles, and sizes.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte RimOuterMax
        {
            get => _rimOuterMax;
            set
            {
                if (!IsValidRimOuterMax(value))
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "This value is outside of range of valid values.");
                _rimOuterMax = value;
                SetValidSpinning();
                Modified = true;
            }
        }

        /// <summary>
        /// If set to true, rim is a spinner type, otherwise a regular rim.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsSpinningRim
        {
            get => _isSpinningRim;
            set
            {
                if (value == eBoolean.True)
                {
                    if (ValidateSpinning())
                        _isSpinningRim = value;
                    else
                        throw new Exception("Spinner with the brand, style, size and outer max specified " +
                                            "does not exist.");
                }
                else
                {
                    _isSpinningRim = value;
                    Modified = true;
                }
            }
        }
    }
}