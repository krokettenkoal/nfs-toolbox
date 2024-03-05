using System;
using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track : NfsUnderground2Collectable
    {
        // Default constructor
        public Track()
        {
        }

        // Default constructor: create new track
        public Track(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            RegionName = "L4RA";
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble track
        public unsafe Track(IntPtr bytePtrT, string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Disassemble((byte*) bytePtrT);
        }

        ~Track()
        {
        }
    }
}