﻿using NfsCore.Reflection;
using NfsCore.Reflection.ID;
using NfsCore.Support.Shared.Parts.STRParts;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
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
            // Run through file
            var readerOffset = 0;
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
                        CollectionName = BaseArguments.GLOBAL;
                    }
                }

                readerOffset += 8 + blockSize;
            }

            // Check if string block exists
            if (_offset == -1 || _size == -1) return;

            // Advance position and read through header
            bytePtrT += _offset + 8;
            _numEntries = *(int*) (bytePtrT);
            _keyOffset = *(int*) (bytePtrT + 4);
            _textOffset = *(int*) (bytePtrT + 8);
            _category = ScriptX.NullTerminatedString(bytePtrT + 12, 0x10);

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