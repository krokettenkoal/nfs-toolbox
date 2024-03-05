using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerStage : NfsUnderground2Collectable
    {
        // Default constructor
        public GCareerStage()
        {
        }

        // Default constructor: create new career stage
        public GCareerStage(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble career stage
        public unsafe GCareerStage(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~GCareerStage()
        {
        }
    }
}