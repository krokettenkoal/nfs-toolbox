using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Class
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
            // Get offset data
            if (CompressionId == EAComp.P8_08)
            {
                PaletteOffset = offdata;
                Offset = offdata + PaletteSize;
            }
            else
                Offset = offdata;

            // Write CollectionName
            var a3 = (_collectionName.Length > 0x17) ? 0x17 : _collectionName.Length;
            for (var a1 = 0; a1 < a3; ++a1)
                *(byteptr_t + offheader + 0xC + a1) = (byte)_collectionName[a1];

            // Write all settings
            *(uint*)(byteptr_t + offheader + 0x24) = BinKey;
            *(uint*)(byteptr_t + offheader + 0x28) = _class;
            *(int*)(byteptr_t + offheader + 0x2C) = _unknown0;
            *(uint*)(byteptr_t + offheader + 0x30) = (uint)Offset;
            *(uint*)(byteptr_t + offheader + 0x34) = (uint)PaletteOffset;
            *(int*)(byteptr_t + offheader + 0x38) = Size;
            *(int*)(byteptr_t + offheader + 0x3C) = PaletteSize;
            *(int*)(byteptr_t + offheader + 0x40) = _area;
            *(short*)(byteptr_t + offheader + 0x44) = Width;
            *(short*)(byteptr_t + offheader + 0x46) = Height;
            *(byteptr_t + offheader + 0x48) = Log_2_Width;
            *(byteptr_t + offheader + 0x49) = Log_2_Height;
            *(byteptr_t + offheader + 0x4A) = CompressionId;
            *(byteptr_t + offheader + 0x4B) = _pal_comp;
            *(short*)(byteptr_t + offheader + 0x4C) = _num_palettes;
            *(byteptr_t + offheader + 0x4E) = Mipmaps;
            *(byteptr_t + offheader + 0x4F) = TileableUV;
            *(byteptr_t + offheader + 0x50) = _bias_level;
            *(byteptr_t + offheader + 0x51) = _rendering_order;
            *(byteptr_t + offheader + 0x52) = _scroll_type;
            *(byteptr_t + offheader + 0x53) = _used_flag;
            *(byteptr_t + offheader + 0x54) = _apply_alpha_sort;
            *(byteptr_t + offheader + 0x55) = _alpha_usage_type;
            *(byteptr_t + offheader + 0x56) = _alpha_blend_type;
            *(byteptr_t + offheader + 0x57) = _flags;
            *(byteptr_t + offheader + 0x58) = MipmapBiasType;
            *(byteptr_t + offheader + 0x59) = _padding;
            *(short*)(byteptr_t + offheader + 0x5A) = _scroll_timestep;
            *(short*)(byteptr_t + offheader + 0x5C) = _scroll_speedS;
            *(short*)(byteptr_t + offheader + 0x5E) = _scroll_speedT;
            *(short*)(byteptr_t + offheader + 0x60) = _offsetS;
            *(short*)(byteptr_t + offheader + 0x62) = _offsetT;
            *(short*)(byteptr_t + offheader + 0x64) = _scaleS;
            *(short*)(byteptr_t + offheader + 0x66) = _scaleT;
            *(int*)(byteptr_t + offheader + 0x68) = _unknown1;
            *(int*)(byteptr_t + offheader + 0x6C) = _unknown2;
            *(int*)(byteptr_t + offheader + 0x70) = _unknown3;
            *(int*)(byteptr_t + offheader + 0x74) = _unknown4;
            *(int*)(byteptr_t + offheader + 0x78) = _unknown5;

            // Check secret compression
            if (_secretp8)
                *(byteptr_t + offheader + 0x4A) = EAComp.SECRET;

            // Precalculate next offsets
            offheader += 0x7C; // set next header offset
            offdata = Offset + Size; // set next data offset
            var a2 = 0x80 - (offdata % 0x80);
            if (a2 != 0x80)
                offdata += a2;
        }
    }
}