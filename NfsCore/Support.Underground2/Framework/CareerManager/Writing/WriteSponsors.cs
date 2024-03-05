using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteSponsors(MemoryWriter mw, Database.Underground2Db db)
        {
            var result = new byte[8 + db.Sponsors.Length * 0x10];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.SPONSOR_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var sponsor in db.Sponsors.Collections)
                {
                    sponsor.Assemble(bytePtrT + offset, mw);
                    offset += 0x10;
                }
            }

            return result;
        }
    }
}