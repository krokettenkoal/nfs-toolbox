using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all tracks into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_Tracks(Database.Underground2 db, BinaryWriter bw)
        {
            I_GlobalLibBlock(bw);
            bw.Write(GlobalId.Tracks);
            bw.Write(db.Tracks.Length * 0x128);
            foreach (var track in db.Tracks.Collections)
                bw.Write(track.Assemble());
        }
    }
}