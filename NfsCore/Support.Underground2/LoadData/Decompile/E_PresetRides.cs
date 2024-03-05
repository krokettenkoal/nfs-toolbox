using System;
using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire preset rides block into Vector of separate elements.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of preset rides block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_PresetRides(byte* bytePtrT, uint length, Database.Underground2Db db)
        {
            const uint size = 0x338;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                var offset = loop * size; // current offset of the preset ride
                // Get CollectionName
                var collectionName = ScriptX.NullTerminatedString(bytePtrT + offset + 0x28, 0x20);
                collectionName = Resolve.GetPathFromCollection(collectionName);
                Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
                var presetRide = new PresetRide((IntPtr) (bytePtrT + offset), collectionName, db);
                db.PresetRides.Collections.Add(presetRide);
            }
        }
    }
}