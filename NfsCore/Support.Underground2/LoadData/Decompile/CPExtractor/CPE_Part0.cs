﻿using System.IO;
using NfsCore.Support.Underground2.Framework;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies entire part0 of CarParts block into memory.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the ID of the part0 of CarParts block.</param>
        /// <param name="length">Length of part 3 of the CarParts block including ID and size.</param>
        /// <returns>Part0 data as a byte array.</returns>
        private static unsafe byte[] CPE_Part0(byte* bytePtrT, uint length)
        {
            if (length < Assert.CpPart0AssertSize)
                throw new FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            var data = new byte[Assert.CpPart0AssertSize];
            for (var a1 = 0; a1 < Assert.CpPart0AssertSize; ++a1)
                data[a1] = *(bytePtrT + a1);

            return data;
        }
    }
}