using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadWorldChallenges(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[10] == -1) return; // if world challenges block does not exist
            if (*(uint*) (bytePtrT + partOffsets[10]) != CareerInfo.WORLD_CHAL_BLOCK)
                return; // check world challenges block ID

            var size = *(int*) (bytePtrT + partOffsets[10] + 4) / 0x18;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrString = partOffsets[0] + 8;
                var ptrHeader = partOffsets[10] + a1 * 0x18 + 8;
                var worldChallenge = new WorldChallenge(bytePtrT + ptrHeader, bytePtrT + ptrString, db);
                db.WorldChallenges.Collections.Add(worldChallenge);
            }
        }
    }
}