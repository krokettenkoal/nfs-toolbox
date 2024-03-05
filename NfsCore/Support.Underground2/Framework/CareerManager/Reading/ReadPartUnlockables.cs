using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadPartUnlockables(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[11] == -1) return; // if part unlocks block does not exist
            if (*(uint*) (bytePtrT + partOffsets[11]) != CareerInfo.PART_UNLOCKS_BLOCK)
                return; // check part unlocks block ID

            var size = *(int*) (bytePtrT + partOffsets[11] + 4) / 0x28;

            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[11] + a1 * 0x28 + 8;
                var partUnlockable = new PartUnlockable(bytePtrT + ptrHeader, db);
                db.PartUnlockables.Collections.Add(partUnlockable);
            }
        }
    }
}