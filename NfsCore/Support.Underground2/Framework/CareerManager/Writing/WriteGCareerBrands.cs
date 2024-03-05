using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteGCareerBrands(MemoryWriter mw, Database.Underground2Db db)
        {
            var result = new byte[8 + db.GCareerBrands.Length * 0x44];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.BRAND_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var brand in db.GCareerBrands.Collections)
                {
                    brand.Assemble(bytePtrT + offset, mw);
                    offset += 0x44;
                }
            }

            return result;
        }
    }
}