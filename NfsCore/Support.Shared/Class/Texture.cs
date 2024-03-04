using System;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.ID;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Shared.Class
{
    public class Texture : Collectable
    {
        #region Private Fields

        private short _width;
        private short _height;
        private byte _log_2_width;
        private byte _log_2_height;
        private byte _mipmaps;
        private byte _mipmap_bias_type;
        private byte _tileableuv;
        protected string _collectionName;
        protected byte _pal_comp = 0;
        protected bool _secretp8 = false; // true of _compression = 0x81 at disassembly
        
        /// <summary>
        /// Parent TPK of the texture.
        /// </summary>
        protected string _parent_TPK;
        
        /// <summary>
        /// Header location offset in the Global data.
        /// </summary>
        protected int _located_at = 0;

        /// <summary>
        /// Size of the header in the Global data.
        /// </summary>
        protected int _size_of_block = 0;
        
        protected virtual byte CompressionId { get; set; } = EAComp.DXT5_08;

        #endregion

        #region Main Properties

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public uint BinKey { get; internal set; }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey => Vlt.Hash(CollectionName);

        /// <summary>
        /// Represents data offset of the block in Global data.
        /// </summary>
        public int Offset { get; protected set; } = 0;

        /// <summary>
        /// Represents data size of the block in Global data.
        /// </summary>
        public int Size { get; protected set; } = 0;

        /// <summary>
        /// Represents palette offset of the block in Global data.
        /// </summary>
        public int PaletteOffset { get; protected set; } = 0;

        /// <summary>
        /// Represents palette size of the block in Global data.
        /// </summary>
        public int PaletteSize { get; protected set; } = 0;

        #endregion

        #region Public Properties
        
        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public virtual BasicBase Database { get; }
        
        /// <summary>
        /// DDS data of the texture.
        /// </summary>
        public byte[] Data { get; protected set; }

        /// <summary>
        /// Gets compression type of the texture.
        /// </summary>
        /// <returns>Compression type as a string.</returns>
        public string Compression
        {
            get => Comp.GetString(CompressionId);
            internal set => CompressionId = Comp.GetByte(value);
        }

        /// <summary>
        /// Represents height in pixels of the texture.
        /// </summary>
        public short Width
        {
            get => _width;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be a positive value.");
                
                _width = value;
                _log_2_width = (byte)Math.Log(value, 2);
            }
        }

        /// <summary>
        /// Represents height in pixels of the texture.
        /// </summary>
        public short Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be a positive value.");
                
                _height = value;
                _log_2_height = (byte)Math.Log(value, 2);
            }
        }

        /// <summary>
        /// Represents base 2 value of the width of the texture.
        /// </summary>
        public byte Log_2_Width
        {
            get
            {
                var b1 = _log_2_width;
                var b2 = (byte)Math.Log(_width, 2);
                if (b1 == b2)
                    return b1;
                
                _log_2_width = b2;
                return b2;
            }
            protected set => _log_2_width = value;
        }

        /// <summary>
        /// Represents base 2 value of the height of the texture.
        /// </summary>
        public byte Log_2_Height
        {
            get
            {
                var b1 = _log_2_height;
                var b2 = (byte)Math.Log(_height, 2);
                if (b1 == b2)
                    return b1;
                
                _log_2_height = b2;
                return b2;
            }
            protected set => _log_2_height = value;
        }

        /// <summary>
        /// Represents number of mipmaps in the texture.
        /// </summary>
        public byte Mipmaps
        {
            get => _mipmaps;
            set
            {
                if (value > 15)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be in range 0 to 15.");
                
                _mipmaps = value;
            }
        }

        /// <summary>
        /// Represents mipmap bias type of the texture.
        /// </summary>
        public byte MipmapBiasType
        {
            get => _mipmap_bias_type;
            set
            {
                if (Enum.IsDefined(typeof(eTextureMipmapBiasType), (int)value))
                    _mipmap_bias_type = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed falls out of range of possible values.");
            }
        }

        /// <summary>
        /// Used in TPK compression blocks.
        /// </summary>
        public int CompVal1 { get; internal set; } = 1;

        /// <summary>
        /// Used in TPK compression blocks.
        /// </summary>
        public int CompVal2 { get; internal set; } = 5;

        /// <summary>
        /// Used in TPK compression blocks.
        /// </summary>
        public int CompVal3 { get; internal set; } = 6;

        #endregion

        #region AccessModifiable Properties
        
        /// <summary>
        /// Collection name of the texture
        /// </summary>
        [AccessModifiable]
        public override string CollectionName
        {
            get => _collectionName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value.Contains(' '))
                    throw new Exception("CollectionName cannot contain whitespace.");
                var tpk = Database.TPKBlocks.FindCollection(_parent_TPK);
                var key = Bin.Hash(value);
                const eKeyType type = eKeyType.BINKEY;
                if (tpk.GetTextureIndex(key, type) != -1)
                    throw new CollectionExistenceException();
                _collectionName = value;
                BinKey = Bin.Hash(value);
            }
        }

        /// <summary>
        /// Represents tileable level of the texture.
        /// </summary>
        [AccessModifiable()]
        public byte TileableUV
        {
            get => _tileableuv;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException("Value passed should be in range 0 to 3.");
                else
                    _tileableuv = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk texture header data.</param>
        /// <param name="offheader">Current offset in the tpk texture header data.</param>
        /// <param name="offdata">Current offset in the tpk data.</param>
        public virtual unsafe void Assemble(byte* byteptr_t, ref int offheader, ref int offdata) { }

        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the texture header array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Gets .dds texture data along with the .dds header.
        /// </summary>
        /// <returns>.dds texture as a byte array.</returns>
        public virtual unsafe byte[] GetDDSArray() { return null; }

        /// <summary>
        /// Initializes all properties of the new texture.
        /// </summary>
        /// <param name="filename">Filename of the .dds texture passed.</param>
        protected virtual unsafe void Initialize(string filename) { }

        /// <summary>
        /// Reads .dds data from the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block.</param>
        /// <param name="offset">Data offset from where to read.</param>
        /// <param name="forced">If forced, ignores internal offset and reads data 
        /// starting at the pointer passed.</param>
        public virtual unsafe void ReadData(byte* byteptr_t, int offset, bool forced) { }

        /// <summary>
        /// Reloads texture properties based on the new texture passed.
        /// </summary>
        /// <param name="filename">Filename of .dds texture passed.</param>
        public virtual unsafe void Reload(string filename)
        {
            Initialize(filename);
        }

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}