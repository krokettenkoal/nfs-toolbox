using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Disperses all settings from the rim string passed.
        /// </summary>
        /// <param name="rim">Rim string to be dispersed.</param>
        private void DisperseRimSettings(string rim)
        {
            var potentialSpi = false;
            if (rim.EndsWith("_SPI"))
            {
                potentialSpi = true;
                rim = rim[..^4];
            }

            _rimBrand = FormatX.GetString(rim, "{X}_STYLE##_##_##");
            if (!FormatX.GetByte(rim, _rimBrand + "_STYLE{X}_##_##", out var thisStyle))
                thisStyle = 1;
            if (!FormatX.GetByte(rim, _rimBrand + "_STYLE##_{X}_##", out var thisSize))
                thisSize = 18;
            if (!FormatX.GetByte(rim, _rimBrand + "_STYLE##_##_{X}", out var thisMax))
                thisMax = 24;
            _rimStyle = thisStyle;
            _rimSize = thisSize;
            _rimOuterMax = thisMax;
            _isSpinningRim = potentialSpi ? eBoolean.True : eBoolean.False;
        }
    }
}