﻿using System.Linq;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Checks if a value passed is a valid rim style in terms of current brand.
        /// </summary>
        /// <param name="value">Rim style value to check.</param>
        /// <returns>True if value passed is valid, false otherwise.</returns>
        private bool IsValidRimStyle(byte value)
        {
            var rim = $"{_rimBrand}_STYLE";
            foreach (var str in Map.RimBrands.Where(str => str.StartsWith(rim)))
            {
                if (!FormatX.GetByte(str, rim + "{X}_##_##", out var radius))
                    continue;
                if (value == radius)
                    return true;
            }

            return false;
        }
    }
}