using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerBrand : NfsUnderground2Collectable
    {
        // Default constructor
        public GCareerBrand()
        {
        }

        // Default constructor: create new career brand
        public GCareerBrand(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble career brand
        public unsafe GCareerBrand(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~GCareerBrand()
        {
        }
    }
}