using System;
using System.IO;
using NfsCore.Reflection.ID;
using NfsCore.Utils.DDS;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
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
                Size = data.Length - 0x80;
                Height = (short) *(uint*) (bytePtrT + 0xC);
                Width = (short) *(uint*) (bytePtrT + 0x10);
                Mipmaps = (byte) *(uint*) (bytePtrT + 0x1C);
                if (*(uint*) (bytePtrT + 0x50) == DDS_TYPE.RGBA)
                {
                    CompressionId = EAComp.RGBA_08;
                    _area = Width * Height * 4;
                }
                else
                {
                    CompressionId = Comp.GetByte(*(uint*) (bytePtrT + 0x54));
                    _area = Comp.FlipToBase(Size);
                }

                // Default palette
                _numPalettes = 0;
                PaletteOffset = -1;
                PaletteSize = 0;
            }

            // Copy data to the memory
            Data = new byte[Size];
            Buffer.BlockCopy(data, 0x80, Data, 0, Size);
        }
    }
}