using GlobalLib.Reflection.ID;
using GlobalLib.Utils;
using GlobalLib.Utils.DDS;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Gets .dds texture data along with the .dds header.
        /// </summary>
        /// <returns>.dds texture as a byte array.</returns>
        public override unsafe byte[] GetDDSArray()
        {
            byte[] data;
            if (CompressionId == EAComp.P8_08)
            {
                data = new byte[Size * 4 + 0x80];
                var copy = Palette.P8toRGBA(Data);
                Buffer.BlockCopy(copy, 0, data, 0x80, copy.Length);
            }
            else
            {
                data = new byte[Data.Length + 0x80];
                Buffer.BlockCopy(Data, 0, data, 0x80, Data.Length);
            }

            // Initialize header first
            var ddsHeader = new DDS_HEADER
            {
                dwFlags = DDS_HEADER_FLAGS.TEXTURE // add texture definition
            };
            ddsHeader.dwFlags += DDS_HEADER_FLAGS.MIPMAP; // add mipmap definition
            if (CompressionId is EAComp.RGBA_08 or EAComp.P8_08)
                ddsHeader.dwFlags += DDS_HEADER_FLAGS.PITCH; // add pitch for uncompressed
            else
                ddsHeader.dwFlags += DDS_HEADER_FLAGS.LINEARSIZE; // add linearsize for compressed

            ddsHeader.dwHeight = (uint)Height;
            ddsHeader.dwWidth = (uint)Width;

            ddsHeader.dwDepth = 1; // considering it is not a cubic texture
            ddsHeader.dwMipMapCount = Mipmaps;

            Comp.GetPixelFormat(ref ddsHeader.ddspf, CompressionId);
            ddsHeader.dwCaps = DDSCAPS.SURFACE_FLAGS_TEXTURE; // by default is a texture
            ddsHeader.dwCaps += DDSCAPS.SURFACE_FLAGS_MIPMAP; // mipmaps should be included
            ddsHeader.dwPitchOrLinearSize = Comp.PitchLinearSize(CompressionId, Width, Height, ddsHeader.ddspf.dwRGBBitCount);

            // Write header using ptr
            fixed (byte* byteptr_t = &data[0])
            {
                *(uint*)(byteptr_t + 0) = DDS_MAIN.MAGIC;
                *(uint*)(byteptr_t + 4) = ddsHeader.dwSize;
                *(uint*)(byteptr_t + 8) = ddsHeader.dwFlags;
                *(uint*)(byteptr_t + 0xC) = ddsHeader.dwHeight;
                *(uint*)(byteptr_t + 0x10) = ddsHeader.dwWidth;
                *(uint*)(byteptr_t + 0x14) = ddsHeader.dwPitchOrLinearSize;
                *(uint*)(byteptr_t + 0x18) = ddsHeader.dwDepth;
                *(uint*)(byteptr_t + 0x1C) = ddsHeader.dwMipMapCount;
                for (int a1 = 0; a1 < 11; ++a1)
                    *(uint*)(byteptr_t + 0x20 + a1 * 4) = ddsHeader.dwReserved1[a1];
                *(uint*)(byteptr_t + 0x4C) = ddsHeader.ddspf.dwSize;
                *(uint*)(byteptr_t + 0x50) = ddsHeader.ddspf.dwFlags;
                *(uint*)(byteptr_t + 0x54) = ddsHeader.ddspf.dwFourCC;
                *(uint*)(byteptr_t + 0x58) = ddsHeader.ddspf.dwRGBBitCount;
                *(uint*)(byteptr_t + 0x5C) = ddsHeader.ddspf.dwRBitMask;
                *(uint*)(byteptr_t + 0x60) = ddsHeader.ddspf.dwGBitMask;
                *(uint*)(byteptr_t + 0x64) = ddsHeader.ddspf.dwBBitMask;
                *(uint*)(byteptr_t + 0x68) = ddsHeader.ddspf.dwABitMask;
                *(uint*)(byteptr_t + 0x6C) = ddsHeader.dwCaps;
                *(uint*)(byteptr_t + 0x70) = ddsHeader.dwCaps2;
                *(uint*)(byteptr_t + 0x74) = ddsHeader.dwCaps3;
                *(uint*)(byteptr_t + 0x78) = ddsHeader.dwCaps4;
                *(uint*)(byteptr_t + 0x7C) = ddsHeader.dwReserved2;
            }

            return data;
        }
    }
}