using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all sun infos into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SunInfos(Database.Underground2Db db, BinaryWriter bw)
        {
            I_GlobalLibBlock(bw);
            bw.Write(GlobalId.SunInfos);
            bw.Write(db.SunInfos.Length * 0x110 + 8);
            bw.Write(0x1111111111111111);
            foreach (var sunInfo in db.SunInfos.Collections)
                bw.Write(sunInfo.Assemble());
        }
    }
}