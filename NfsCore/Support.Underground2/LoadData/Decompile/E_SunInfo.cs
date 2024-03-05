using System;
using NfsCore.Global;
using NfsCore.Support.Underground2.Gameplay;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire suninfo block into Vector of separate elements.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of suninfo block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_SunInfo(byte* bytePtrT, uint length, Database.Underground2Db db)
        {
            const uint size = 0x110;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                var offset = 8 + loop * size; // current offset of the suninfo (padding included)
                // Get CollectionName
                var collectionName = ScriptX.NullTerminatedString(bytePtrT + offset + 8, 0x18);
                collectionName = Resolve.GetPathFromCollection(collectionName);
                Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
                var sunInfo = new SunInfo((IntPtr) (bytePtrT + offset), collectionName, db);
                db.SunInfos.Collections.Add(sunInfo);
            }
        }
    }
}