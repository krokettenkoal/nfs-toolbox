using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all car parts into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarParts(Database.Underground2Db db, BinaryWriter bw)
        {
            var part1 = CPI_Part1(db);
            var part2 = CPI_Part2(db);
            var part3 = CPI_Part3(db);
            var part4 = CPI_Part4(db);
            var part56 = CPI_Part56(db);
            var part0 = db.SlotTypes.Part0.Data;

            var size = part0.Length + part1.Length + part2.Length;
            size += part3.Length + part4.Length + part56.Length;

            bw.Write(GlobalId.CarParts);
            bw.Write(size);
            bw.Write(part0);
            bw.Write(part1);
            bw.Write(part2);
            bw.Write(part3);
            bw.Write(part4);
            bw.Write(part56);
        }
    }
}