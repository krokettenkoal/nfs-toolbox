using System;
using System.IO;
using NfsCore.Reflection.ID;
using NfsCore.Utils;
using NfsCore.Utils.DDS;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground1.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Reloads texture properties based on the new texture passed.
        /// </summary>
        /// <param name="filename">Filename of .dds texture passed.</param>
        public override unsafe void Reload(string filename)
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

                // Default palette
                _num_palettes = (short)(PaletteSize / 4);
            }
        }
    }
}