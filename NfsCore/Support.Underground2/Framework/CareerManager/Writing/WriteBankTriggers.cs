using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteBankTriggers(Database.Underground2Db db)
        {
            var result = new byte[8 + db.BankTriggers.Length * 0xC];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.BANK_TRIGS_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var bank in db.BankTriggers.Collections)
                {
                    bank.Assemble(bytePtrT + offset);
                    offset += 0xC;
                }
            }

            return result;
        }
    }
}