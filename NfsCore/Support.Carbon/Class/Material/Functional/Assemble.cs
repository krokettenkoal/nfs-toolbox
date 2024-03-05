namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[0xF4];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write header of the material
                *(uint*) (bytePtrT + 0) = Id;
                *(int*) (bytePtrT + 4) = Size;
                *(int*) (bytePtrT + 8) = UnknownMaterialProp0;
                *(int*) (bytePtrT + 0xC) = MaterialLocalizer;
                *(int*) (bytePtrT + 0x10) = MaterialLocalizer;
                *(uint*) (bytePtrT + 0x14) = BinKey;
                *(int*) (bytePtrT + 0x18) = MaterialLocalizer;

                // Write CollectionName
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + 0x1C + a1) = (byte) CollectionName[a1];

                // Write all settings
                *(float*) (bytePtrT + 0x5C) = _shadowOuterRadius;
                *(float*) (bytePtrT + 0x60) = _optimalLightReflection;
                *(float*) (bytePtrT + 0x64) = _unk1;
                *(float*) (bytePtrT + 0x68) = _grayscale;
                *(float*) (bytePtrT + 0x6C) = _brightcolor1_level;
                *(float*) (bytePtrT + 0x70) = _brightcolor1_red;
                *(float*) (bytePtrT + 0x74) = _brightcolor1_green;
                *(float*) (bytePtrT + 0x78) = _brightcolor1_blue;
                *(float*) (bytePtrT + 0x7C) = _brightcolor2_level;
                *(float*) (bytePtrT + 0x80) = _brightcolor2_red;
                *(float*) (bytePtrT + 0x84) = _brightcolor2_green;
                *(float*) (bytePtrT + 0x88) = _brightcolor2_blue;
                *(float*) (bytePtrT + 0x8C) = _transparency1;
                *(float*) (bytePtrT + 0x90) = _transparency2;
                *(float*) (bytePtrT + 0x94) = _disable_reflection;
                *(float*) (bytePtrT + 0x98) = _unk2;
                *(float*) (bytePtrT + 0x9C) = _unk3;
                *(float*) (bytePtrT + 0xA0) = _unk4;
                *(float*) (bytePtrT + 0xA4) = _unk5;
                *(float*) (bytePtrT + 0xA8) = _unk6;
                *(float*) (bytePtrT + 0xAC) = _unk7;
                *(float*) (bytePtrT + 0xB0) = _reflectionColorLevel;
                *(float*) (bytePtrT + 0xB4) = _reflectionColorRed;
                *(float*) (bytePtrT + 0xB8) = _reflectionColorGreen;
                *(float*) (bytePtrT + 0xBC) = _reflectionColorBlue;
                *(float*) (bytePtrT + 0xC0) = _stronger_reflection;
                *(float*) (bytePtrT + 0xC4) = _blend_strong_colors;
                *(float*) (bytePtrT + 0xC8) = _disable_strong_colors;
                *(float*) (bytePtrT + 0xCC) = _strongColor1Level;
                *(float*) (bytePtrT + 0xD0) = _strongColor1Red;
                *(float*) (bytePtrT + 0xD4) = _strongColor1Green;
                *(float*) (bytePtrT + 0xD8) = _strongColor1Blue;
                *(float*) (bytePtrT + 0xDC) = _strongColor2Level;
                *(float*) (bytePtrT + 0xE0) = _strongColor2Red;
                *(float*) (bytePtrT + 0xE4) = _strongColor2Green;
                *(float*) (bytePtrT + 0xE8) = _strongColor2Blue;
                *(float*) (bytePtrT + 0xEC) = _linearNegative;
                *(float*) (bytePtrT + 0xF0) = _gradientNegative;
            }

            return result;
        }
    }
}