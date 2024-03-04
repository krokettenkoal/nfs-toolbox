using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin
    {
        // Default constructor
        public PresetSkin() { }

        // Default constructor: create new skin
        public PresetSkin(string CName, Database.CarbonDb db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble skin
        public unsafe PresetSkin(IntPtr byteptr_t, string CName, Database.CarbonDb db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        // Default destructor
        ~PresetSkin() { }
    }
}