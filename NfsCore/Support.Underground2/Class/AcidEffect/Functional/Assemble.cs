using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class AcidEffect
    {
        /// <summary>
        /// Assembles xenon effect into a byte array.
        /// </summary>
        /// <returns>Byte array of the xenon effect.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[0xD0];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write all settings
                *(int*) bytePtrT = Localizer;
                *(int*) (bytePtrT + 0x04) = Localizer;
                *(uint*) (bytePtrT + 0x08) = BinKey;
                *(uint*) (bytePtrT + 0x0C) = BinKey;
                *(uint*) (bytePtrT + 0x10) = ClassKey;
                *(uint*) (bytePtrT + 0x18) = Flags;
                *(ushort*) (bytePtrT + 0x1C) = NumEmitters;
                *(ushort*) (bytePtrT + 0x1E) = SectionNumber;
                *(float*) (bytePtrT + 0x20) = LocalWorldVec1X;
                *(float*) (bytePtrT + 0x24) = LocalWorldVec1Y;
                *(float*) (bytePtrT + 0x28) = LocalWorldVec1Z;
                *(float*) (bytePtrT + 0x2C) = LocalWorldVec1W;
                *(float*) (bytePtrT + 0x30) = LocalWorldVec2X;
                *(float*) (bytePtrT + 0x34) = LocalWorldVec2Y;
                *(float*) (bytePtrT + 0x38) = LocalWorldVec2Z;
                *(float*) (bytePtrT + 0x3C) = LocalWorldVec2W;
                *(float*) (bytePtrT + 0x40) = LocalWorldVec3X;
                *(float*) (bytePtrT + 0x44) = LocalWorldVec3Y;
                *(float*) (bytePtrT + 0x48) = LocalWorldVec3Z;
                *(float*) (bytePtrT + 0x4C) = LocalWorldVec3W;
                *(float*) (bytePtrT + 0x50) = LocalWorldVec4X;
                *(float*) (bytePtrT + 0x54) = LocalWorldVec4Y;
                *(float*) (bytePtrT + 0x58) = LocalWorldVec4Z;
                *(float*) (bytePtrT + 0x5C) = LocalWorldVec4W;
                *(uint*) (bytePtrT + 0x60) = Bin.SmartHash(_inheritanceKey);
                *(float*) (bytePtrT + 0x64) = FarClip;
                *(float*) (bytePtrT + 0x68) = Intensity;
                *(float*) (bytePtrT + 0x70) = LastPositionX;
                *(float*) (bytePtrT + 0x74) = LastPositionY;
                *(float*) (bytePtrT + 0x78) = LastPositionZ;
                *(float*) (bytePtrT + 0x7C) = LastPositionW;
                *(uint*) (bytePtrT + 0x84) = NumZeroParticleFrames;
                *(uint*) (bytePtrT + 0x88) = CreationTimeStamp;

                // Write CollectionName
                for (var a1 = 0; a1 < CollName.Length; ++a1)
                    *(bytePtrT + 0x90 + a1) = (byte) CollName[a1];
            }

            return result;
        }
    }
}