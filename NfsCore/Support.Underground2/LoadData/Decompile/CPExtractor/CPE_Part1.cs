using System.IO;
using NfsCore.Global;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompiles part1 of CarParts block, extracts all strings and gets the array to memory.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the ID of the part1 of CarParts block.</param>
        /// <param name="length">Length of part 3 of the CarParts block including ID and size.</param>
        /// <returns>Part1 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part1(byte* bytePtrT, uint length)
        {
            if (length < Assert.CpPart1AssertSize)
                throw new FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            var data = new byte[Assert.CpPart1AssertSize];
            uint offset = 8;
            while (offset < Assert.CpPart1AssertSize)
            {
                var debug = ScriptX.NullTerminatedString(bytePtrT + offset);
                if (debug == null) offset += 1;
                else offset += (uint) debug.Length + 1;
                Map.BinKeys[Bin.Hash(debug)] = debug;
            }

            for (var a1 = 0; a1 < Assert.CpPart1AssertSize; ++a1)
                data[a1] = *(bytePtrT + a1);

            return data;
        }
    }
}