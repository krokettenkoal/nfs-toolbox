namespace NfsCore.Support.Carbon.Class
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
            var a1 = CollName.Length > 0x22 ? 0x22 : CollName.Length;
            var a2 = 0x5D + a1 - (1 + a1) % 4; // size of the texture header

            Offset = offData;

            // Write all settings
            *(uint*) (bytePtrT + offHeader) = _cubeEnvironment;
            *(uint*) (bytePtrT + offHeader + 0xC) = BinKey;
            *(uint*) (bytePtrT + offHeader + 0x10) = _class;
            *(uint*) (bytePtrT + offHeader + 0x14) = (uint) Offset;
            *(uint*) (bytePtrT + offHeader + 0x18) = (uint) PaletteOffset;
            *(int*) (bytePtrT + offHeader + 0x1C) = Size;
            *(int*) (bytePtrT + offHeader + 0x20) = PaletteSize;
            *(int*) (bytePtrT + offHeader + 0x24) = _area;
            *(short*) (bytePtrT + offHeader + 0x28) = Width;
            *(short*) (bytePtrT + offHeader + 0x2A) = Height;
            *(bytePtrT + offHeader + 0x2C) = Log2Width;
            *(bytePtrT + offHeader + 0x2D) = Log2Height;
            *(bytePtrT + offHeader + 0x2E) = CompressionId;
            *(bytePtrT + offHeader + 0x2F) = PalComp;
            *(short*) (bytePtrT + offHeader + 0x30) = _numPalettes;
            *(bytePtrT + offHeader + 0x32) = Mipmaps;
            *(bytePtrT + offHeader + 0x33) = TileableUV;
            *(bytePtrT + offHeader + 0x34) = _biasLevel;
            *(bytePtrT + offHeader + 0x35) = _renderingOrder;
            *(bytePtrT + offHeader + 0x36) = _scrollType;
            *(bytePtrT + offHeader + 0x37) = _usedFlag;
            *(bytePtrT + offHeader + 0x38) = _applyAlphaSort;
            *(bytePtrT + offHeader + 0x39) = _alphaUsageType;
            *(bytePtrT + offHeader + 0x3A) = _alphaBlendType;
            *(bytePtrT + offHeader + 0x3B) = _flags;
            *(bytePtrT + offHeader + 0x3C) = MipmapBiasType;
            *(bytePtrT + offHeader + 0x3D) = _padding;
            *(short*) (bytePtrT + offHeader + 0x3E) = _scrollTimeStep;
            *(short*) (bytePtrT + offHeader + 0x40) = _scrollSpeedS;
            *(short*) (bytePtrT + offHeader + 0x42) = _scrollSpeedT;
            *(short*) (bytePtrT + offHeader + 0x44) = _offsetS;
            *(short*) (bytePtrT + offHeader + 0x46) = _offsetT;
            *(short*) (bytePtrT + offHeader + 0x48) = _scaleS;
            *(short*) (bytePtrT + offHeader + 0x4A) = _scaleT;
            *(int*) (bytePtrT + offHeader + 0x4C) = _unknown1;
            *(int*) (bytePtrT + offHeader + 0x50) = _unknown2;
            *(int*) (bytePtrT + offHeader + 0x54) = _unknown3;
            *(bytePtrT + offHeader + 0x58) = (byte) (a2 - 0x59);

            // Write CollectionName
            for (var a3 = 0; a3 < a1; ++a3)
                *(bytePtrT + offHeader + 0x59 + a3) = (byte) CollectionName[a3];

            // Precalculate next offsets
            offHeader += a2; // set next header offset
            offData = Offset + Size; // set next data offset
            a1 = 0x80 - offData % 0x80;
            if (a1 != 0x80)
                offData += a1;
        }
    }
}