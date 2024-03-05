using NfsCore.Reflection;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private string GetValidRimString()
        {
            if (_rimBrand is BaseArguments.NULL or BaseArguments.STOCK)
                return $"{MODEL}_KIT00_FRONT_WHEEL";
            var result = $"{_rimBrand}_STYLE{_rimStyle:00}_{_rimSize:00}_{_rimOuterMax:00}";
            return _isSpinningRim == eBoolean.True ? result + "_SPI" : result;
        }
    }
}