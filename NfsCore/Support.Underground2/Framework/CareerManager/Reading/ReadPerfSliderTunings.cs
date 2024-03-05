using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadPerfSliderTunings(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[9] == -1) return; // if career brands block does not exist
            if (*(uint*) (bytePtrT + partOffsets[9]) != CareerInfo.TUNING_PERF_BLOCK)
                return; // check career brands block ID

            var size = *(int*) (bytePtrT + partOffsets[9] + 4) / 0x18;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[9] + a1 * 0x18 + 8;
                var perfSliderTuning = new PerfSliderTuning(bytePtrT + ptrHeader, db);
                db.PerfSliderTunings.Collections.Add(perfSliderTuning);
            }
        }
    }
}