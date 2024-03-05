using System;
using System.Collections.Generic;
using System.Linq;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Parts.CarParts;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        private static byte[] CPI_Part56(Database.Underground2Db db)
        {
            // Part56 list that is used for intermediate calculations

            // Actual used Part56 list
            var usedPart56 = new List<Part56>();

            // This will be used in writing new car parts
            var entries = (db.SlotTypes.Part4.Data.Length - 8) / 0x24;
            var racers = 0;
            var trafficCars = 0;

            // MemoryCast all Part56 for processing
            var interMid56 = db.SlotTypes.Part56.Select(t => t.MemoryCast()).ToList();

            // Go through all cartypeinfo, set correct usagetype and keys
            foreach (var car in db.CarTypeInfos.Collections.Where(car => car.Deletable))
            {
                // If car is new and uses its own auto-generated carparts
                interMid56.Add(new Part56(car.CollectionName, car.UsageType, entries, racers, trafficCars));
                switch (car.UsageType)
                {
                    case eUsageType.Traffic:
                        ++trafficCars;
                        break;
                    case eUsageType.Racer:
                        ++racers;
                        break;
                    case eUsageType.Cop:
                        break;
                    case eUsageType.Wheels:
                        break;
                    case eUsageType.Universal:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // Make new list of only used Part56 to write
            var part6Size = 8;
            byte currentLength = 0;
            foreach (var _56 in interMid56.Where(_56 =>
                         !_56.IsCar || db.CarTypeInfos.TryGetCollectionIndex(_56.BelongsTo, out _)))
            {
                _56.SetIndex(currentLength++);
                usedPart56.Add(_56);
                part6Size += _56.Data.Length;
            }

            // Precalculate size of Part5
            var part5Size = 8 + usedPart56.Count * 4;
            var padding = 0x10 - ((part5Size + 0xC) % 0x10);
            if (padding != 0x10) part5Size += padding;

            // Write data to Part0
            db.SlotTypes.Part0.SetPartsNumber((part6Size - 8) / 0xE);
            db.SlotTypes.Part0.SetCarsNumber(usedPart56.Count);

            // Precalculate size of Part6
            padding = 0x10 - ((part6Size + 0x4) % 0x10);
            if (padding != 0x10) part6Size += padding;

            // Write all info
            var mw = new MemoryWriter(part5Size + part6Size);
            mw.Write(CarParts.Part5);
            mw.Write(part5Size - 8);
            foreach (var _56 in usedPart56)
                mw.Write(_56.Key);
            mw.Position = part5Size;
            mw.Write(CarParts.Part6);
            mw.Write(part6Size - 8);
            foreach (var _56 in usedPart56)
                mw.Write(_56.Data);

            return mw.Data;
        }
    }
}