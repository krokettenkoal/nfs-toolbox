using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        private static unsafe void E_GlobalLibBlock(byte* bytePtrT, uint length)
        {
            var off = 0x50; // offset in data
            var num = 0; // number of strings
            var len = 0; // length of strings

            var blockType = ScriptX.NullTerminatedString(bytePtrT + 0x30, 0x20);

            switch (blockType)
            {
                case "Padding Block":
                    return;

                case "Collision Block":
                    num = *(int*) (bytePtrT + off); // get number of strings allocated
                    len = *(int*) (bytePtrT + off + 4); // get total length of characters
                    off += 8; // move last time
                    Map.CollisionMap.Clear(); // clear collision map
                    while (len > 0 && num > 0)
                    {
                        var collectionName = string.Empty;
                        int numBytes = *(bytePtrT + off); // length of the string
                        for (var a1 = off + 1; a1 < off + 1 + numBytes; ++a1)
                            collectionName += ((char) *(bytePtrT + a1)).ToString();
                        Map.CollisionMap[Vlt.Hash(collectionName)] = collectionName;
                        --num;
                        len -= numBytes + 1;
                        off += numBytes + 1;
                    }

                    _libColBlockExists = true;
                    break;

                case "Raider Block": // suspended, no longer supported
                    num = *(int*) (bytePtrT + off); // get number of strings allocated
                    len = *(int*) (bytePtrT + off + 4); // get total length of characters
                    off += 8; // move last time
                    while (len > 0 && num > 0)
                    {
                        var collectionName = string.Empty;
                        int numBytes = *(bytePtrT + off); // length of the string
                        for (var a1 = off + 1; a1 < off + 1 + numBytes; ++a1)
                            collectionName += ((char) *(bytePtrT + a1)).ToString();
                        Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
                        --num;
                        len -= numBytes + 1;
                        off += numBytes + 1;
                    }

                    break;
            }
        }
    }
}