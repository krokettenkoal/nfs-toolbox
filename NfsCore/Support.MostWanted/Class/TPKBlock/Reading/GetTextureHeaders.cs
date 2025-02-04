﻿using System.Collections.Generic;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets list of offsets and sizes of the texture headers in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part4 offset in the tpk block array.</param>
        /// <returns>Array of offsets and sizes of texture headers.</returns>
        protected override unsafe int[,] GetTextureHeaders(byte* bytePtrT, int offset)
        {
            if (*(uint*) (bytePtrT + offset) != TPK.INFO_PART4_BLOCKID)
                return null; // check Part4 ID

            var readerSize = offset + 8 + *(int*) (bytePtrT + offset + 4);
            var offsets = new List<int>();
            var sizes = new List<int>();
            offset += 8;

            while (offset < readerSize)
            {
                offsets.Add(offset); // add offset
                sizes.Add(0x7C); // constant size
                offset += 0x7C;
            }

            var result = new int[offsets.Count, 2];
            for (var a1 = 0; a1 < offsets.Count; ++a1)
            {
                result[a1, 0] = offsets[a1];
                result[a1, 1] = sizes[a1];
            }

            return result;
        }
    }
}