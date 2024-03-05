using NfsCore.Global;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// If spinning was set before and rim was changed, checks if spinner still exists.
        /// </summary>
        private void SetValidSpinning()
        {
            if (_isSpinningRim == eBoolean.False) return;
            var rim = $"{_rimBrand}_STYLE{_rimStyle:00}_{_rimSize}_{_rimOuterMax}_SPI";
            if (Map.RimBrands.Contains(rim)) return;
            _isSpinningRim = eBoolean.False;
        }
    }
}