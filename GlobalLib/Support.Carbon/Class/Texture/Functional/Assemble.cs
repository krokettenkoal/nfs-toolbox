namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk texture header data.</param>
        /// <param name="offheader">Current offset in the tpk texture header data.</param>
        /// <param name="offdata">Current offset in the tpk data.</param>
        public override unsafe void Assemble(byte* byteptr_t, ref int offheader, ref int offdata)
        {
            var a1 = _collectionName.Length > 0x22 ? 0x22 : _collectionName.Length;
            var a2 = 0x5D + a1 - ((1 + a1) % 4); // size of the texture header

            Offset = offdata;

            // Write all settings
            *(uint*)(byteptr_t + offheader) = _cube_environment;
            *(uint*)(byteptr_t + offheader + 0xC) = BinKey;
            *(uint*)(byteptr_t + offheader + 0x10) = _class;
            *(uint*)(byteptr_t + offheader + 0x14) = (uint)Offset;
            *(uint*)(byteptr_t + offheader + 0x18) = (uint)PaletteOffset;
            *(int*)(byteptr_t + offheader + 0x1C) = Size;
            *(int*)(byteptr_t + offheader + 0x20) = PaletteSize;
            *(int*)(byteptr_t + offheader + 0x24) = _area;
            *(short*)(byteptr_t + offheader + 0x28) = Width;
            *(short*)(byteptr_t + offheader + 0x2A) = Height;
            *(byteptr_t + offheader + 0x2C) = Log_2_Width;
            *(byteptr_t + offheader + 0x2D) = Log_2_Height;
            *(byteptr_t + offheader + 0x2E) = CompressionId;
            *(byteptr_t + offheader + 0x2F) = _pal_comp;
            *(short*)(byteptr_t + offheader + 0x30) = _num_palettes;
            *(byteptr_t + offheader + 0x32) = Mipmaps;
            *(byteptr_t + offheader + 0x33) = TileableUV;
            *(byteptr_t + offheader + 0x34) = _bias_level;
            *(byteptr_t + offheader + 0x35) = _rendering_order;
            *(byteptr_t + offheader + 0x36) = _scroll_type;
            *(byteptr_t + offheader + 0x37) = _used_flag;
            *(byteptr_t + offheader + 0x38) = _apply_alpha_sort;
            *(byteptr_t + offheader + 0x39) = _alpha_usage_type;
            *(byteptr_t + offheader + 0x3A) = _alpha_blend_type;
            *(byteptr_t + offheader + 0x3B) = _flags;
            *(byteptr_t + offheader + 0x3C) = MipmapBiasType;
            *(byteptr_t + offheader + 0x3D) = _padding;
            *(short*)(byteptr_t + offheader + 0x3E) = _scroll_timestep;
            *(short*)(byteptr_t + offheader + 0x40) = _scroll_speedS;
            *(short*)(byteptr_t + offheader + 0x42) = _scroll_speedT;
            *(short*)(byteptr_t + offheader + 0x44) = _offsetS;
            *(short*)(byteptr_t + offheader + 0x46) = _offsetT;
            *(short*)(byteptr_t + offheader + 0x48) = _scaleS;
            *(short*)(byteptr_t + offheader + 0x4A) = _scaleT;
            *(int*)(byteptr_t + offheader + 0x4C) = _unknown1;
            *(int*)(byteptr_t + offheader + 0x50) = _unknown2;
            *(int*)(byteptr_t + offheader + 0x54) = _unknown3;
            *(byteptr_t + offheader + 0x58) = (byte)(a2 - 0x59);

            // Write CollectionName
            for (var a3 = 0; a3 < a1; ++a3)
                *(byteptr_t + offheader + 0x59 + a3) = (byte)CollectionName[a3];

            // Precalculate next offsets
            offheader += a2; // set next header offset
            offdata = (int)Offset + Size; // set next data offset
            a1 = 0x80 - (offdata % 0x80);
            if (a1 != 0x80)
                offdata += a1;
        }
    }
}