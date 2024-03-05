using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GShowcase : NfsUnderground2Collectable
    {
        // Default constructor
        public GShowcase()
        {
        }

        // Default constructor: create new showcase
        public GShowcase(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble showcase
        public unsafe GShowcase(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~GShowcase()
        {
        }
    }
}