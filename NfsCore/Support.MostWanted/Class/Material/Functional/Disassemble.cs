namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        /// <summary>
        /// Disassembles material array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the material array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            _brightColor1Level = *(float*) (bytePtrT + 0x38);
            _brightColor1Red = *(float*) (bytePtrT + 0x3C);
            _brightColor1Green = *(float*) (bytePtrT + 0x40);
            _brightColor1Blue = *(float*) (bytePtrT + 0x44);
            _brightColor2Level = *(float*) (bytePtrT + 0x48);
            _brightColor2Red = *(float*) (bytePtrT + 0x4C);
            _brightColor2Green = *(float*) (bytePtrT + 0x50);
            _brightColor2Blue = *(float*) (bytePtrT + 0x54);
            _transparency = *(float*) (bytePtrT + 0x58);
            _reflection1 = *(float*) (bytePtrT + 0x5C);
            _reflection2 = *(float*) (bytePtrT + 0x60);
            _reflection3 = *(float*) (bytePtrT + 0x64);
            _unk1 = *(float*) (bytePtrT + 0x68);
            _unk2 = *(float*) (bytePtrT + 0x6C);
            _unk3 = *(float*) (bytePtrT + 0x70);
            _strongColor1Level = *(float*) (bytePtrT + 0x74);
            _strongColor1Red = *(float*) (bytePtrT + 0x78);
            _strongColor1Green = *(float*) (bytePtrT + 0x7C);
            _strongColor1Blue = *(float*) (bytePtrT + 0x80);
            _shadowLevel = *(float*) (bytePtrT + 0x84);
            _matteLevel = *(float*) (bytePtrT + 0x88);
            _chromeLevel = *(float*) (bytePtrT + 0x8C);
            _unk4 = *(float*) (bytePtrT + 0x90);
            _unk5 = *(float*) (bytePtrT + 0x94);
            _linearNegative = *(float*) (bytePtrT + 0x98);
            _gradientNegative = *(float*) (bytePtrT + 0x9C);
            _unk6 = *(float*) (bytePtrT + 0xA0);
            _unk7 = *(float*) (bytePtrT + 0xA4);
            _unk8 = *(float*) (bytePtrT + 0xA8);
            _unk9 = *(float*) (bytePtrT + 0xAC);
        }
    }
}