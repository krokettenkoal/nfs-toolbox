using System.Collections.Generic;
using System.IO;
using System.Linq;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.MostWanted
{
    public static partial class SaveData
    {
        private static unsafe void I_CollisionLibBlock(Database.MostWantedDb db, BinaryWriter bw)
        {
            var colSize = 0;
            var padding = 0;

            // Collision Block
            var collisionsUsed = new List<string>();
            foreach (var info in db.CarTypeInfos.Collections.Where(info =>
                         info.CollisionExternalName != BaseArguments.NULL))
            {
                if (info.CollisionExternalName != info.CollisionInternalName)
                {
                    collisionsUsed.Add(info.CollisionInternalName);
                    colSize += info.CollisionInternalName.Length + 1;
                }
                else
                {
                    collisionsUsed.Add(info.CollisionExternalName);
                    colSize += info.CollisionExternalName.Length + 1;
                }
            }

            padding = 0x80 - (((int) bw.BaseStream.Length + colSize + 0x98) % 0x80);
            if (padding == 0x80) padding = 0;
            var colData = new byte[0x58];
            fixed (byte* bytePtrT = &colData[0])
            {
                *(int*) (bytePtrT + 4) = colSize + 0x50 + padding;
                *(uint*) (bytePtrT + 8) = GlobalId.GlobalLib;
                const string colBlock = "Collision Block";
                var libDescription = Process.Watermark;
                for (var a1 = 0; a1 < libDescription.Length; ++a1)
                    *(bytePtrT + 0x10 + a1) = (byte) libDescription[a1];
                for (var a1 = 0; a1 < colBlock.Length; ++a1)
                    *(bytePtrT + 0x30 + a1) = (byte) colBlock[a1];
                *(int*) (bytePtrT + 0x50) = collisionsUsed.Count;
                *(int*) (bytePtrT + 0x54) = colSize;
            }

            bw.Write(colData);
            foreach (var c in collisionsUsed)
                bw.Write(c);

            for (var a1 = 0; a1 < padding; ++a1)
                bw.Write((byte) 0);
        }
    }
}