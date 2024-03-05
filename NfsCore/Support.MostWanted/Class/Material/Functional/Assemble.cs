namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[0xB0];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write header of the material
                *(uint*) (bytePtrT + 0) = Id;
                *(int*) (bytePtrT + 4) = Size;
                *(int*) (bytePtrT + 8) = UnknownMaterialProp1;
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
                *(float*) (bytePtrT + 0x58) = _transparency;
                *(float*) (bytePtrT + 0x5C) = _reflection1;
                *(float*) (bytePtrT + 0x60) = _reflection2;
                *(float*) (bytePtrT + 0x64) = _reflection3;
                *(float*) (bytePtrT + 0x68) = _unk1;
                *(float*) (bytePtrT + 0x6C) = _unk2;
                *(float*) (bytePtrT + 0x70) = _unk3;
                *(float*) (bytePtrT + 0x74) = _strongColor1Level;
                *(float*) (bytePtrT + 0x78) = _strongColor1Red;
                *(float*) (bytePtrT + 0x7C) = _strongColor1Green;
                *(float*) (bytePtrT + 0x80) = _strongColor1Blue;
                *(float*) (bytePtrT + 0x84) = _shadowLevel;
                *(float*) (bytePtrT + 0x88) = _matteLevel;
                *(float*) (bytePtrT + 0x8C) = _chromeLevel;
                *(float*) (bytePtrT + 0x90) = _unk4;
                *(float*) (bytePtrT + 0x94) = _unk5;
                *(float*) (bytePtrT + 0x98) = _linearNegative;
                *(float*) (bytePtrT + 0x9C) = _gradientNegative;
                *(float*) (bytePtrT + 0xA0) = _unk6;
                *(float*) (bytePtrT + 0xA4) = _unk7;
                *(float*) (bytePtrT + 0xA8) = _unk8;
                *(float*) (bytePtrT + 0xAC) = _unk9;
            }

            return result;
        }
    }
}