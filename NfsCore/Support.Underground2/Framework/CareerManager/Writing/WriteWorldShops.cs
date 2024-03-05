using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteWorldShops(MemoryWriter mw, Database.Underground2Db db)
        {
            var result = new byte[8 + db.WorldShops.Length * 0xA0];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.SHOP_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var shop in db.WorldShops.Collections)
                {
                    shop.Assemble(bytePtrT + offset, mw);
                    offset += 0xA0;
                }
            }

            return result;
        }
    }
}