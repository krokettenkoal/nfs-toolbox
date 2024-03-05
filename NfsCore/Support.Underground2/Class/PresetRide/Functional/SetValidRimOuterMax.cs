using System.Linq;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Sets first valid rim outer max radius based on current brand, style and size.
        /// </summary>
        private void SetValidRimOuterMax()
        {
            var rim = $"{_rimBrand}_STYLE{_rimStyle:00}_{_rimSize}_";
            foreach (var str in Map.RimBrands.Where(str => str.StartsWith(rim)))
            {
                if (!FormatX.GetByte(str, rim + "{X}", out var radius)) continue;
                _rimOuterMax = radius;
                return;
            }
        }
    }
}