using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the texture header array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            _cubeEnvironment = *(uint*) bytePtrT;
            _binKey = *(uint*) (bytePtrT + 0xC);
            _class = *(uint*) (bytePtrT + 0x10);
            Offset = *(int*) (bytePtrT + 0x14);
            PaletteOffset = *(int*) (bytePtrT + 0x18);
            Size = *(int*) (bytePtrT + 0x1C);
            PaletteSize = *(int*) (bytePtrT + 0x20);
            _area = *(int*) (bytePtrT + 0x24);
            Width = *(short*) (bytePtrT + 0x28);
            Height = *(short*) (bytePtrT + 0x2A);
            Log2Width = *(bytePtrT + 0x2C);
            Log2Height = *(bytePtrT + 0x2D);
            CompressionId = *(bytePtrT + 0x2E);
            PalComp = *(bytePtrT + 0x2F);
            _numPalettes = *(short*) (bytePtrT + 0x30);
            Mipmaps = *(bytePtrT + 0x32);
            TileableUV = *(bytePtrT + 0x33);
            _biasLevel = *(bytePtrT + 0x34);
            _renderingOrder = *(bytePtrT + 0x35);
            _scrollType = *(bytePtrT + 0x36);
            _usedFlag = *(bytePtrT + 0x37);
            _applyAlphaSort = *(bytePtrT + 0x38);
            _alphaUsageType = *(bytePtrT + 0x39);
            _alphaBlendType = *(bytePtrT + 0x3A);
            _flags = *(bytePtrT + 0x3B);
            MipmapBiasType = *(bytePtrT + 0x3C);
            _padding = *(bytePtrT + 0x3D);
            _scrollTimeStep = *(short*) (bytePtrT + 0x3E);
            _scrollSpeedS = *(short*) (bytePtrT + 0x40);
            _scrollSpeedT = *(short*) (bytePtrT + 0x42);
            _offsetS = *(short*) (bytePtrT + 0x44);
            _offsetT = *(short*) (bytePtrT + 0x46);
            _scaleS = *(short*) (bytePtrT + 0x48);
            _scaleT = *(short*) (bytePtrT + 0x4A);
            _unknown1 = *(int*) (bytePtrT + 0x4C);
            _unknown2 = *(int*) (bytePtrT + 0x50);
            _unknown3 = *(int*) (bytePtrT + 0x54);

            // Get texture name
            CollName = ScriptX.NullTerminatedString(bytePtrT + 0x59, *(bytePtrT + 0x58));
        }
    }
}