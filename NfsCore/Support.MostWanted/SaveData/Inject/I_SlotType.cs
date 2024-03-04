using System.Collections.Generic;
using System.IO;
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
            var SetList = new List<CarSpoilerType>();

            // Get all cartypeinfos with non-base spoilers
            foreach (var info in db.CarTypeInfos.Collections)
            {
                if (info.Spoiler != eSpoiler.SPOILER)
                {
                    var Class = new CarSpoilerType();
                    Class.CarTypeInfo = info.CollectionName;
                    Class.Spoiler = info.Spoiler;
                    SetList.Add(Class);
                }
            }

            bw.Write(db.SlotTypes.Spoilers.SetSpoilers(SetList));
        }
    }
}