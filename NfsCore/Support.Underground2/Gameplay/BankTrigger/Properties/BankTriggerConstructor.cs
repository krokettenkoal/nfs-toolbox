using System.Linq;
using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class BankTrigger : NfsUnderground2Collectable
    {
        // Default constructor
        public BankTrigger()
        {
        }

        // Default constructor: create new bank trigger
        public BankTrigger(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            byte maxIndex = 0;
            foreach (var bank in db.BankTriggers.Collections.Where(bank => bank.BankIndex > maxIndex))
                maxIndex = bank.BankIndex;
            BankIndex = (byte) (maxIndex + 1);
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble bank trigger
        public unsafe BankTrigger(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~BankTrigger()
        {
        }
    }
}