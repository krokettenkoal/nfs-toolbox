﻿using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all cartypeinfo into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarTypeInfo(Database.MostWantedDb db, BinaryWriter bw)
        {
            var index = 0;
            bw.Write(GlobalId.CarTypeInfo);
            bw.Write(db.CarTypeInfos.Length * 0xD0 + 8);
            bw.Write(0x1111111111111111);
            foreach (var car in db.CarTypeInfos.Collections)
            {
                car.Index = index++;
                bw.Write(car.Assemble());
            }
        }
    }
}