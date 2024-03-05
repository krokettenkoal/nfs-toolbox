using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Disassembles labels block array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the label block array.</param>
        /// <param name="length">The length of the label block</param>
        protected override unsafe void DisperseLabels(byte* bytePtrT, int length)
        {
            var readerOffset = 0;

            // Run through file
            while (readerOffset < length)
            {
                var readerId = *(uint*) (bytePtrT + readerOffset);
                var blockSize = *(int*) (bytePtrT + readerOffset + 4);
                if (readerId == GlobalId.STRBlocks)
                {
                    var category = ScriptX.NullTerminatedString(bytePtrT + readerOffset + 20, 0x10);
                    if (category == "Global")
                    {
                        _offset = readerOffset;
                        _size = blockSize;
                    }
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
            _numEntries = *(int*) (bytePtrT);
            _keyOffset = *(int*) (bytePtrT + 4);
            _textOffset = *(int*) (bytePtrT + 8);
            _category = ScriptX.NullTerminatedString(bytePtrT + 12, 0x10);

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