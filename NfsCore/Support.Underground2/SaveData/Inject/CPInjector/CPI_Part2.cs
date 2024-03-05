using System.Linq;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        // Thanks to nlgzrgn for helping with this part!)))
        private static byte[] CPI_Part2(Database.Underground2Db db)
        {
            var part2Size = db.SlotTypes.Part2.Data.Length;
            var part3Entries = (db.SlotTypes.Part3.Data.Length - 8) / 8;
            var numAddons = 0;

            // Precalculate size of part2
            foreach (var unused in db.CarTypeInfos.Collections.Where(car =>
                         car.Deletable && car.UsageType == eUsageType.Racer))
            {
                part2Size += 0x11E;
                ++numAddons;
            }

            var padding = 0x10 - ((part2Size + 4) % 0x10);
            if (padding != 0x10) part2Size += padding;

            // Use MemoryWriter instead of BinaryWriter so we can return an array for later processes
            var mw = new MemoryWriter(part2Size);
            mw.Write(db.SlotTypes.Part2.Data);

            // Write all info
            for (var a1 = 0; a1 < numAddons; ++a1)
            {
                // CARNAME_CV - KIT00_BODY
                mw.Write((short) 2);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCB);

                // CARNAME_W01_CV
                mw.Write((short) 2);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);

                // CARNAME_W02_CV
                mw.Write((short) 2);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);

                // CARNAME_W03_CV
                mw.Write((short) 2);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);

                // CARNAME_W04_CV
                mw.Write((short) 2);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);

                // CARNAME_KIT00_HEADLIGHT
                mw.Write((short) 2);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CDC);

                // CARNAME_STYLE01_HEADLIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE04_HEADLIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE10_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE11_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE02_HEADLIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE03_HEADLIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE05_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE08_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE13_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE06_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE07_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE09_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE12_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE14_HEADLIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_KIT00_BRAKELIGHT
                mw.Write((short) 2);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CED);

                // CARNAME_STYLE01_BRAKELIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE04_BRAKELIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE10_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE11_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE02_BRAKELIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE03_BRAKELIGHT
                mw.Write((short) 3);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0CCE);
                mw.Write((short) 0x0CDE);

                // CARNAME_STYLE05_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE08_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE13_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE06_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE07_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE09_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE12_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE14_BRAKELIGHT
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_KIT22_HOOD_UNDER
                mw.Write((short) 2);
                mw.Write((short) part3Entries);
                mw.Write((short) 0x0D03);

                // CARNAME_KIT24_HOOD_UNDER
                mw.Write((short) 2);
                mw.Write((short) (part3Entries + 1));
                mw.Write((short) 0x0D03);

                // CARNAME_KIT23_HOOD_UNDER
                mw.Write((short) 3);
                mw.Write((short) (part3Entries + 2));
                mw.Write((short) 0x0D07);
                mw.Write((short) 0x0D03);

                // CARNAME_KIT25_HOOD_UNDER
                mw.Write((short) 3);
                mw.Write((short) (part3Entries + 3));
                mw.Write((short) 0x0D07);
                mw.Write((short) 0x0D03);

                // CARNAME_KIT21_HOOD_UNDER
                mw.Write((short) 2);
                mw.Write((short) (part3Entries + 4));
                mw.Write((short) 0x0D03);

                // CARNAME_KIT22_HOOD_UNDER CF
                mw.Write((short) 4);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0D0A);
                mw.Write((short) 2);
                mw.Write((short) 0x0D03);

                // CARNAME_KIT24_HOOD_UNDER CF
                mw.Write((short) 4);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0D0B);
                mw.Write((short) 2);
                mw.Write((short) 0x0D03);

                // CARNAME_KIT23_HOOD_UNDER CF
                mw.Write((short) 5);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0D07);
                mw.Write((short) 0x0D0C);
                mw.Write((short) 2);
                mw.Write((short) 0x0D03);

                // CARNAME_KIT25_HOOD_UNDER CF
                mw.Write((short) 5);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0D07);
                mw.Write((short) 0x0D0D);
                mw.Write((short) 2);
                mw.Write((short) 0x0D03);

                // CARNAME_KIT21_HOOD_UNDER CF
                mw.Write((short) 4);
                mw.Write((short) part3Entries++);
                mw.Write((short) 0x0D0E);
                mw.Write((short) 2);
                mw.Write((short) 0x0D03);

                // CARNAME_ENGINE
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE01_ENGINE
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);

                // CARNAME_STYLE02_ENGINE
                mw.Write((short) 1);
                mw.Write((short) part3Entries++);
            }

            // Fix length in the header
            mw.Position = 4;
            mw.Write(mw.Length - 8);
            return mw.Data;
        }
    }
}