﻿using System;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 1 part4 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part4.</returns>
        protected override unsafe byte[] Get1Part4()
        {
            var result = new byte[8 + _keys.Count * 0x7C]; // later resize
            var offHeader = 8; // for calculating header offsets
            var offData = 0; // for calculating data offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = TPK.INFO_PART4_BLOCKID; // write ID
                for (var a1 = 0; a1 < _keys.Count; ++a1)
                {
                    Textures[a1].Assemble(bytePtrT, ref offHeader, ref offData);
                }

                *(int*) (bytePtrT + 4) = offHeader - 8; // write size
            }

            Array.Resize(ref result, offHeader);
            return result;
        }
    }
}