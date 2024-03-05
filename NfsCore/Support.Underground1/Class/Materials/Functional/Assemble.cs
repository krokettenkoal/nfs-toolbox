namespace NfsCore.Support.Underground1.Class
{
    public partial class Material
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[0xA8];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write header of the material
                *(uint*) (bytePtrT + 0) = Id;
                *(int*) (bytePtrT + 4) = Size;
                *(uint*) (bytePtrT + 8) = ClassKey;
                *(int*) (bytePtrT + 0xC) = MaterialLocalizer;
                *(int*) (bytePtrT + 0x10) = MaterialLocalizer;
                *(uint*) (bytePtrT + 0x14) = BinKey;
                *(int*) (bytePtrT + 0x18) = MaterialLocalizer;

                // Write CollectionName
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + 0x1C + a1) = (byte) CollectionName[a1];

                // Write all settings
                *(float*) (bytePtrT + 0x38) = _brightColor1Level;
                *(float*) (bytePtrT + 0x3C) = _brightColor1Red;
                *(float*) (bytePtrT + 0x40) = _brightColor1Green;
                *(float*) (bytePtrT + 0x44) = _brightColor1Blue;
                *(float*) (bytePtrT + 0x48) = _brightColor2Level;
                *(float*) (bytePtrT + 0x4C) = _brightColor2Red;
                *(float*) (bytePtrT + 0x50) = _brightColor2Green;
                *(float*) (bytePtrT + 0x54) = _brightColor2Blue;
                *(float*) (bytePtrT + 0x58) = _transparency1;
                *(float*) (bytePtrT + 0x5C) = _transparency2;
                *(float*) (bytePtrT + 0x60) = _strong1To2Ratio;
                *(float*) (bytePtrT + 0x64) = _strongColor1Level;
                *(float*) (bytePtrT + 0x68) = _strongColor1Red;
                *(float*) (bytePtrT + 0x6C) = _strongColor1Green;
                *(float*) (bytePtrT + 0x70) = _strongColor1Blue;
                *(float*) (bytePtrT + 0x74) = _strongColor2Level;
                *(float*) (bytePtrT + 0x78) = _strongColor2Red;
                *(float*) (bytePtrT + 0x7C) = _strongColor2Green;
                *(float*) (bytePtrT + 0x80) = _strongColor2Blue;
                *(float*) (bytePtrT + 0x84) = _strong3To4Ratio;
                *(float*) (bytePtrT + 0x88) = _strongColor3Level;
                *(float*) (bytePtrT + 0x8C) = _strongColor3Red;
                *(float*) (bytePtrT + 0x90) = _strongColor3Green;
                *(float*) (bytePtrT + 0x94) = _strongColor3Blue;
                *(float*) (bytePtrT + 0x98) = _strongColor4Level;
                *(float*) (bytePtrT + 0x9C) = _strongColor4Red;
                *(float*) (bytePtrT + 0xA0) = _strongColor4Green;
                *(float*) (bytePtrT + 0xA4) = _strongColor4Blue;
            }

            return result;
        }
    }
}