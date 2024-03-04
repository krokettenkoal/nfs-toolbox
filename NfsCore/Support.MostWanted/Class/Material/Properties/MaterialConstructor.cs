using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material : Shared.Class.Material
    {
        // Default constructor
        public Material() { }

        // Default constructor: create new material
        public Material(string CName, Database.MostWantedDb db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble material
        public unsafe Material(System.IntPtr byteptr_t, string CName, Database.MostWantedDb db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        ~Material() { }
    }
}