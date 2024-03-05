using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteWorldChallenges(MemoryWriter mw, Database.Underground2Db db)
        {
            var result = new byte[8 + db.WorldChallenges.Length * 0x18];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.WORLD_CHAL_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var challenge in db.WorldChallenges.Collections)
                {
                    challenge.Assemble(bytePtrT + offset, mw);
                    offset += 0x18;
                }
            }

            return result;
        }
    }
}