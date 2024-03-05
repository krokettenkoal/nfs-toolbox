using System.Linq;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Checks if a value passed is a valid rim size in terms of current 
        /// brand and style.
        /// </summary>
        /// <param name="value">Rim size value to check.</param>
        /// <returns>True if value passed is valid, false otherwise.</returns>
        private bool IsValidRimSize(byte value)
        {
            var rim = $"{_rimBrand}_STYLE{_rimStyle:00}_";
            foreach (var str in Map.RimBrands.Where(str => str.StartsWith(rim)))
            {
                if (!FormatX.GetByte(str, rim + "{X}_##", out var radius))
                    continue;
                if (value == radius)
                    return true;
            }

            return false;
        }
    }
}