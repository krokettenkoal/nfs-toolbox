using NfsCore.Global;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private bool ValidateSpinning()
        {
            var rim = $"{_rimBrand}_STYLE{_rimStyle:00}_{_rimSize}_{_rimOuterMax}_SPI";
            return Map.RimBrands.Contains(rim);
        }
    }
}