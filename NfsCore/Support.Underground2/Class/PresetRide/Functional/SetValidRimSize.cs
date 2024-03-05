using System.Linq;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Sets first valid rim outer max radius based on current brand and style.
        /// </summary>
        private void SetValidRimSize()
        {
            var rim = $"{_rimBrand}_STYLE{_rimStyle:00}";
            foreach (var str in Map.RimBrands.Where(str => str.StartsWith(rim)))
            {
                if (FormatX.GetByte(str, rim + "_{X}_##", out var radius))
                    _rimSize = radius;
            }
        }
    }
}