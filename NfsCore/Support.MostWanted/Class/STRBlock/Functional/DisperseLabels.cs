using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Disassembles labels block array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the label block array.</param>
        /// <param name="length">The length of the string block</param>
        protected override unsafe void DisperseLabels(byte* bytePtrT, int length)
        {
            var readerOffset = 0;
            var found = false;

            // Run through file
            while (readerOffset < length)
            {
                var readerId = *(uint*) (bytePtrT + readerOffset);
                var blockSize = *(int*) (bytePtrT + readerOffset + 4);
                if (!found && readerId == GlobalId.STRBlocks)
                {
                    _offset = readerOffset;
                    _size = blockSize;
                    found = true;
                }

                readerOffset += 8 + blockSize;
            }

            // Check if string block exists
            if (_offset == -1 || _size == -1) return;

            // Initialize map with keys and indexes
            var keyToIndex = new Dictionary<uint, int>();
            for (var a1 = 0; a1 < _stringInfo.Count; ++a1)
                keyToIndex[_stringInfo[a1].Key] = a1;

            // Advance position and read through header
            bytePtrT += _offset + 8;
            _unkDataOffset = *(int*) bytePtrT;
            _numEntries = *(int*) (bytePtrT + 4);
            _keyOffset = *(int*) (bytePtrT + 8);
            _textOffset = *(int*) (bytePtrT + 12);

            // Get unknown data into memory
            _labunk = new byte[_keyOffset - _unkDataOffset];
            for (var a1 = 0; a1 < _labunk.Length; ++a1)
                _labunk[a1] = *(bytePtrT + _unkDataOffset + a1);

            // Begin reading through string records
            for (var a1 = 0; a1 < _numEntries; ++a1)
            {
                var key = *(uint*) (bytePtrT + _keyOffset + a1 * 8);
                var pos = _textOffset + *(int*) (bytePtrT + _keyOffset + a1 * 8 + 4);
                var label = ScriptX.NullTerminatedString(bytePtrT + pos);
                if (keyToIndex.TryGetValue(key, out var index))
                    _stringInfo[index].Label = label;
            }
        }
    }
}