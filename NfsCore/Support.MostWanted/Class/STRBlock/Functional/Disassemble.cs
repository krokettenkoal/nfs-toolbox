using NfsCore.Reflection;
using NfsCore.Reflection.ID;
using NfsCore.Support.Shared.Parts.STRParts;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Disassembles string block array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the string block array.</param>
        /// <param name="length">The length of the string block</param>
        protected override unsafe void Disassemble(byte* bytePtrT, int length)
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
                    CollectionName = BaseArguments.GLOBAL;
                    found = true;
                }

                readerOffset += 8 + blockSize;
            }

            // Check if string block exists
            if (_offset == -1 || _size == -1) return;

            // Advance position and read through header
            bytePtrT += _offset + 8;
            _unkDataOffset = *(int*) bytePtrT;
            _numEntries = *(int*) (bytePtrT + 4);
            _keyOffset = *(int*) (bytePtrT + 8);
            _textOffset = *(int*) (bytePtrT + 12);

            // Get unknown data into memory
            _unknown = new byte[_keyOffset - _unkDataOffset];
            for (var a1 = 0; a1 < _unknown.Length; ++a1)
                _unknown[a1] = *(bytePtrT + _unkDataOffset + a1);

            // Begin reading through string records
            for (var a1 = 0; a1 < _numEntries; ++a1)
            {
                var info = new StringRecord(this)
                {
                    Key = *(uint*) (bytePtrT + _keyOffset + a1 * 8)
                };
                var pos = _textOffset + *(int*) (bytePtrT + _keyOffset + a1 * 8 + 4);
                info.Text = ScriptX.NullTerminatedString(bytePtrT + pos);
                _stringInfo.Add(info);
            }
        }
    }
}