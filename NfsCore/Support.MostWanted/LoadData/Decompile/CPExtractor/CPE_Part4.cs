namespace NfsCore.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies entire part4 of CarParts block into memory.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the ID of the part4 of CarParts block.</param>
        /// <param name="length">Lenght of the part4 of CarParts block including ID and size.</param>
        /// <returns>Part4 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part4(byte* bytePtrT, uint length)
        {
            var data = new byte[length];
            fixed (byte* dataPtrT = &data[0])
            {
                for (var a1 = 0; a1 < length; ++a1)
                    *(dataPtrT + a1) = *(bytePtrT + a1);
            }

            return data;
        }
    }
}