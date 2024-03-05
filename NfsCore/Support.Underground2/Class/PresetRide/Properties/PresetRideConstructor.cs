using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide : Shared.Class.PresetRide
    {
        // Default constructor
        public PresetRide()
        {
        }

        // Default constructor: create new preset
        public PresetRide(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            Initialize();
            _data = new byte[0x338];
            MODEL = "SUPRA";
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
            Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(IntPtr bytePtrT, string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Initialize();
            _data = new byte[0x338];
            Exists = true;
            Disassemble((byte*) bytePtrT);
            Modified = false;
        }

        // Default destructor
        ~PresetRide()
        {
        }
    }
}