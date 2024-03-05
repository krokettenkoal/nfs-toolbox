using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Assembles preset skin into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset skin.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[0x68];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write CollectionName
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + 8 + a1) = (byte) CollectionName[a1];

                // Write all main settings
                *(uint*) (bytePtrT + 0x28) = (uint) PaintType;
                *(uint*) (bytePtrT + 0x2C) = Bin.Hash(Resolve.GetSwatchString(PaintSwatch));
                *(float*) (bytePtrT + 0x30) = PaintSaturation;
                *(float*) (bytePtrT + 0x34) = PaintBrightness;

                // Write Generic Vinyl
                *(uint*) (bytePtrT + 0x38) = Bin.SmartHash(_genericVinyl);

                // Write Vector Vinyl
                *(uint*) (bytePtrT + 0x3C) = Bin.SmartHash(_vectorVinyl);
                *(short*) (bytePtrT + 0x40) = PositionY;
                *(short*) (bytePtrT + 0x42) = PositionX;
                *(bytePtrT + 0x44) = (byte) Rotation;
                *(bytePtrT + 0x45) = (byte) Skew;
                *(bytePtrT + 0x46) = (byte) ScaleY;
                *(bytePtrT + 0x47) = (byte) ScaleX;
                *(uint*) (bytePtrT + 0x48) = Bin.Hash(Resolve.GetVinylString(SwatchColor1));
                *(uint*) (bytePtrT + 0x50) = Bin.Hash(Resolve.GetVinylString(SwatchColor2));
                *(uint*) (bytePtrT + 0x58) = Bin.Hash(Resolve.GetVinylString(SwatchColor3));
                *(uint*) (bytePtrT + 0x60) = Bin.Hash(Resolve.GetVinylString(SwatchColor4));
                *(bytePtrT + 0x4C) = Saturation1;
                *(bytePtrT + 0x54) = Saturation2;
                *(bytePtrT + 0x5C) = Saturation3;
                *(bytePtrT + 0x64) = Saturation4;
                *(bytePtrT + 0x4D) = Brightness1;
                *(bytePtrT + 0x55) = Brightness2;
                *(bytePtrT + 0x5D) = Brightness3;
                *(bytePtrT + 0x65) = Brightness4;
            }

            return result;
        }
    }
}