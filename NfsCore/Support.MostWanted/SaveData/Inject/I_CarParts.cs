using System.Collections.Generic;
using System.IO;
using System.Linq;
using NfsCore.Reflection.ID;
using NfsCore.Support.MostWanted.Parts.CarParts;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all car parts into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_CarParts(Database.MostWantedDb db, BinaryWriter bw)
        {
            bw.Write(GlobalId.CarParts);
            bw.Write(0xFFFFFFFF); // temp size

            var initialSize = (int) bw.BaseStream.Position;
            var carIdOffset = initialSize + 0x30;
            var partNumOffset = initialSize + 0x40;
            var padding = 0;

            var keys = new List<uint>();
            var usedPart56 = new List<Part56>();

            // Copy for processing
            var interMid56 = db.SlotTypes.Part56.Select(t => t.MemoryCast()).ToList();

            // Go through all cartypeinfo, set correct usagetype and keys
            foreach (var car in db.CarTypeInfos.Collections)
            {
                var carDoesExist = false;
                var index = 0;
                var collectionName = car.CollectionName;
                var cKey = car.BinKey;
                var oKey = Bin.Hash(car.OriginalName);
                keys.Add(cKey);
                for (index = 0; index < interMid56.Count; ++index)
                {
                    if (oKey != interMid56[index].Key) continue;
                    carDoesExist = true;
                    break;
                }

                if (carDoesExist)
                {
                    if (cKey != oKey || car.Modified)
                        interMid56[index] = new Part56(collectionName, (byte) index);
                }
                else
                {
                    var part = new Part56(collectionName, (byte) index);
                    interMid56.Add(part);
                }
            }

            // Make new list of only used Part56 to write
            byte currentLength = 0;
            foreach (var t in interMid56.Where(t => !t.IsCar || keys.Contains(t.Key)))
            {
                t.SetIndex(currentLength++);
                usedPart56.Add(t);
            }

            // Write parts 1-4
            bw.Write(db.SlotTypes.Part0.Data);
            bw.Write(db.SlotTypes.Part1.Data);
            bw.Write(db.SlotTypes.Part2.Data);
            bw.Write(db.SlotTypes.Part3.Data);
            bw.Write(db.SlotTypes.Part4.Data);

            // Write part 5
            var part5Size = usedPart56.Count * 4;
            padding = 3 - usedPart56.Count % 4;
            if (padding != 0) part5Size += padding * 4;
            bw.Write(CarParts.Part5);
            bw.Write(part5Size);
            foreach (var p in usedPart56)
                bw.Write(p.Key);

            for (var a1 = 0; a1 < padding * 4; ++a1)
                bw.Write((byte) 0);

            // Write part 6
            var part6Size = 0;
            bw.Write(CarParts.Part6);
            var size6Off = (int) bw.BaseStream.Position;
            bw.Write(0xFFFFFFFF); // temp size
            foreach (var t in usedPart56)
            {
                bw.Write(t.Data);
                part6Size += t.Data.Length;
            }

            padding = 0x10 - ((part6Size + 8) % 0x10);
            if (padding == 0x10) padding = 0;
            for (var a1 = 0; a1 < padding; ++a1)
                bw.Write((byte) 0);
            part6Size += padding;
            bw.BaseStream.Position = size6Off;
            bw.Write(part6Size);

            // Quick editing
            bw.BaseStream.Position = carIdOffset;
            bw.Write(usedPart56.Count);
            bw.BaseStream.Position = partNumOffset;
            bw.Write(part6Size / 0xE);
            bw.BaseStream.Position = initialSize - 4;
            bw.Write((int) bw.BaseStream.Length - initialSize);
            bw.BaseStream.Position = bw.BaseStream.Length;
        }
    }
}