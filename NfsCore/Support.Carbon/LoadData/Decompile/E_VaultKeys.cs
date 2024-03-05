using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        private static unsafe void E_VaultKeys(byte* bytePtrT)
        {
            var id = *(uint*) bytePtrT;
            var size = *(int*) (bytePtrT + 4) + 8;
            if (id != 0x53747245) return;

            var offset = 8;
            while (offset < size)
            {
                var collectionName = ScriptX.NullTerminatedString(bytePtrT + offset, size - offset);
                if (collectionName == null)
                {
                    offset += 1;
                    continue;
                }

                var key = Vlt.Hash(collectionName);
                Map.VltKeys[key] = collectionName;
                offset += collectionName.Length + 1;
            }
        }
    }
}