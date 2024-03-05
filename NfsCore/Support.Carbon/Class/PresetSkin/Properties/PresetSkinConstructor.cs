using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin
    {
        // Default constructor
        public PresetSkin()
        {
        }

        // Default constructor: create new skin
        public PresetSkin(string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble skin
        public unsafe PresetSkin(IntPtr bytePtrT, string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollName = collectionName;
            Disassemble((byte*) bytePtrT);
        }

        // Default destructor
        ~PresetSkin()
        {
        }
    }
}