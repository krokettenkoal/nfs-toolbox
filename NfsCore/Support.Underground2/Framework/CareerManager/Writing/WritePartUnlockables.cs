using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WritePartUnlockables(Database.Underground2Db db)
        {
            var result = new byte[8 + db.PartUnlockables.Length * 0x28];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.PART_UNLOCKS_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var part in db.PartUnlockables.Collections)
                {
                    part.Assemble(bytePtrT + offset);
                    offset += 0x28;
                }
            }

            return result;
        }
    }
}