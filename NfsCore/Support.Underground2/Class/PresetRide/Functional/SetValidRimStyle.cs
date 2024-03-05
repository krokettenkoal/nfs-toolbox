using System.Linq;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Sets first valid rim style based on current brand.
        /// </summary>
        private void SetValidRimStyle()
        {
            var rim = $"{_rimBrand}_STYLE";
            foreach (var str in Map.RimBrands.Where(str => str.StartsWith(rim)))
            {
                if (FormatX.GetByte(str, rim + "{X}_##_##", out var radius))
                    _rimStyle = radius;
            }
        }
    }
}