using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets the frontend group, decompresses it if needed, and plugs into Vector.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of frontend group in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_FNGroup(byte* bytePtrT, uint length, Database.Underground2Db db)
        {
            // Copy data and decompress
            var data = new byte[length];
            fixed (byte* dataPtrT = &data[0])
            {
                for (var a1 = 0; a1 < data.Length; ++a1)
                    *(dataPtrT + a1) = *(bytePtrT + a1);
            }

            data = SAT.Decompress(data);
            var fnGroup = new FNGroup(data, db);

            // Check whether this FEng class already exists in the database
            if (fnGroup.Destroy)
                return;
            if (db.FNGroups.FindCollection(fnGroup.CollectionName) != null)
                return;
            db.FNGroups.Collections.Add(fnGroup);
            Bin.Hash(fnGroup.CollectionName);
        }
    }
}