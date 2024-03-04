using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.ID;
using GlobalLib.Utils.DDS;
using GlobalLib.Utils.EA;
using System;
using System.IO;

namespace GlobalLib.Support.Carbon.Class
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
            fixed (byte* bytePtrT = &data[0])
            {
                Size = data.Length - 0x80;
                Height = (short)*(uint*)(bytePtrT + 0xC);
                Width = (short)*(uint*)(bytePtrT + 0x10);
                Mipmaps = (byte)*(uint*)(bytePtrT + 0x1C);
                if (*(uint*)(bytePtrT + 0x50) == DDS_TYPE.RGBA)
                {
                    CompressionId = EAComp.RGBA_08;
                    _area = Width * Height * 4;
                }
                else
                {
                    CompressionId = Comp.GetByte(*(uint*)(bytePtrT + 0x54));
                    _area = Comp.FlipToBase(Size);
                }

                // Default all other values
                _num_palettes = 0;
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

            // Copy data to the memory
            Data = new byte[Size];
            Buffer.BlockCopy(data, 0x80, Data, 0, Size);
        }
    }
}