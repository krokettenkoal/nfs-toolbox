namespace NfsCore.Support.Underground1.Class
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
            _transparency1 = *(float*) (bytePtrT + 0x58);
            _transparency2 = *(float*) (bytePtrT + 0x5C);
            _strong1To2Ratio = *(float*) (bytePtrT + 0x60);
            _strongColor1Level = *(float*) (bytePtrT + 0x64);
            _strongColor1Red = *(float*) (bytePtrT + 0x68);
            _strongColor1Green = *(float*) (bytePtrT + 0x6C);
            _strongColor1Blue = *(float*) (bytePtrT + 0x70);
            _strongColor2Level = *(float*) (bytePtrT + 0x74);
            _strongColor2Red = *(float*) (bytePtrT + 0x78);
            _strongColor2Green = *(float*) (bytePtrT + 0x7C);
            _strongColor2Blue = *(float*) (bytePtrT + 0x80);
            _strong3To4Ratio = *(float*) (bytePtrT + 0x84);
            _strongColor3Level = *(float*) (bytePtrT + 0x88);
            _strongColor3Red = *(float*) (bytePtrT + 0x8C);
            _strongColor3Green = *(float*) (bytePtrT + 0x90);
            _strongColor3Blue = *(float*) (bytePtrT + 0x94);
            _strongColor4Level = *(float*) (bytePtrT + 0x98);
            _strongColor4Red = *(float*) (bytePtrT + 0x9C);
            _strongColor4Green = *(float*) (bytePtrT + 0xA0);
            _strongColor4Blue = *(float*) (bytePtrT + 0xA4);
        }
    }
}