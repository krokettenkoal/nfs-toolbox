using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material : Shared.Class.Material
    {
        // Default constructor
        public Material()
        {
        }

        // Default constructor: create new material
        public Material(string collectionName, Database.MostWantedDb db)
        {
            Database = db;
            CollectionName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble material
        public unsafe Material(System.IntPtr bytePtrT, string collectionName, Database.MostWantedDb db)
        {
            Database = db;
            CollName = collectionName;
            Disassemble((byte*) bytePtrT);
        }

        ~Material()
        {
        }
    }
}