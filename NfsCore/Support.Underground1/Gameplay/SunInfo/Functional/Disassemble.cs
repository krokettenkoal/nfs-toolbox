namespace NfsCore.Support.Underground1.Gameplay
{
    public partial class SunInfo
    {
        /// <summary>
        /// Disassembles suninfo block into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the suninfo block.</param>
        protected unsafe void Disassemble(byte* bytePtrT)
        {
            Version = *(int*) bytePtrT;
            PositionX = *(float*) (bytePtrT + 0x20);
            PositionY = *(float*) (bytePtrT + 0x24);
            PositionZ = *(float*) (bytePtrT + 0x28);
            CarShadowPositionX = *(float*) (bytePtrT + 0x2C);
            CarShadowPositionY = *(float*) (bytePtrT + 0x30);
            CarShadowPositionZ = *(float*) (bytePtrT + 0x34);
            SUNLAYER1.Read(bytePtrT + 0x38 + 0x24 * 0);
            SUNLAYER2.Read(bytePtrT + 0x38 + 0x24 * 1);
            SUNLAYER3.Read(bytePtrT + 0x38 + 0x24 * 2);
            SUNLAYER4.Read(bytePtrT + 0x38 + 0x24 * 3);
            SUNLAYER5.Read(bytePtrT + 0x38 + 0x24 * 4);
            SUNLAYER6.Read(bytePtrT + 0x38 + 0x24 * 5);
        }
    }
}