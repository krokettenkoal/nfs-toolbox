using System;
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
        private byte _log2Width;
        private byte _log2Height;
        private byte _mipmaps;
        private byte _mipmapBiasType;
        private byte _tileableUv;
        protected byte PalComp = 0;
        protected bool SecretP8 = false; // true of _compression = 0x81 at disassembly

        /// <summary>
        /// Parent TPK of the texture.
        /// </summary>
        protected string ParentTpkName;

        /// <summary>
        /// Header location offset in the Global data.
        /// </summary>
        protected int HeaderLocationOffset = 0;

        /// <summary>
        /// Size of the header in the Global data.
        /// </summary>
        protected int HeaderBlockSize = 0;

        protected virtual byte CompressionId { get; set; } = EAComp.DXT5_08;

        #endregion

        #region Main Properties

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
                _log2Width = (byte) Math.Log(value, 2);
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
                _log2Height = (byte) Math.Log(value, 2);
            }
        }

        /// <summary>
        /// Represents base 2 value of the width of the texture.
        /// </summary>
        public byte Log2Width
        {
            get
            {
                var b1 = _log2Width;
                var b2 = (byte) Math.Log(_width, 2);
                if (b1 == b2)
                    return b1;

                _log2Width = b2;
                return b2;
            }
            protected set => _log2Width = value;
        }

        /// <summary>
        /// Represents base 2 value of the height of the texture.
        /// </summary>
        public byte Log2Height
        {
            get
            {
                var b1 = _log2Height;
                var b2 = (byte) Math.Log(_height, 2);
                if (b1 == b2)
                    return b1;

                _log2Height = b2;
                return b2;
            }
            protected set => _log2Height = value;
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
            get => _mipmapBiasType;
            set
            {
                if (Enum.IsDefined(typeof(eTextureMipmapBiasType), (int) value))
                    _mipmapBiasType = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Value passed falls out of range of possible values.");
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
        protected override void ValidateCollectionName(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName), "This value cannot be left empty.");
            if (collectionName.Contains(' '))
                throw new Exception("CollectionName cannot contain whitespace.");
            var tpk = Database.TPKBlocks.FindCollection(ParentTpkName);
            var key = Bin.Hash(collectionName);
            const eKeyType type = eKeyType.BINKEY;
            if (tpk.GetTextureIndex(key, type) != -1)
                throw new CollectionExistenceException();
        }

        /// <summary>
        /// Represents tileable level of the texture.
        /// </summary>
        [AccessModifiable]
        public byte TileableUV
        {
            get => _tileableUv;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be in range 0 to 3.");
                _tileableUv = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk texture header data.</param>
        /// <param name="offHeader">Current offset in the tpk texture header data.</param>
        /// <param name="offData">Current offset in the tpk data.</param>
        public virtual unsafe void Assemble(byte* bytePtrT, ref int offHeader, ref int offData)
        {
        }

        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the texture header array.</param>
        protected virtual unsafe void Disassemble(byte* bytePtrT)
        {
        }

        /// <summary>
        /// Gets .dds texture data along with the .dds header.
        /// </summary>
        /// <returns>.dds texture as a byte array.</returns>
        public virtual byte[] GetDDSArray()
        {
            return null;
        }

        /// <summary>
        /// Initializes all properties of the new texture.
        /// </summary>
        /// <param name="filename">Filename of the .dds texture passed.</param>
        protected virtual void Initialize(string filename)
        {
        }

        /// <summary>
        /// Reads .dds data from the tpk block.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block.</param>
        /// <param name="offset">Data offset from where to read.</param>
        /// <param name="forced">If forced, ignores internal offset and reads data 
        /// starting at the pointer passed.</param>
        public virtual unsafe void ReadData(byte* bytePtrT, int offset, bool forced)
        {
        }

        /// <summary>
        /// Reloads texture properties based on the new texture passed.
        /// </summary>
        /// <param name="filename">Filename of .dds texture passed.</param>
        public virtual void Reload(string filename)
        {
            Initialize(filename);
        }

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}