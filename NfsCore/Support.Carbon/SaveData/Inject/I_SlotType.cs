﻿using System.Collections.Generic;
using System.IO;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Carbon.Parts.CarParts;

namespace NfsCore.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all slottype into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SlotType(Database.CarbonDb db, BinaryWriter bw)
        {
            var SetList = new List<CarSpoilerType>();

            // Get all cartypeinfos with non-base spoilers
            foreach (var info in db.CarTypeInfos.Collections)
            {
                if (info.Spoiler != eSpoiler.SPOILER || info.SpoilerAS != eSpoilerAS2.SPOILER_AS2)
                {
                    var Class = new CarSpoilerType();
                    Class.CarTypeInfo = info.CollectionName;
                    Class.Spoiler = info.Spoiler;
                    Class.SpoilerAS = info.SpoilerAS;
                    SetList.Add(Class);
                }
            }

            bw.Write(db.SlotTypes.Spoilers.SetSpoilers(SetList));
        }
    }
}