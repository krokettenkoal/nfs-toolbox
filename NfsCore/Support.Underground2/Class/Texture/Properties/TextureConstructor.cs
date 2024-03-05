using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Texture : Shared.Class.Texture
    {
        public Texture()
        {
        }

        // Default constructor: create new texture for memory cast
        public Texture(string collectionName, string parentTpk, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            ParentTpkName = parentTpk;
            _binKey = Bin.Hash(collectionName);
            PaletteOffset = 0;
            _padding = 1;
        }

        // Default constructor: create new texture from file.
        public Texture(string collectionName, string parentTpk, string filename, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            ParentTpkName = parentTpk;
            _binKey = Bin.Hash(collectionName);
            PaletteOffset = 0;
            _padding = 1;
            Initialize(filename);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* bytePtrT, int offset, int size, string parentTpk, Database.Underground2Db db)
        {
            Database = db;
            HeaderLocationOffset = offset;
            HeaderBlockSize = size;
            ParentTpkName = parentTpk;
            PaletteOffset = 0;
            _padding = 1;
            Disassemble(bytePtrT + HeaderLocationOffset);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* bytePtrT, uint offset, uint size, string parentTpk, Database.Underground2Db db)
        {
            Database = db;
            HeaderLocationOffset = (int) offset;
            HeaderBlockSize = (int) size;
            ParentTpkName = parentTpk;
            PaletteOffset = 0;
            _padding = 1;
            Disassemble(bytePtrT + HeaderLocationOffset);
        }

        ~Texture()
        {
        }
    }
}