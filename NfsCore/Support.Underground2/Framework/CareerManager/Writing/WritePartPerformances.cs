using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WritePartPerformances(Database.Underground2Db db)
        {
            var result = new byte[0x2C90]; // max size of perf part block
            var offset = 8; // for calculating offsets

            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.PERF_PACK_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                for (var a1 = 0; a1 < 10; ++a1)
                {
                    for (var a2 = 0; a2 < 3; ++a2)
                    {
                        var count = 0;
                        *(int*) (bytePtrT + offset) = a1;
                        *(int*) (bytePtrT + offset + 4) = a2 + 1;
                        if (Map.PerfPartTable[a1, a2, 0] != 0)
                        {
                            var key = Map.PerfPartTable[a1, a2, 0];
                            var cla = db.PartPerformances.FindCollection(key, eKeyType.BINKEY);
                            cla.Assemble(bytePtrT + offset + 0xC);
                            ++count;
                        }

                        if (Map.PerfPartTable[a1, a2, 1] != 0)
                        {
                            var key = Map.PerfPartTable[a1, a2, 1];
                            var cla = db.PartPerformances.FindCollection(key, eKeyType.BINKEY);
                            cla.Assemble(bytePtrT + offset + 0x68);
                            ++count;
                        }

                        if (Map.PerfPartTable[a1, a2, 2] != 0)
                        {
                            var key = Map.PerfPartTable[a1, a2, 2];
                            var cla = db.PartPerformances.FindCollection(key, eKeyType.BINKEY);
                            cla.Assemble(bytePtrT + offset + 0xC4);
                            ++count;
                        }

                        if (Map.PerfPartTable[a1, a2, 3] != 0)
                        {
                            var key = Map.PerfPartTable[a1, a2, 3];
                            var cla = db.PartPerformances.FindCollection(key, eKeyType.BINKEY);
                            cla.Assemble(bytePtrT + offset + 0x120);
                            ++count;
                        }

                        *(int*) (bytePtrT + offset + 8) = count;
                        offset += 0x17C;
                    }
                }
            }

            return result;
        }
    }
}