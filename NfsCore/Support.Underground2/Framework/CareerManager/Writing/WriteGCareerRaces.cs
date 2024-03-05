using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteGCareerRaces(MemoryWriter mw, Database.Underground2Db db)
        {
            var result = new byte[8 + db.GCareerRaces.Length * 0x88];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.EVENT_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var race in db.GCareerRaces.Collections)
                {
                    race.Assemble(bytePtrT + offset, mw);
                    offset += 0x88;
                }
            }

            return result;
        }
    }
}