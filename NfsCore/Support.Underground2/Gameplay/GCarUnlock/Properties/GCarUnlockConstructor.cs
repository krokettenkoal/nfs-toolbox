using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCarUnlock : NfsUnderground2Collectable
    {
        // Default constructor
        public GCarUnlock()
        {
        }

        // Default constructor: create new car unlock
        public GCarUnlock(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble car unlock
        public unsafe GCarUnlock(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~GCarUnlock()
        {
        }
    }
}