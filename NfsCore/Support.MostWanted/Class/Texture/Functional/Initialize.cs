using System;
using System.IO;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.ID;
using NfsCore.Utils;
using NfsCore.Utils.DDS;
using NfsCore.Utils.EA;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Initializes all properties of the new texture.
        /// </summary>
        /// <param name="filename">Filename of the .dds texture passed.</param>
        protected override unsafe void Initialize(string filename)
        {
            var data = File.ReadAllBytes(filename);
            byte[] cdata;
            fixed (byte* byteptr_t = &data[0])
            {
                Height = (short)*(uint*)(byteptr_t + 0xC);
                Width = (short)*(uint*)(byteptr_t + 0x10);
                Mipmaps = (byte)*(uint*)(byteptr_t + 0x1C);
                if (*(uint*)(byteptr_t + 0x50) == DDS_TYPE.RGBA)
                {
                    cdata = Palette.RGBAtoP8(data);
                    if (cdata == null)
                    {
                        CompressionId = EAComp.RGBA_08;
                        _area = Width * Height * 4;
                        Size = data.Length - 0x80;
                        PaletteSize = 0;
                        Data = new byte[Size];
                        Buffer.BlockCopy(data, 0, Data, 0, Size);
                    }
                    else
                    {
                        CompressionId = EAComp.P8_08;
                        _area = Width * Height * 4;
                        Size = (data.Length - 0x80) / 4;
                        PaletteSize = 0x400;
                        Data = new byte[cdata.Length];
                        Buffer.BlockCopy(cdata, 0, Data, 0, Size + PaletteSize);
                    }
                }
                else
                {
                    CompressionId = Comp.GetByte(*(uint*)(byteptr_t + 0x54));
                    Size = data.Length - 0x80;
                    _area = Comp.FlipToBase(Size);
                    Data = new byte[Size];
                    Buffer.BlockCopy(data, 0x80, Data, 0, Size);
                }

                // Default all other values
                _num_palettes = (short)(PaletteSize / 4);
                TileableUV = 0;
                _bias_level = 0;
                _rendering_order = 5;
                _scroll_type = 0;
                _used_flag = 0;
                _apply_alpha_sort = 0;
                _alpha_usage_type = (byte)eAlphaUsageType.TEXUSAGE_MODULATED;
                _alpha_blend_type = (byte)eTextureAlphaBlendType.TEXBLEND_BLEND;
                _flags = 0;
                MipmapBiasType = (byte)eTextureMipmapBiasType.TEXBIAS_DEFAULT;
                _scroll_timestep = 0;
                _scroll_speedS = 0;
                _scroll_speedT = 0;
                _offsetS = 0;
                _offsetT = 0x100;
                _scaleS = 0x100;
                _scaleT = 0;
            }
        }
    }
}