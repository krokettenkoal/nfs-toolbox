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
        /// Decompile entire acid effects block into Vector of separate elements.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of acid effects block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_AcidEffects(byte* bytePtrT, uint length, Database.Underground2Db db)
        {
            const uint size = 0xD0;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                var offset = 0x18 + loop * size; // current offset of the acid effect (padding included)

                // Get CollectionName
                var collectionName = ScriptX.NullTerminatedString(bytePtrT + offset + 0x90, 0x40);
                collectionName = Resolve.GetPathFromCollection(collectionName);
                Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
                var acidEffect = new AcidEffect((IntPtr) (bytePtrT + offset), collectionName, db);
                db.AcidEffects.Collections.Add(acidEffect);
            }
        }
    }
}