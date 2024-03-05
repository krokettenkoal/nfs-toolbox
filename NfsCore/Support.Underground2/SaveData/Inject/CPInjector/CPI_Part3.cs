using System.Linq;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Underground2.Parts.CarParts;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        // Thanks to nlgzrgn for helping with this part!)))
        private static byte[] CPI_Part3(Database.Underground2Db db)
        {
            // Precalculate size of part3
            var part3Size = db.SlotTypes.Part3.Data.Length;
            var cars = (from car in db.CarTypeInfos.Collections
                where car.Deletable && car.UsageType == eUsageType.Racer
                select car.CollectionName).ToList();
            part3Size += cars.Count * 0x158;
            var padding = 0x10 - ((part3Size + 8) % 0x10);
            if (padding != 0x10) part3Size += padding;

            // Use MemoryWriter instead of BinaryWriter so we can return an array for later processes
            var mw = new MemoryWriter(part3Size);
            mw.Write(db.SlotTypes.Part3.Data);

            const uint key1 = 0x10C98090; // ???
            const uint key2 = 0x0D4B85C7; // HOODUNDER

            // Write all info
            foreach (var name in cars)
            {
                for (var a1 = 0; a1 < 0x2B; ++a1)
                {
                    mw.Write(a1 is > 34 and < 40 ? key2 : key1);
                    mw.Write(Bin.Hash(name + UsageType.SpecPartNames[a1]));
                }
            }

            // Fix length in the header
            mw.Position = 4;
            mw.Write(mw.Length - 8);
            db.SlotTypes.Part0.SetRecordNumber((mw.Length - 8) / 8);
            return mw.Data;
        }
    }
}