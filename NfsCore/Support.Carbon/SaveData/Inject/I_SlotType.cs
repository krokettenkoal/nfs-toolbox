using System.IO;
using System.Linq;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Carbon.Parts.CarParts;

namespace NfsCore.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all slot types into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SlotType(Database.CarbonDb db, BinaryWriter bw)
        {
            // Get all cartypeinfos with non-base spoilers
            var setList = (from info in db.CarTypeInfos.Collections
                where info.Spoiler != eSpoiler.SPOILER || info.SpoilerAS != eSpoilerAS2.SPOILER_AS2
                select new CarSpoilerType
                    {CarTypeInfo = info.CollectionName, Spoiler = info.Spoiler, SpoilerAS = info.SpoilerAS}).ToList();

            bw.Write(db.SlotTypes.Spoilers.SetSpoilers(setList));
        }
    }
}