using System.IO;
using NfsCore.Global;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Carbon
{
    public static partial class SaveData
    {
        private static unsafe void I_GlobalLibBlock(BinaryWriter bw)
        {
            var padding = 0x80 - (((int) bw.BaseStream.Length + 0x50) % 0x80);
            if (padding == 0x80) padding = 0;

            var data = new byte[0x50 + padding];
            fixed (byte* bytePtrT = &data[0])
            {
                *(int*) (bytePtrT + 4) = 0x48 + padding;
                *(uint*) (bytePtrT + 8) = GlobalId.GlobalLib;
                const string padBlock = "Padding Block";
                var libDescription = Process.Watermark;
                for (var a1 = 0; a1 < libDescription.Length; ++a1)
                    *(bytePtrT + 0x10 + a1) = (byte) libDescription[a1];
                for (var a1 = 0; a1 < padBlock.Length; ++a1)
                    *(bytePtrT + 0x30 + a1) = (byte) padBlock[a1];
            }

            bw.Write(data);
        }
    }
}