﻿using System.Collections.Generic;
using NfsCore.Reflection;

namespace NfsCore.Global
{
    public static class Map
    {
        /// <summary>
        /// Represents all binary memory hashes through runtime of the library.
        /// </summary>
        public static Dictionary<uint, string> BinKeys { get; } = new();

        /// <summary>
        /// Represents all vault memory hashes through runtime of the library.
        /// </summary>
        public static Dictionary<uint, string> VltKeys { get; } = new();

        /// <summary>
        /// Represents map of all possible collisions that can be used.
        /// </summary>
        public static Dictionary<uint, string> CollisionMap { get; set; } = new();

        /// <summary>
        /// Represents list of all possible window tints that can be used.
        /// </summary>
        public static List<string> WindowTintMap { get; set; } = new();

        /// <summary>
        /// Represents array of all possible rim brands that can be used.
        /// </summary>
        public static List<string> RimBrands { get; set; } = new();

        /// <summary>
        /// Represents array of all possible audio types that can be used.
        /// </summary>
        public static List<string> AudioTypes { get; set; } = new();

        /// <summary>
        /// Represents list of all possible paint type that can be used in UG2 support.
        /// </summary>
        public static List<string> UG2PaintTypes { get; set; } = new();

        /// <summary>
        /// Represents list of all possible caliper paints that can be used in UG2 support.
        /// </summary>
        public static List<string> UG2CaliperPaints { get; set; } = new();

        /// <summary>
        /// Represents list of all possible rim paints that can be used in UG2 support.
        /// </summary>
        public static List<string> UG2RimPaints { get; set; } = new();

        /// <summary>
        /// Represents list of all possible vinyl paints that can be used in UG2 support.
        /// </summary>
        public static List<string> UG2VinylPaints { get; set; } = new();

        /// <summary>
        /// Index table of all performance parts.
        /// </summary>
        public static uint[,,] PerfPartTable { get; set; }

        /// <summary>
        /// Lookup through raider key map that throws no exceptions.
        /// </summary>
        /// <param name="key">Binary memory hash to look for.</param>
        /// <param name="nullIfZero">Whether to return <see cref="BaseArguments.NULL"/> if the given <paramref name="key"/> is <c>0</c></param>
        /// <returns>Result value from the key passed, if value was not found, returns null instead.</returns>
        public static string Lookup(uint key, bool nullIfZero)
        {
            if (nullIfZero && key == 0) return BaseArguments.NULL;
            return BinKeys.GetValueOrDefault(key);
        }
    }
}
