using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WritePerfSliderTunings(Database.Underground2Db db)
        {
            var result = new byte[8 + db.PerfSliderTunings.Length * 0x18];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.TUNING_PERF_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var slider in db.PerfSliderTunings.Collections)
                {
                    slider.Assemble(bytePtrT + offset);
                    offset += 0x18;
                }
            }

            return result;
        }
    }
}