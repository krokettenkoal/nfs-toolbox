using System;
using System.IO;
using NfsCore.Reflection.ID;
using NfsCore.Utils;
using NfsCore.Utils.DDS;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2.Class
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
            fixed (byte* bytePtrT = &data[0])
            {
                Height = (short) *(uint*) (bytePtrT + 0xC);
                Width = (short) *(uint*) (bytePtrT + 0x10);
                Mipmaps = (byte) *(uint*) (bytePtrT + 0x1C);
                if (*(uint*) (bytePtrT + 0x50) == DDS_TYPE.RGBA)
                {
                    var cData = Palette.RGBAtoP8(data);
                    if (cData == null)
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
                        Data = new byte[cData.Length];
                        Buffer.BlockCopy(cData, 0, Data, 0, Size + PaletteSize);
                    }
                }
                else
                {
                    CompressionId = Comp.GetByte(*(uint*) (bytePtrT + 0x54));
                    Size = data.Length - 0x80;
                    _area = Comp.FlipToBase(Size);
                    Data = new byte[Size];
                    Buffer.BlockCopy(data, 0x80, Data, 0, Size);
                }

                // Default palette
                _numPalettes = (short) (PaletteSize / 4);
            }
        }
    }
}