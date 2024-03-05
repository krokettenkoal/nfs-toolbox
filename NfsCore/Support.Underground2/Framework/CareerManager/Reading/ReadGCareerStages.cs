using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadGCareerStages(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[8] == -1) return; // if career stages block does not exist
            if (*(uint*) (bytePtrT + partOffsets[8]) != CareerInfo.STAGE_BLOCK)
                return; // check career stages block ID

            var size = *(int*) (bytePtrT + partOffsets[8] + 4) / 0x50;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[8] + a1 * 0x50 + 8;
                var careerStage = new GCareerStage(bytePtrT + ptrHeader, db);
                db.GCareerStages.Collections.Add(careerStage);
            }
        }
    }
}