using System.Linq;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Checks if a value passed is a valid outer max radius in terms of current 
        /// brand, style and size.
        /// </summary>
        /// <param name="value">Outer max radius value to check.</param>
        /// <returns>True if value passed is valid, false otherwise.</returns>
        private bool IsValidRimOuterMax(byte value)
        {
            var rim = $"{_rimBrand}_STYLE{_rimStyle:00}_{_rimSize}_";
            foreach (var str in Map.RimBrands.Where(str => str.StartsWith(rim)))
            {
                if (!FormatX.GetByte(str, rim + "{X}", out var radius))
                    continue;
                if (value == radius)
                    return true;
            }

            return false;
        }
    }
}