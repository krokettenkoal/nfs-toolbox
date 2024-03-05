using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Texture : Shared.Class.Texture
    {
        public Texture()
        {
            _flags = 0;
        }

        // Default constructor: create new texture for memory cast
        public Texture(string collectionName, string parentTpk, Database.CarbonDb db)
        {
            _flags = 0;
            Database = db;
            CollName = collectionName;
            ParentTpkName = parentTpk;
            _binKey = Bin.Hash(collectionName);
            PaletteOffset = -1;
            _padding = 0;
        }

        // Default constructor: create new texture from file.
        public Texture(string collectionName, string parentTpk, string filename, Database.CarbonDb db)
        {
            _flags = 0;
            Database = db;
            CollName = collectionName;
            ParentTpkName = parentTpk;
            _binKey = Bin.Hash(collectionName);
            PaletteOffset = -1;
            _padding = 0;
            Initialize(filename);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* bytePtrT, int offset, int size, string parentTpk, Database.CarbonDb db)
        {
            _flags = 0;
            Database = db;
            HeaderLocationOffset = offset;
            HeaderBlockSize = size;
            ParentTpkName = parentTpk;
            PaletteOffset = -1;
            _padding = 0;
            Disassemble(bytePtrT + HeaderLocationOffset);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* bytePtrT, uint offset, uint size, string parentTpk, Database.CarbonDb db)
        {
            _flags = 0;
            Database = db;
            HeaderLocationOffset = (int) offset;
            HeaderBlockSize = (int) size;
            ParentTpkName = parentTpk;
            PaletteOffset = -1;
            _padding = 0;
            Disassemble(bytePtrT + HeaderLocationOffset);
        }

        ~Texture()
        {
        }
    }
}