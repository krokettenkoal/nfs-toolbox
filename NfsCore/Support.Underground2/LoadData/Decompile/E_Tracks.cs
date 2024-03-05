using System;
using NfsCore.Global;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Support.Underground2.Gameplay;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire track block into Vector of separate elements.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of track block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_Tracks(byte* bytePtrT, uint length, Database.Underground2Db db)
        {
            const uint size = 0x128;
            for (uint loop = 0; loop < length / size; ++loop)
            {
                var offset = loop * size; // current offset of the cartypeinfo (padding included)
                // Get CollectionName
                var collectionName = ScriptX.NullTerminatedString(bytePtrT + offset + 0x20, 0x20);
                collectionName = Parse.TrackCollectionName(collectionName);
                collectionName = Resolve.GetPathFromCollection(collectionName);
                Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
                var track = new Track((IntPtr) (bytePtrT + offset), collectionName, db);
                db.Tracks.Collections.Add(track);
            }
        }
    }
}