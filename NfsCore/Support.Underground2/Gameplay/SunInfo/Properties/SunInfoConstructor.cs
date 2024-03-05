using System;
using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Support.Underground2.Parts.GameParts;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class SunInfo : NfsUnderground2Collectable
    {
        // Default constructor
        public SunInfo()
        {
        }

        // Default constructor: create new suninfo
        public SunInfo(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            SUNLAYER1 = new SunLayer();
            SUNLAYER2 = new SunLayer();
            SUNLAYER3 = new SunLayer();
            SUNLAYER4 = new SunLayer();
            SUNLAYER5 = new SunLayer();
            SUNLAYER6 = new SunLayer();
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble suninfo
        public unsafe SunInfo(IntPtr bytePtrT, string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            SUNLAYER1 = new SunLayer();
            SUNLAYER2 = new SunLayer();
            SUNLAYER3 = new SunLayer();
            SUNLAYER4 = new SunLayer();
            SUNLAYER5 = new SunLayer();
            SUNLAYER6 = new SunLayer();
            Disassemble((byte*) bytePtrT);
        }

        ~SunInfo()
        {
        }
    }
}