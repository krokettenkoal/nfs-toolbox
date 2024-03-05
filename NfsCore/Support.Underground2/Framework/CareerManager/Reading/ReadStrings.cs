using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadStrings(byte* bytePtrT, IReadOnlyList<int> partOffsets)
        {
            if (partOffsets[0] == -1) return; // if strings block does not exist
            if (*(uint*) (bytePtrT + partOffsets[0]) != CareerInfo.STRING_BLOCK)
                return; // check strings block ID

            var readerSize = 8 + *(int*) (bytePtrT + partOffsets[0] + 4);
            var current = partOffsets[0] + 8;
            while (current < readerSize)
            {
                var str = ScriptX.NullTerminatedString(bytePtrT + current);
                Bin.Hash(str);
                current += str.Length + 1;
            }
        }
    }
}