using System;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Carbon.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Assembles labels block into a byte array.
        /// </summary>
        /// <returns>Byte array of the labels block.</returns>
        public override unsafe byte[] ParseLabels()
        {
            // Precalculate size
            _size = 0x3C + _stringInfo.Count * 8;
            foreach (var info in _stringInfo)
                _size += info.NulledLabelLength;
            var padding = 0x10 - ((_size + 8) % 0x10);
            if (padding >= 0xC) _size += 4 + padding - 0x10;
            else _size += 4 + padding;

            var mark = "NfsCore by MaxHwoy & krokettenkoal " + DateTime.Today.ToString("dd-MM-yyyy");
            _keyOffset = 0x3C;
            _textOffset = 0x3C + _stringInfo.Count * 8;

            // Begin writing
            var result = new byte[_size + 8];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write header
                *(uint*) bytePtrT = GlobalId.STRBlocks;
                *(int*) (bytePtrT + 0x4) = _size;
                *(int*) (bytePtrT + 0x8) = _stringInfo.Count;
                *(int*) (bytePtrT + 0xC) = _keyOffset;
                *(int*) (bytePtrT + 0x10) = _textOffset;
                for (var a1 = 0; a1 < _category.Length; ++a1)
                    *(bytePtrT + 0x14 + a1) = (byte) _category[a1];
                for (var a1 = 0; a1 < mark.Length; ++a1)
                    *(bytePtrT + 0x24 + a1) = (byte) mark[a1];

                // Write hashes and offsets
                var textOff = 0;
                var keyPtrT = bytePtrT + 8 + _keyOffset;
                var textPtrT = bytePtrT + 8 + _textOffset;
                for (var a1 = 0; a1 < _stringInfo.Count; ++a1)
                {
                    *(uint*) (keyPtrT + a1 * 8) = _stringInfo[a1].Key;
                    *(int*) (keyPtrT + a1 * 8 + 4) = textOff;
                    for (var a2 = 0; a2 < _stringInfo[a1].Label.Length; ++a2)
                        *(textPtrT + textOff + a2) = (byte) _stringInfo[a1].Label[a2];
                    textOff += _stringInfo[a1].NulledLabelLength;
                }
            }

            return result;
        }
    }
}