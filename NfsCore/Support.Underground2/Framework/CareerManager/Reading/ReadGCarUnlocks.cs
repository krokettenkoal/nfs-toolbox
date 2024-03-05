using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadGCarUnlocks(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[13] == -1) return; // if car unlocks block does not exist
            if (*(uint*) (bytePtrT + partOffsets[13]) != CareerInfo.CAR_UNLOCKS_BLOCK)
                return; // check car unlocks block ID

            var size = *(int*) (bytePtrT + partOffsets[13] + 4) / 0xC;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[13] + a1 * 0xC + 8;
                var carUnlock = new GCarUnlock(bytePtrT + ptrHeader, db);
                db.GCarUnlocks.Collections.Add(carUnlock);
            }
        }
    }
}