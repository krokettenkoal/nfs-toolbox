using System;
using NfsCore.Reflection.ID;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground1.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles tpk block into a byte array.
        /// </summary>
        /// <returns>Byte array of the tpk block.</returns>
        public override unsafe byte[] Assemble()
        {
            // TPK Check
            CheckKeys();
            CheckComps();
            TextureSort();

            // Partial 1 Block
            var _1_Part1 = Get1Part1();
            var _1_Part2 = Get1Part2();
            var _1_Part4 = Get1Part4();
            var _1_Part5 = Get1Part5();

            // Partial 2 Block
            var _2_Part1 = Get2Part1();
            var _2_Part2 = Get2Part2();

            // Get sizes
            var _1_Size = _1_Part1.Length + _1_Part2.Length + _1_Part4.Length + _1_Part5.Length;
            var _2_Size = _2_Part1.Length + _2_Part2.Length;
            var padding = Resolve.GetPaddingArray(_1_Size + 0x48, 0x80);
            var padSize = padding.Length;

            // All offsets
            const int partialOffset1 = 0x40;
            var partialOffset2 = 0x48 + _1_Size + padSize;

            const int _1_Offset1 = partialOffset1 + 8;
            var _1_Offset2 = _1_Offset1 + _1_Part1.Length;
            var _1_Offset4 = _1_Offset2 + _1_Part2.Length;
            var _1_Offset5 = _1_Offset4 + _1_Part4.Length;
            var paddingOffset = _1_Offset5 + _1_Part5.Length;
            var _2_Offset1 = partialOffset2 + 8;
            var _2_Offset2 = _2_Offset1 + _2_Part1.Length;

            // Initialize .tpk array
            var total = _1_Size + _2_Size + padSize + 0x50;
            var result = new byte[total];

            // Write everything
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = TPK.MAINID;
                *(int*) (bytePtrT + 4) = total - 8;
                *(int*) (bytePtrT + 12) = 0x30;
                *(uint*) (bytePtrT + partialOffset1) = TPK.INFO_BLOCKID;
                *(int*) (bytePtrT + partialOffset1 + 4) = _1_Size;
                *(uint*) (bytePtrT + partialOffset2) = TPK.DATA_BLOCKID;
                *(int*) (bytePtrT + partialOffset2 + 4) = _2_Size;
            }

            Buffer.BlockCopy(_1_Part1, 0, result, _1_Offset1, _1_Part1.Length);
            Buffer.BlockCopy(_1_Part2, 0, result, _1_Offset2, _1_Part2.Length);
            Buffer.BlockCopy(_1_Part4, 0, result, _1_Offset4, _1_Part4.Length);
            Buffer.BlockCopy(_1_Part5, 0, result, _1_Offset5, _1_Part5.Length);
            Buffer.BlockCopy(padding, 0, result, paddingOffset, padSize);
            Buffer.BlockCopy(_2_Part1, 0, result, _2_Offset1, _2_Part1.Length);
            Buffer.BlockCopy(_2_Part2, 0, result, _2_Offset2, _2_Part2.Length);

            return result;
        }
    }
}