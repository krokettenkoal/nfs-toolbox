﻿using System.Collections.Generic;
using System.IO;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Underground2.Parts.CarParts;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all slottype into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SlotType(Database.Underground2Db db, BinaryWriter bw)
        {
            var setList = new List<CarSpoilMirrType>();

            // Get all cartypeinfos with non-base spoilers and mirrors
            foreach (var car in db.CarTypeInfos.Collections)
            {
                if (car.Spoiler != eSpoiler.SPOILER)
                {
                    var add = new CarSpoilMirrType
                    {
                        CarTypeInfo = car.CollectionName,
                        Spoiler = car.Spoiler,
                        SpoilerNoMirror = true
                    };
                    setList.Add(add);
                }

                if (car.Mirrors == eMirrorTypes.MIRRORS) continue;
                {
                    var add = new CarSpoilMirrType
                    {
                        CarTypeInfo = car.CollectionName,
                        Mirrors = car.Mirrors,
                        SpoilerNoMirror = false
                    };
                    setList.Add(add);
                }
            }

            bw.Write(db.SlotTypes.SpoilMirrs.SetSpoilMirrs(setList));
        }
    }
}