using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadGCareerRaces(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[1] == -1) return; // if career races block does not exist
            if (*(uint*) (bytePtrT + partOffsets[1]) != CareerInfo.EVENT_BLOCK)
                return; // check career races block ID

            var size = *(int*) (bytePtrT + partOffsets[1] + 4) / 0x88;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrString = partOffsets[0] + 8;
                var ptrHeader = partOffsets[1] + a1 * 0x88 + 8;
                var careerRace = new GCareerRace(bytePtrT + ptrHeader, bytePtrT + ptrString, db);
                db.GCareerRaces.Collections.Add(careerRace);
            }
        }
    }
}