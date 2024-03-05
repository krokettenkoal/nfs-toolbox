using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadPartPerformances(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[4] == -1) return; // if part perf block does not exist
            if (*(uint*) (bytePtrT + partOffsets[4]) != CareerInfo.PERF_PACK_BLOCK)
                return; // check part perf block ID

            var size = *(int*) (bytePtrT + partOffsets[4] + 4) / 0x17C;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var offsetPtr = bytePtrT + partOffsets[4] + a1 * 0x17C + 8;
                var index = *(int*) (offsetPtr);
                var level = *(int*) (offsetPtr + 4) - 1;
                var total = *(int*) (offsetPtr + 8);

                for (var a2 = 0; a2 < total; ++a2)
                {
                    var ptrHeader = 12 + a2 * 0x5C;
                    var partPerformance = new PartPerformance(offsetPtr + ptrHeader, db, index, level, a2);
                    db.PartPerformances.Collections.Add(partPerformance);
                }
            }
        }
    }
}