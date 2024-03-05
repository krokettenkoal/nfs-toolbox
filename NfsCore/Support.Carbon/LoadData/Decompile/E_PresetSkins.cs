using System;
using NfsCore.Global;
using NfsCore.Support.Carbon.Class;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire preset skins block into Vector of separate elements.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of preset skins block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_PresetSkins(byte* bytePtrT, uint length, Database.CarbonDb db)
        {
            const uint size = 0x68;
            for (uint loop = 0; loop < length / size; ++loop)
            {
                var offset = loop * size; // current offset of the preset skin
                // Get CollectionName
                var collectionName = ScriptX.NullTerminatedString(bytePtrT + offset + 0x8, 0x20);
                collectionName = Resolve.GetPathFromCollection(collectionName);
                Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
                var presetSkin = new PresetSkin((IntPtr) (bytePtrT + offset), collectionName, db);
                db.PresetSkins.Collections.Add(presetSkin);
            }
        }
    }
}