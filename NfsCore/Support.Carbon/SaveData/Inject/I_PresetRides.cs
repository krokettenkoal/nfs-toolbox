using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all preset rides into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_PresetRides(Database.CarbonDb db, BinaryWriter bw)
        {
            bw.Write(GlobalId.PresetRides);
            bw.Write(db.PresetRides.Length * 0x600);
            foreach (var ride in db.PresetRides.Collections)
                bw.Write(ride.Assemble());
        }
    }
}