using NfsCore.Global;

namespace NfsCore.Support.Underground2.Class
{
    public partial class AcidEffect
    {
        /// <summary>
        /// Disassembles acid effect array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the acid effect array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            ClassKey = *(uint*) (bytePtrT + 0x10);
            Flags = *(uint*) (bytePtrT + 0x18);
            NumEmitters = *(ushort*) (bytePtrT + 0x1C);
            SectionNumber = *(ushort*) (bytePtrT + 0x1E);
            LocalWorldVec1X = *(float*) (bytePtrT + 0x20);
            LocalWorldVec1Y = *(float*) (bytePtrT + 0x24);
            LocalWorldVec1Z = *(float*) (bytePtrT + 0x28);
            LocalWorldVec1W = *(float*) (bytePtrT + 0x2C);
            LocalWorldVec2X = *(float*) (bytePtrT + 0x30);
            LocalWorldVec2Y = *(float*) (bytePtrT + 0x34);
            LocalWorldVec2Z = *(float*) (bytePtrT + 0x38);
            LocalWorldVec2W = *(float*) (bytePtrT + 0x3C);
            LocalWorldVec3X = *(float*) (bytePtrT + 0x40);
            LocalWorldVec3Y = *(float*) (bytePtrT + 0x44);
            LocalWorldVec3Z = *(float*) (bytePtrT + 0x48);
            LocalWorldVec3W = *(float*) (bytePtrT + 0x4C);
            LocalWorldVec4X = *(float*) (bytePtrT + 0x50);
            LocalWorldVec4Y = *(float*) (bytePtrT + 0x54);
            LocalWorldVec4Z = *(float*) (bytePtrT + 0x58);
            LocalWorldVec4W = *(float*) (bytePtrT + 0x5C);

            var key = *(uint*) (bytePtrT + 0x60);
            _inheritanceKey = Map.Lookup(key, true) ?? $"0x{key:X8}";

            FarClip = *(float*) (bytePtrT + 0x64);
            Intensity = *(float*) (bytePtrT + 0x68);
            LastPositionX = *(float*) (bytePtrT + 0x70);
            LastPositionY = *(float*) (bytePtrT + 0x74);
            LastPositionZ = *(float*) (bytePtrT + 0x78);
            LastPositionW = *(float*) (bytePtrT + 0x7C);
            NumZeroParticleFrames = *(uint*) (bytePtrT + 0x84);
            CreationTimeStamp = *(uint*) (bytePtrT + 0x88);
        }
    }
}