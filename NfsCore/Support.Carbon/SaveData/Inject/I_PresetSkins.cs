using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset skins into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetSkins(Database.CarbonDb db, BinaryWriter bw)
        {
            bw.Write(GlobalId.PresetSkins);
            bw.Write(db.PresetSkins.Length * 0x68);
            foreach (var skin in db.PresetSkins.Collections)
                bw.Write(skin.Assemble());
        }
    }
}