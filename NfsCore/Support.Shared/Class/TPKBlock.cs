using System;
using System.Collections.Generic;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Shared.Parts.TPKParts;

namespace NfsCore.Support.Shared.Class
{
    public abstract class TPKBlock : Collectable
    {
        #region Private Fields

        protected int Version { get; set; } = 8; // 8 for C, 5 for MW and UG2
        protected string FileName { get; set; } // 0x40 bytes max
        protected uint FilenameHash { get; set; } // Bin.Hash(this.filename)
        protected uint PermBlockByteOffset { get; set; } = 0; // usually 0
        protected uint PermBlockByteSize { get; set; } = 0; // usually 0
        protected int EndianSwapped { get; set; } = 0; // usually 0
        protected int TexturePack { get; set; } = 0; // usually 0
        protected int TextureIndexEntryTable { get; set; } = 0; // usually 0
        protected int TextureStreamEntryTable { get; set; } = 0; // usually 0

        #endregion

        #region Main Properties

        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.None;

        /// <summary>
        /// Index of the TPK in the Global data.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// True if this tpk is in GlobalA file.
        /// </summary>
        public bool InGlobalA { get; set; }

        #endregion

        #region Internal properties

        /// <summary>
        /// The list of all <see cref="Texture"/>s in the <see cref="TPKBlock"/>.
        /// </summary>
        public List<Texture> Textures { get; } = new();

        #endregion
        
        #region Internal Methods

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sorts <see cref="Texture"/> by their CollectionNames or BinKeys.
        /// </summary>
        /// <param name="byName">True if sort by name; false is sort by hash.</param>
        public virtual void SortTexturesByType(bool byName) { }

        /// <summary>
        /// Assembles <see cref="TPKBlock"/> into a byte array.
        /// </summary>
        /// <returns>Byte array of the tpk block.</returns>
        public virtual byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles <see cref="TPKBlock"/> array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        protected virtual unsafe void Disassemble(byte* bytePtrT) { }

        /// <summary>
        /// Tries to find <see cref="Texture"/> based on the key passed.
        /// </summary>
        /// <param name="key">Key of the <see cref="Texture"/> Collection Name.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <returns>Texture if it is found; null otherwise.</returns>
        public virtual Texture FindTexture(uint key, eKeyType type) { return null; }

        /// <summary>
        /// Gets index of the <see cref="Texture"/> in the <see cref="TPKBlock"/>.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/>.</param>
        /// <param name="type">Key type passed.</param>
        /// <returns>Index number as an integer. If element does not exist, returns -1.</returns>
        public virtual int GetTextureIndex(uint key, eKeyType type) { return -1; }

        /// <summary>
        /// Attempts to add <see cref="Texture"/> to the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="collectionName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="fileName">Path of the texture to be imported.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public virtual bool TryAddTexture(string collectionName, string fileName) { return false; }

        /// <summary>
        /// Attempts to add <see cref="Texture"/> to the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="collectionName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="fileName">Path of the texture to be imported.</param>
        /// <param name="error">Error occured when trying to add a texture.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public virtual bool TryAddTexture(string collectionName, string fileName, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attempts to remove <see cref="Texture"/> specified from <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to be deleted.</param>
        /// <param name="type">Type fo the key passed.</param>
        /// <returns>True if texture removing was successful, false otherwise.</returns>
        public virtual bool TryRemoveTexture(uint key, eKeyType type) { return false; }

        /// <summary>
        /// Attempts to remove <see cref="Texture"/> specified from <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to be deleted.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="error">Error occured when trying to remove a texture.</param>
        /// <returns>True if texture removing was successful, false otherwise.</returns>
        public virtual bool TryRemoveTexture(uint key, eKeyType type, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attempts to clone <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="newName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to clone.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <returns>True if texture cloning was successful, false otherwise.</returns>
        public virtual bool TryCloneTexture(string newName, uint key, eKeyType type) { return false; }

        /// <summary>
        /// Attempts to clone <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="newName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to clone.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="error">Error occured when trying to clone a texture.</param>
        /// <returns>True if texture cloning was successful, false otherwise.</returns>
        public virtual bool TryCloneTexture(string newName, uint key, eKeyType type, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attemps to replace <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data with a new one.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to be replaced.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="fileName">Path of the texture that replaces the current one.</param>
        /// <returns>True if texture replacing was successful, false otherwise.</returns>
        public virtual bool TryReplaceTexture(uint key, eKeyType type, string fileName) { return false; }

        /// <summary>
        /// Attemps to replace <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data with a new one.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to be replaced.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="fileName">Path of the texture that replaces the current one.</param>
        /// <param name="error">Error occured when trying to replace a texture.</param>
        /// <returns>True if texture replacing was successful, false otherwise.</returns>
        public virtual bool TryReplaceTexture(uint key, eKeyType type, string fileName, out string error)
        {
            error = null;
            return false;
        }

        #endregion

        #region Reading Methods

        /// <summary>
        /// Finds offsets of all partials and its parts in the tpk block.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <returns>Array of all offsets.</returns>
        protected virtual unsafe int[] FindOffsets(byte* bytePtrT) { return null; }

        /// <summary>
        /// Gets amount of textures in the tpk block.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        /// <returns>Number of textures in the tpk block.</returns>
        protected virtual unsafe int GetTextureCount(byte* bytePtrT, int offset) { return 0; }

        /// <summary>
        /// Gets tpk header information.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part1 offset in the tpk block array.</param>
        protected virtual unsafe void GetHeaderInfo(byte* bytePtrT, int offset) { }

        /// <summary>
        /// Gets list of keys of the textures in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        protected virtual unsafe void GetKeyList(byte* bytePtrT, int offset) { }

        /// <summary>
        /// Gets list of offset slots of the textures in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part3 offset in the tpk block array.</param>
        protected virtual unsafe void GetOffsetSlots(byte* bytePtrT, int offset) { }

        /// <summary>
        /// Gets list of compressions of the textures in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part5 offset in the tpk block array.</param>
        protected virtual unsafe void GetCompressionList(byte* bytePtrT, int offset) { }

        /// <summary>
        /// Gets list of offsets and sizes of the texture headers in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part4 offset in the tpk block array.</param>
        /// <returns>Array of offsets and sizes of texture headers.</returns>
        protected virtual unsafe int[,] GetTextureHeaders(byte* bytePtrT, int offset) { return null; }

        /// <summary>
        /// Parses compressed texture and returns it on the output.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offSlot">Off-slot of the texture to be parsed</param>
        /// <returns>Decompressed texture valid to the current support.</returns>
        protected virtual unsafe void ParseCompTexture(byte* bytePtrT, OffSlot offSlot) { }

        #endregion

        #region Writing Methods

        /// <summary>
        /// Sorts textures by their binary memory hashes.
        /// </summary>
        protected virtual void TextureSort() { }

        /// <summary>
        /// Checks texture keys and tpk keys for matching.
        /// </summary>
        protected virtual void CheckKeys() { }

        /// <summary>
        /// Checks texture compressions and tpk compressions for matching.
        /// </summary>
        protected virtual void CheckComps() { }

        /// <summary>
        /// Assembles partial 1 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part1.</returns>
        protected virtual byte[] Get1Part1() { return null; }

        /// <summary>
        /// Assembles partial 1 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part2.</returns>
        protected virtual byte[] Get1Part2() { return null; }

        /// <summary>
        /// Assembles partial 1 part4 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part4.</returns>
        protected virtual byte[] Get1Part4() { return null; }

        /// <summary>
        /// Assembles partial 1 part5 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part5.</returns>
        protected virtual byte[] Get1Part5() { return null; }

        /// <summary>
        /// Assembles partial 2 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part1.</returns>
        protected virtual byte[] Get2Part1() { return null; }

        /// <summary>
        /// Assembles partial 2 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part2.</returns>
        protected virtual byte[] Get2Part2() { return null; }

        #endregion
    }
}