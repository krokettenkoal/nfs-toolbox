using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadGCareerBrands(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[3] == -1) return; // if career brands block does not exist
            if (*(uint*) (bytePtrT + partOffsets[3]) != CareerInfo.BRAND_BLOCK)
                return; // check career brands block ID

            var size = *(int*) (bytePtrT + partOffsets[3] + 4) / 0x44;

            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[3] + a1 * 0x44 + 8;
                var careerBrand = new GCareerBrand(bytePtrT + ptrHeader, db);
                db.GCareerBrands.Collections.Add(careerBrand);
            }
        }
    }
}