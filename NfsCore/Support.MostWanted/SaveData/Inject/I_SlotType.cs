using System.IO;
using System.Linq;
using NfsCore.Reflection.Enum;
using NfsCore.Support.MostWanted.Parts.CarParts;

namespace NfsCore.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all slottype into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SlotType(Database.MostWantedDb db, BinaryWriter bw)
        {
            // Get all CarTypeInfos with non-base spoilers
            var setList = (from info in db.CarTypeInfos.Collections
                where info.Spoiler != eSpoiler.SPOILER
                select new CarSpoilerType {CarTypeInfo = info.CollectionName, Spoiler = info.Spoiler}).ToList();
            bw.Write(db.SlotTypes.Spoilers.SetSpoilers(setList));
        }
    }
}