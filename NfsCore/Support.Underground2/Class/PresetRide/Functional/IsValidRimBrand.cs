using System.Linq;
using NfsCore.Global;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Checks if a value passed is a valid rim brand that exists in the map.
        /// </summary>
        /// <param name="brand">Rim brand value to check.</param>
        /// <returns>True if value passed is valid, false otherwise.</returns>
        private static bool IsValidRimBrand(string brand)
        {
            return Map.RimBrands.Any(str => str.StartsWith(brand));
        }
    }
}