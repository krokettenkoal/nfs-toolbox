using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Support.Underground2.Parts.GameParts;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace : NfsUnderground2Collectable
    {
        // Default constructor
        public GCareerRace()
        {
        }

        // Default constructor: create new career race
        public GCareerRace(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            OPPONENT1 = new Opponent();
            OPPONENT2 = new Opponent();
            OPPONENT3 = new Opponent();
            OPPONENT4 = new Opponent();
            OPPONENT5 = new Opponent();
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble career race
        public unsafe GCareerRace(byte* ptrHeader, byte* ptrString, Database.Underground2Db db)
        {
            Database = db;
            OPPONENT1 = new Opponent();
            OPPONENT2 = new Opponent();
            OPPONENT3 = new Opponent();
            OPPONENT4 = new Opponent();
            OPPONENT5 = new Opponent();
            Disassemble(ptrHeader, ptrString);
        }
    }
}