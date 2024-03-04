using GlobalLib.Utils;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture : Shared.Class.Texture
    {
        public Texture() { }

        // Default constructor: create new texture for memory cast
        public Texture(string CName, string _TPK, Database.Carbon db)
        {
            Database = db;
            _collectionName = CName;
            _parent_TPK = _TPK;
            BinKey = Bin.Hash(CName);
            PaletteOffset = -1;
            _padding = 0;
        }

        // Default constructor: create new texture from file.
        public Texture(string CName, string _TPK, string filename, Database.Carbon db)
        {
            Database = db;
            _collectionName = CName;
            _parent_TPK = _TPK;
            BinKey = Bin.Hash(CName);
            PaletteOffset = -1;
            _padding = 0;
            Initialize(filename);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* byteptr_t, int offset, int size, string _TPK, Database.Carbon db)
        {
            Database = db;
            _located_at = offset;
            _size_of_block = size;
            _parent_TPK = _TPK;
            PaletteOffset = -1;
            _padding = 0;
            Disassemble(byteptr_t + _located_at);
        }

        // Default constructor: disassemble texture
        public unsafe Texture(byte* byteptr_t, uint offset, uint size, string _TPK, Database.Carbon db)
        {
            Database = db;
            _located_at = (int)offset;
            _size_of_block = (int)size;
            _parent_TPK = _TPK;
            PaletteOffset = -1;
            _padding = 0;
            Disassemble(byteptr_t + _located_at);
        }

        ~Texture() { }
    }
}