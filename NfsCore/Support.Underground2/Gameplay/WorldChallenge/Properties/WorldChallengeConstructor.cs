using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldChallenge : NfsUnderground2Collectable
    {
        // Default constructor
        public WorldChallenge()
        {
        }

        // Default constructor: create new world challenge
        public WorldChallenge(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble world challenge
        public unsafe WorldChallenge(byte* ptrHeader, byte* ptrString, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(ptrHeader, ptrString);
        }

        ~WorldChallenge()
        {
        }
    }
}