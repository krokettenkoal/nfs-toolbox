using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground1.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Assembles string block into a byte array.
        /// </summary>
        /// <returns>Byte array of the string block.</returns>
        public override unsafe byte[] Assemble()
        {
            // Precalculate size
            _size = 0x10 + _unknown.Length + _stringInfo.Count * 8;
            foreach (var info in _stringInfo)
                _size += info.NulledTextLength;
            var padding = 0x10 - (_size % 0x10);
            if (padding != 0x10) _size += padding;

            // var mark = "GlobalLib by MaxHwoy " + DateTime.Today.ToString("dd-MM-yyyy");
            _unkDataOffset = 0x10;
            _keyOffset = 0x10 + _unknown.Length;
            _textOffset = 0x10 + _unknown.Length + _stringInfo.Count * 8;

            // Sort records by keys
            _stringInfo.Sort((a, b) => a.Key.CompareTo(b.Key));

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
                for (var a1 = 0; a1 < _unknown.Length; ++a1)
                    *(bytePtrT + 0x18 + a1) = _unknown[a1];

                // Write hashes and offsets
                var textOff = 0;
                var keyPtrT = bytePtrT + 8 + _keyOffset;
                var textPtrT = bytePtrT + 8 + _textOffset;
                for (var a1 = 0; a1 < _stringInfo.Count; ++a1)
                {
                    *(uint*) (keyPtrT + a1 * 8) = _stringInfo[a1].Key;
                    *(int*) (keyPtrT + a1 * 8 + 4) = textOff;
                    for (var a2 = 0; a2 < _stringInfo[a1].Text.Length; ++a2)
                        *(textPtrT + textOff + a2) = (byte) _stringInfo[a1].Text[a2];
                    textOff += _stringInfo[a1].NulledTextLength;
                }
            }

            return result;
        }
    }
}