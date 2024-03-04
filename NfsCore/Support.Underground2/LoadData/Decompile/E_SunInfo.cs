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
        /// <param name="byteptr_t">Pointer to the beginning of suninfo block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_SunInfo(byte* byteptr_t, uint length, Database.Underground2Db db)
        {
            const uint size = 0x110;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                uint offset = 8 + loop * size; // current offset of the suninfo (padding included)

                // Get CollectionName
                string CName = ScriptX.NullTerminatedString(byteptr_t + offset + 8, 0x18);

                CName = Resolve.GetPathFromCollection(CName);
                Map.BinKeys[Bin.Hash(CName)] = CName;

                var Class = new SunInfo((IntPtr)(byteptr_t + offset), CName, db);
                db.SunInfos.Collections.Add(Class);
            }
        }
    }
}