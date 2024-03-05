using System.Collections.Generic;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        public unsafe byte[] GetCarSkins(int index = 0xFF)
        {
            // Precalculate size of the array first
            var skinsUsed = new List<byte>();
            if (AvailableSkinNumbers01 > 0) skinsUsed.Add(1);
            if (AvailableSkinNumbers02 > 0) skinsUsed.Add(2);
            if (AvailableSkinNumbers03 > 0) skinsUsed.Add(3);
            if (AvailableSkinNumbers04 > 0) skinsUsed.Add(4);
            if (AvailableSkinNumbers05 > 0) skinsUsed.Add(5);
            if (AvailableSkinNumbers06 > 0) skinsUsed.Add(6);
            if (AvailableSkinNumbers07 > 0) skinsUsed.Add(7);
            if (AvailableSkinNumbers08 > 0) skinsUsed.Add(8);
            if (AvailableSkinNumbers09 > 0) skinsUsed.Add(9);
            if (AvailableSkinNumbers10 > 0) skinsUsed.Add(10);
            if (skinsUsed.Count == 0) return null;

            var result = new byte[0x40 * skinsUsed.Count];
            fixed (byte* bytePtrT = &result[0])
            {
                var offset = 0;
                foreach (var skin in skinsUsed)
                {
                    switch (skin)
                    {
                        case 1:
                            CARSKIN01.Write(bytePtrT + offset, index, 1);
                            goto default;
                        case 2:
                            CARSKIN02.Write(bytePtrT + offset, index, 2);
                            goto default;
                        case 3:
                            CARSKIN03.Write(bytePtrT + offset, index, 3);
                            goto default;
                        case 4:
                            CARSKIN04.Write(bytePtrT + offset, index, 4);
                            goto default;
                        case 5:
                            CARSKIN05.Write(bytePtrT + offset, index, 5);
                            goto default;
                        case 6:
                            CARSKIN06.Write(bytePtrT + offset, index, 6);
                            goto default;
                        case 7:
                            CARSKIN07.Write(bytePtrT + offset, index, 7);
                            goto default;
                        case 8:
                            CARSKIN08.Write(bytePtrT + offset, index, 8);
                            goto default;
                        case 9:
                            CARSKIN09.Write(bytePtrT + offset, index, 9);
                            goto default;
                        case 10:
                            CARSKIN10.Write(bytePtrT + offset, index, 10);
                            goto default;
                        default:
                            offset += 0x40;
                            break;
                    }
                }
            }

            return result;
        }
    }
}