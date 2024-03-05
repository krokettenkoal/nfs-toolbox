using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadGShowcases(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[5] == -1) return; // if showcases block does not exist
            if (*(uint*) (bytePtrT + partOffsets[5]) != CareerInfo.SHOWCASE_BLOCK)
                return; // check showcases block ID

            var size = *(int*) (bytePtrT + partOffsets[5] + 4) / 0x40;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[5] + a1 * 0x40 + 8;
                var showcase = new GShowcase(bytePtrT + ptrHeader, db);
                db.GShowcases.Collections.Add(showcase);
            }
        }
    }
}