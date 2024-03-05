using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Sponsor : NfsUnderground2Collectable
    {
        // Default constructor
        public Sponsor()
        {
        }

        // Default constructor: create new sponsor
        public Sponsor(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble sponsor
        public unsafe Sponsor(byte* ptrHeader, byte* ptrString, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(ptrHeader, ptrString);
        }

        ~Sponsor()
        {
        }
    }
}