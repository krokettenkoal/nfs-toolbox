using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadWorldShops(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[2] == -1) return; // if world shops block does not exist
            if (*(uint*) (bytePtrT + partOffsets[2]) != CareerInfo.SHOP_BLOCK)
                return; // check world shops block ID

            var size = *(int*) (bytePtrT + partOffsets[2] + 4) / 0xA0;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[2] + a1 * 0xA0 + 8;
                var worldShop = new WorldShop(bytePtrT + ptrHeader, db);
                db.WorldShops.Collections.Add(worldShop);
            }
        }
    }
}