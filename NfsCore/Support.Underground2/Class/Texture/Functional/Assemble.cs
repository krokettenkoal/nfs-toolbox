using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Assembles texture header into a byte array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk texture header data.</param>
        /// <param name="offHeader">Current offset in the tpk texture header data.</param>
        /// <param name="offData">Current offset in the tpk data.</param>
        public override unsafe void Assemble(byte* bytePtrT, ref int offHeader, ref int offData)
        {
            // Get offset data
            if (CompressionId == EAComp.P8_08)
            {
                PaletteOffset = offData;
                Offset = offData + PaletteSize;
            }
            else
                Offset = offData;

            // Write CollectionName
            var a3 = (CollName.Length > 0x17) ? 0x17 : CollName.Length;
            for (var a1 = 0; a1 < a3; ++a1)
                *(bytePtrT + offHeader + 0xC + a1) = (byte) CollName[a1];

            // Write all settings
            *(uint*) (bytePtrT + offHeader + 0x24) = BinKey;
            *(uint*) (bytePtrT + offHeader + 0x28) = _class;
            *(int*) (bytePtrT + offHeader + 0x2C) = _unknown0;
            *(uint*) (bytePtrT + offHeader + 0x30) = (uint) Offset;
            *(uint*) (bytePtrT + offHeader + 0x34) = (uint) PaletteOffset;
            *(int*) (bytePtrT + offHeader + 0x38) = Size;
            *(int*) (bytePtrT + offHeader + 0x3C) = PaletteSize;
            *(int*) (bytePtrT + offHeader + 0x40) = _area;
            *(short*) (bytePtrT + offHeader + 0x44) = Width;
            *(short*) (bytePtrT + offHeader + 0x46) = Height;
            *(bytePtrT + offHeader + 0x48) = Log2Width;
            *(bytePtrT + offHeader + 0x49) = Log2Height;
            *(bytePtrT + offHeader + 0x4A) = CompressionId;
            *(bytePtrT + offHeader + 0x4B) = PalComp;
            *(short*) (bytePtrT + offHeader + 0x4C) = _numPalettes;
            *(bytePtrT + offHeader + 0x4E) = Mipmaps;
            *(bytePtrT + offHeader + 0x4F) = TileableUV;
            *(bytePtrT + offHeader + 0x50) = _biasLevel;
            *(bytePtrT + offHeader + 0x51) = _renderingOrder;
            *(bytePtrT + offHeader + 0x52) = _scrollType;
            *(bytePtrT + offHeader + 0x53) = _usedFlag;
            *(bytePtrT + offHeader + 0x54) = _applyAlphaSort;
            *(bytePtrT + offHeader + 0x55) = _alphaUsageType;
            *(bytePtrT + offHeader + 0x56) = _alphaBlendType;
            *(bytePtrT + offHeader + 0x57) = _flags;
            *(bytePtrT + offHeader + 0x58) = MipmapBiasType;
            *(bytePtrT + offHeader + 0x59) = _padding;
            *(short*) (bytePtrT + offHeader + 0x5A) = _scrollTimeStep;
            *(short*) (bytePtrT + offHeader + 0x5C) = _scrollSpeedS;
            *(short*) (bytePtrT + offHeader + 0x5E) = _scrollSpeedT;
            *(short*) (bytePtrT + offHeader + 0x60) = _offsetS;
            *(short*) (bytePtrT + offHeader + 0x62) = _offsetT;
            *(short*) (bytePtrT + offHeader + 0x64) = _scaleS;
            *(short*) (bytePtrT + offHeader + 0x66) = _scaleT;
            *(int*) (bytePtrT + offHeader + 0x68) = _unknown1;
            *(int*) (bytePtrT + offHeader + 0x6C) = _unknown2;
            *(int*) (bytePtrT + offHeader + 0x70) = _unknown3;
            *(int*) (bytePtrT + offHeader + 0x74) = _unknown4;
            *(int*) (bytePtrT + offHeader + 0x78) = _unknown5;

            // Check secret compression
            if (SecretP8)
                *(bytePtrT + offHeader + 0x4A) = EAComp.SECRET;

            // Precalculate next offsets
            offHeader += 0x7C; // set next header offset
            offData = Offset + Size; // set next data offset
            var a2 = 0x80 - (offData % 0x80);
            if (a2 != 0x80)
                offData += a2;
        }
    }
}