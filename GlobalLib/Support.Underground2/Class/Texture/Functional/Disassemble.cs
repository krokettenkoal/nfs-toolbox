using GlobalLib.Reflection.ID;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the texture header array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            _collectionName = ScriptX.NullTerminatedString(byteptr_t + 0xC , 0x18);

            BinKey = *(uint*)(byteptr_t  + 0x24);
            _class = *(uint*)(byteptr_t  + 0x28);
            _unknown0 = *(int*)(byteptr_t  + 0x2C);
            Offset = *(int*)(byteptr_t  + 0x30);
            PaletteOffset = *(int*)(byteptr_t  + 0x34);
            Size = *(int*)(byteptr_t  + 0x38);
            PaletteSize = *(int*)(byteptr_t  + 0x3C);
            _area = *(int*)(byteptr_t  + 0x40);
            Width = *(short*)(byteptr_t  + 0x44);
            Height = *(short*)(byteptr_t  + 0x46);
            Log_2_Width = *(byteptr_t  + 0x48);
            Log_2_Height = *(byteptr_t  + 0x49);
            CompressionId = *(byteptr_t  + 0x4A);
            _pal_comp = *(byteptr_t  + 0x4B);
            _num_palettes = *(short*)(byteptr_t  + 0x4C);
            Mipmaps = *(byteptr_t  + 0x4E);
            TileableUV = *(byteptr_t  + 0x4F);
            _bias_level = *(byteptr_t  + 0x50);
            _rendering_order = *(byteptr_t  + 0x51);
            _scroll_type = *(byteptr_t  + 0x52);
            _used_flag = *(byteptr_t  + 0x53);
            _apply_alpha_sort = *(byteptr_t  + 0x54);
            _alpha_usage_type = *(byteptr_t  + 0x55);
            _alpha_blend_type = *(byteptr_t  + 0x56);
            _flags = *(byteptr_t  + 0x57);
            MipmapBiasType = *(byteptr_t  + 0x58);
            _padding = *(byteptr_t  + 0x59);
            _scroll_timestep = *(short*)(byteptr_t  + 0x5A);
            _scroll_speedS = *(short*)(byteptr_t  + 0x5C);
            _scroll_speedT = *(short*)(byteptr_t  + 0x5E);
            _offsetS = *(short*)(byteptr_t  + 0x60);
            _offsetT = *(short*)(byteptr_t  + 0x62);
            _scaleS = *(short*)(byteptr_t  + 0x64);
            _scaleT = *(short*)(byteptr_t  + 0x66);
            _unknown1 = *(int*)(byteptr_t  + 0x68);
            _unknown2 = *(int*)(byteptr_t  + 0x6C);
            _unknown3 = *(int*)(byteptr_t  + 0x70);
            _unknown4 = *(int*)(byteptr_t  + 0x74);
            _unknown5 = *(int*)(byteptr_t  + 0x78);

            // Get compression name
            if (CompressionId != EAComp.SECRET) return;
            CompressionId = EAComp.P8_08;
            _secretp8 = true;
        }
    }
}