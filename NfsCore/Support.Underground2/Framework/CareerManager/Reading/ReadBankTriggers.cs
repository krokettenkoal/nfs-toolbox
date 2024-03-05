using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadBankTriggers(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[12] == -1) return; // if bank trigger block does not exist
            if (*(uint*) (bytePtrT + partOffsets[12]) != CareerInfo.BANK_TRIGS_BLOCK)
                return; // check bank trigger block ID

            var size = *(int*) (bytePtrT + partOffsets[12] + 4) / 0xC;

            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrHeader = partOffsets[12] + a1 * 0xC + 8;
                var bankTrigger = new BankTrigger(bytePtrT + ptrHeader, db);
                db.BankTriggers.Collections.Add(bankTrigger);
            }
        }
    }
}