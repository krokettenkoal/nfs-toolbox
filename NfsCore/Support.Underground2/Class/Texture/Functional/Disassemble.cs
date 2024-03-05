using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Disassembles texture header array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the texture header array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            CollName = ScriptX.NullTerminatedString(bytePtrT + 0xC, 0x18);

            _binKey = *(uint*) (bytePtrT + 0x24);
            _class = *(uint*) (bytePtrT + 0x28);
            _unknown0 = *(int*) (bytePtrT + 0x2C);
            Offset = *(int*) (bytePtrT + 0x30);
            PaletteOffset = *(int*) (bytePtrT + 0x34);
            Size = *(int*) (bytePtrT + 0x38);
            PaletteSize = *(int*) (bytePtrT + 0x3C);
            _area = *(int*) (bytePtrT + 0x40);
            Width = *(short*) (bytePtrT + 0x44);
            Height = *(short*) (bytePtrT + 0x46);
            Log2Width = *(bytePtrT + 0x48);
            Log2Height = *(bytePtrT + 0x49);
            CompressionId = *(bytePtrT + 0x4A);
            PalComp = *(bytePtrT + 0x4B);
            _numPalettes = *(short*) (bytePtrT + 0x4C);
            Mipmaps = *(bytePtrT + 0x4E);
            TileableUV = *(bytePtrT + 0x4F);
            _biasLevel = *(bytePtrT + 0x50);
            _renderingOrder = *(bytePtrT + 0x51);
            _scrollType = *(bytePtrT + 0x52);
            _usedFlag = *(bytePtrT + 0x53);
            _applyAlphaSort = *(bytePtrT + 0x54);
            _alphaUsageType = *(bytePtrT + 0x55);
            _alphaBlendType = *(bytePtrT + 0x56);
            _flags = *(bytePtrT + 0x57);
            MipmapBiasType = *(bytePtrT + 0x58);
            _padding = *(bytePtrT + 0x59);
            _scrollTimeStep = *(short*) (bytePtrT + 0x5A);
            _scrollSpeedS = *(short*) (bytePtrT + 0x5C);
            _scrollSpeedT = *(short*) (bytePtrT + 0x5E);
            _offsetS = *(short*) (bytePtrT + 0x60);
            _offsetT = *(short*) (bytePtrT + 0x62);
            _scaleS = *(short*) (bytePtrT + 0x64);
            _scaleT = *(short*) (bytePtrT + 0x66);
            _unknown1 = *(int*) (bytePtrT + 0x68);
            _unknown2 = *(int*) (bytePtrT + 0x6C);
            _unknown3 = *(int*) (bytePtrT + 0x70);
            _unknown4 = *(int*) (bytePtrT + 0x74);
            _unknown5 = *(int*) (bytePtrT + 0x78);

            // Get compression name
            if (CompressionId != EAComp.SECRET) return;
            CompressionId = EAComp.P8_08;
            SecretP8 = true;
        }
    }
}