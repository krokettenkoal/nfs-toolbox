using GlobalLib.Utils;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the texture header array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            _cube_environment = *(uint*)byteptr_t;
            BinKey = *(uint*)(byteptr_t  + 0xC);
            _class = *(uint*)(byteptr_t  + 0x10);
            Offset = *(int*)(byteptr_t  + 0x14);
            PaletteOffset = *(int*)(byteptr_t  + 0x18);
            Size = *(int*)(byteptr_t  + 0x1C);
            PaletteSize = *(int*)(byteptr_t  + 0x20);
            _area = *(int*)(byteptr_t  + 0x24);
            Width = *(short*)(byteptr_t  + 0x28);
            Height = *(short*)(byteptr_t  + 0x2A);
            Log_2_Width = *(byteptr_t  + 0x2C);
            Log_2_Height = *(byteptr_t  + 0x2D);
            CompressionId = *(byteptr_t  + 0x2E);
            _pal_comp = *(byteptr_t  + 0x2F);
            _num_palettes = *(short*)(byteptr_t  + 0x30);
            Mipmaps = *(byteptr_t  + 0x32);
            TileableUV = *(byteptr_t  + 0x33);
            _bias_level = *(byteptr_t  + 0x34);
            _rendering_order = *(byteptr_t  + 0x35);
            _scroll_type = *(byteptr_t  + 0x36);
            _used_flag = *(byteptr_t  + 0x37);
            _apply_alpha_sort = *(byteptr_t  + 0x38);
            _alpha_usage_type = *(byteptr_t  + 0x39);
            _alpha_blend_type = *(byteptr_t  + 0x3A);
            _flags = *(byteptr_t  + 0x3B);
            MipmapBiasType = *(byteptr_t  + 0x3C);
            _padding = *(byteptr_t  + 0x3D);
            _scroll_timestep = *(short*)(byteptr_t  + 0x3E);
            _scroll_speedS = *(short*)(byteptr_t  + 0x40);
            _scroll_speedT = *(short*)(byteptr_t  + 0x42);
            _offsetS = *(short*)(byteptr_t  + 0x44);
            _offsetT = *(short*)(byteptr_t  + 0x46);
            _scaleS = *(short*)(byteptr_t  + 0x48);
            _scaleT = *(short*)(byteptr_t  + 0x4A);
            _unknown1 = *(int*)(byteptr_t  + 0x4C);
            _unknown2 = *(int*)(byteptr_t  + 0x50);
            _unknown3 = *(int*)(byteptr_t  + 0x54);

            // Get texture name
            _collectionName = ScriptX.NullTerminatedString(byteptr_t  + 0x59, *(byteptr_t  + 0x58));
        }
    }
}