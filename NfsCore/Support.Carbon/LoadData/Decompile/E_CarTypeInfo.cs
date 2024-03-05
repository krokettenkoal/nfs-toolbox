﻿using System;
using NfsCore.Global;
using NfsCore.Support.Carbon.Class;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire cartypeinfo block into Vector of separate elements.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of cartypeinfo block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_CarTypeInfo(byte* bytePtrT, uint length, Database.CarbonDb db)
        {
            const uint size = 0xD0;
            for (uint loop = 0; loop < length / size; ++loop)
            {
                var offset = 8 + loop * size; // current offset of the cartypeinfo (padding included)

                // Get CollectionName
                var collectionName = ScriptX.NullTerminatedString(bytePtrT + offset, 0x10);
                collectionName = Resolve.GetPathFromCollection(collectionName);
                Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
                if (!_libColBlockExists)
                    Map.CollisionMap[Vlt.Hash(collectionName)] = collectionName;

                var carTypeInfo = new CarTypeInfo((IntPtr) (bytePtrT + offset), collectionName, db);
                db.CarTypeInfos.Collections.Add(carTypeInfo);
            }
        }
    }
}