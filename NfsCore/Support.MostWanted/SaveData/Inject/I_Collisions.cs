using System.IO;
using System.Linq;
using NfsCore.Reflection;
using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all collisions into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static unsafe void I_Collisions(Database.MostWantedDb db, BinaryWriter bw)
        {
            bw.Write(GlobalId.Collisions);
            bw.Write(0xFFFFFFFF); // write temp size
            var initialSize = (int) bw.BaseStream.Position;

            // Copy all collisions by the internal names
            foreach (var info in db.CarTypeInfos.Collections)
            {
                if (info.CollisionExternalName == BaseArguments.NULL) continue;
                var extKey = Vlt.Hash(info.CollisionExternalName);
                var intKey = Vlt.Hash(info.CollisionInternalName);
                if (db.SlotTypes.Collisions.TryGetValue(intKey, out var collision))
                    bw.Write(collision.GetData(extKey));
            }

            // Copy all unknown collisions
            foreach (var collision in db.SlotTypes.Collisions.Where(collision => collision.Value.Unknown))
            {
                bw.Write(collision.Value.GetData(0));
            }

            // Fix size
            bw.BaseStream.Position = initialSize - 4;
            bw.Write((int) bw.BaseStream.Length - initialSize);
            bw.BaseStream.Position = bw.BaseStream.Length;
        }
    }
}