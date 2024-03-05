using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldShop : NfsUnderground2Collectable
    {
        // Default constructor
        public WorldShop()
        {
        }

        // Default constructor: create new world shop
        public WorldShop(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble world shop
        public unsafe WorldShop(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~WorldShop()
        {
        }
    }
}