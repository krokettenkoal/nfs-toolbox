using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadSponsors(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[7] == -1) return; // if sponsors block does not exist
            if (*(uint*) (bytePtrT + partOffsets[7]) != CareerInfo.SPONSOR_BLOCK)
                return; // check sponsors block ID

            var size = *(int*) (bytePtrT + partOffsets[7] + 4) / 0x10;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrString = partOffsets[0] + 8;
                var ptrHeader = partOffsets[7] + a1 * 0x10 + 8;
                var sponsor = new Sponsor(bytePtrT + ptrHeader, bytePtrT + ptrString, db);
                db.Sponsors.Collections.Add(sponsor);
            }
        }
    }
}