using System.IO;
using NfsCore.Support.Underground2.Framework;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies entire part2 of CarParts block into memory.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the ID of the part2 of CarParts block.</param>
        /// <param name="length">Length of part 3 of the CarParts block including ID and size.</param>
        /// <returns>Part2 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part2(byte* bytePtrT, uint length)
        {
            if (length < Assert.CpPart2AssertSize)
                throw new FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            var data = new byte[Assert.CpPart2AssertSize];
            for (var a1 = 0; a1 < Assert.CpPart2AssertSize; ++a1)
                data[a1] = *(bytePtrT + a1);
            return data;
        }
    }
}