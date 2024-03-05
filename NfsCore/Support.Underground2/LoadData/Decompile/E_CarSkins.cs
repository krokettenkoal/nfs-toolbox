using System.Collections.Generic;
using NfsCore.Support.Underground2.Parts.CarParts;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        private static unsafe void E_CarSkins(byte* bytePtrT, uint length, Database.Underground2Db db)
        {
            const uint size = 0x40;
            var map = new Dictionary<int, string>();

            foreach (var car in db.CarTypeInfos.Collections)
                map[car.Index] = car.CollectionName;

            for (uint loop = 0; loop < length / size; ++loop)
            {
                var offset = loop * size;
                var reader = new CarSkin();
                reader.Read(bytePtrT + offset, out var id, out var index);
                var car = db.CarTypeInfos.FindCollection(map[id]);
                if (car == null) continue;

                switch (index)
                {
                    case 1:
                        car.CARSKIN01 = reader;
                        break;
                    case 2:
                        car.CARSKIN02 = reader;
                        break;
                    case 3:
                        car.CARSKIN03 = reader;
                        break;
                    case 4:
                        car.CARSKIN04 = reader;
                        break;
                    case 5:
                        car.CARSKIN05 = reader;
                        break;
                    case 6:
                        car.CARSKIN06 = reader;
                        break;
                    case 7:
                        car.CARSKIN07 = reader;
                        break;
                    case 8:
                        car.CARSKIN08 = reader;
                        break;
                    case 9:
                        car.CARSKIN09 = reader;
                        break;
                    case 10:
                        car.CARSKIN10 = reader;
                        break;
                }
            }
        }
    }
}