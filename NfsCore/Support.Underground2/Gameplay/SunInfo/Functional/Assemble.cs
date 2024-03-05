namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class SunInfo
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public unsafe byte[] Assemble()
        {
            var result = new byte[0x110];
            fixed (byte* bytePtrT = &result[0])
            {
                *(int*) bytePtrT = Version;
                *(uint*) (bytePtrT + 4) = BinKey;

                for (var a1 = 0; a1 < CollName.Length; ++a1)
                    *(bytePtrT + 8 + a1) = (byte) CollName[a1];

                *(float*) (bytePtrT + 0x20) = PositionX;
                *(float*) (bytePtrT + 0x24) = PositionY;
                *(float*) (bytePtrT + 0x28) = PositionZ;
                *(float*) (bytePtrT + 0x2C) = CarShadowPositionX;
                *(float*) (bytePtrT + 0x30) = CarShadowPositionY;
                *(float*) (bytePtrT + 0x34) = CarShadowPositionZ;
                SUNLAYER1.Write(bytePtrT + 0x38 + 0x24 * 0);
                SUNLAYER2.Write(bytePtrT + 0x38 + 0x24 * 1);
                SUNLAYER3.Write(bytePtrT + 0x38 + 0x24 * 2);
                SUNLAYER4.Write(bytePtrT + 0x38 + 0x24 * 3);
                SUNLAYER5.Write(bytePtrT + 0x38 + 0x24 * 4);
                SUNLAYER6.Write(bytePtrT + 0x38 + 0x24 * 5);
            }

            return result;
        }
    }
}