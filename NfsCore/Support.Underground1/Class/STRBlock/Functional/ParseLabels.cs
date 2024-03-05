using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground1.Class
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
            _size = 0x10 + _unknown.Length + _stringInfo.Count * 8;
            foreach (var info in _stringInfo)
                _size += info.NulledLabelLength;
            var padding = 0x10 - ((_size + 0xC) % 0x10);
            if (padding != 0x10) _size += padding;

            // var mark = "GlobalLib by MaxHwoy " + DateTime.Today.ToString("dd-MM-yyyy");
            _unkDataOffset = 0x10;
            _keyOffset = 0x10 + _labunk.Length;
            _textOffset = 0x10 + _labunk.Length + _stringInfo.Count * 8;

            // Begin writing
            var result = new byte[_size + 8];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write header
                *(uint*) bytePtrT = GlobalId.STRBlocks;
                *(int*) (bytePtrT + 0x4) = _size;
                *(int*) (bytePtrT + 0x8) = _unkDataOffset;
                *(int*) (bytePtrT + 0xC) = _stringInfo.Count;
                *(int*) (bytePtrT + 0x10) = _keyOffset;
                *(int*) (bytePtrT + 0x14) = _textOffset;
                for (var a1 = 0; a1 < _labunk.Length; ++a1)
                    *(bytePtrT + 0x18 + a1) = _labunk[a1];

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