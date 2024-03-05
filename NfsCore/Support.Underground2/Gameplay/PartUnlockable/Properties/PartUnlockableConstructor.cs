using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartUnlockable : NfsUnderground2Collectable
    {
        // Default constructor
        public PartUnlockable()
        {
        }

        // Default constructor: create new part unlockable
        public PartUnlockable(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble part unlockable
        public unsafe PartUnlockable(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~PartUnlockable()
        {
        }
    }
}