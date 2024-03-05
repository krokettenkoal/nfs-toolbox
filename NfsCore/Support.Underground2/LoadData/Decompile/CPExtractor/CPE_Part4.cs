using System.IO;
using NfsCore.Support.Underground2.Framework;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies part 4 of the CarParts block into memory.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the ID of the part4 of CarParts block.</param>
        /// <param name="length">Length of the part4 of CarParts block including ID and size.</param>
        /// <returns>Part4 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part4(byte* bytePtrT, uint length)
        {
            if (length < Assert.CpPart4AssertSize)
                throw new FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            var data = new byte[Assert.CpPart4AssertSize];
            for (var a1 = 0; a1 < Assert.CpPart4AssertSize; ++a1)
                data[a1] = *(bytePtrT + a1);

            return data;
        }
    }
}