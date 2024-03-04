using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material
    {
        // Default constructor
        public Material() { }

        // Default constructor: create new material
        public Material(string CName, Database.CarbonDb db)
        {
            Database = db;
            CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble material
        public unsafe Material(IntPtr byteptr_t, string CName, Database.CarbonDb db)
        {
            Database = db;
            CollectionName = CName;
            Disassemble((byte*)byteptr_t);
        }

        ~Material() { }
    }
}