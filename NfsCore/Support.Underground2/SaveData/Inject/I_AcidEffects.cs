using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all acid effects into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_AcidEffects(Database.Underground2Db db, BinaryWriter bw)
        {
            I_GlobalLibBlock(bw);
            bw.Write(GlobalId.AcidEffects);
            bw.Write(db.AcidEffects.Length * 0xD0 + 0x18);
            bw.Write(0x1111111111111111);
            bw.Write((long)0);
            bw.Write(6);
            bw.Write(db.AcidEffects.Length);

            foreach (var acid in db.AcidEffects.Collections)
                bw.Write(acid.Assemble());
        }
    }
}