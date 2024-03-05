using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompiles part1 of CarParts block, extracts all strings and gets the array to memory.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the ID of the part1 of CarParts block.</param>
        /// <param name="length">Lenght of the part1 of CarParts block including ID and size.</param>
        /// <returns>Part1 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part1(byte* bytePtrT, uint length)
        {
            var data = new byte[length];
            uint offset = 8;
            while (offset < length)
            {
                var debug = ScriptX.NullTerminatedString(bytePtrT + offset);
                if (debug == null) offset += 1;
                else offset += (uint) debug.Length + 1;
                Map.BinKeys[Bin.Hash(debug)] = debug;
            }

            fixed (byte* dataPtrT = &data[0])
            {
                for (var a1 = 0; a1 < length; ++a1)
                    *(dataPtrT + a1) = *(bytePtrT + a1);
            }

            return data;
        }
    }
}