using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe int[] FindOffsets(byte* bytePtrT)
        {
            var offsets = new[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
            var readerOffset = 8;
            var size = *(int*) (bytePtrT + 4) + 8;

            while (readerOffset < size)
            {
                var readerId = *(uint*) (bytePtrT + readerOffset);
                switch (readerId)
                {
                    case CareerInfo.STRING_BLOCK:
                        offsets[0] = readerOffset;
                        goto default;

                    case CareerInfo.EVENT_BLOCK:
                        offsets[1] = readerOffset;
                        goto default;

                    case CareerInfo.SHOP_BLOCK:
                        offsets[2] = readerOffset;
                        goto default;

                    case CareerInfo.BRAND_BLOCK:
                        offsets[3] = readerOffset;
                        goto default;

                    case CareerInfo.PERF_PACK_BLOCK:
                        offsets[4] = readerOffset;
                        goto default;

                    case CareerInfo.SHOWCASE_BLOCK:
                        offsets[5] = readerOffset;
                        goto default;

                    case CareerInfo.SMS_MESSAGE_BLOCK:
                        offsets[6] = readerOffset;
                        goto default;

                    case CareerInfo.SPONSOR_BLOCK:
                        offsets[7] = readerOffset;
                        goto default;

                    case CareerInfo.STAGE_BLOCK:
                        offsets[8] = readerOffset;
                        goto default;

                    case CareerInfo.TUNING_PERF_BLOCK:
                        offsets[9] = readerOffset;
                        goto default;

                    case CareerInfo.WORLD_CHAL_BLOCK:
                        offsets[10] = readerOffset;
                        goto default;

                    case CareerInfo.PART_UNLOCKS_BLOCK:
                        offsets[11] = readerOffset;
                        goto default;

                    case CareerInfo.BANK_TRIGS_BLOCK:
                        offsets[12] = readerOffset;
                        goto default;

                    case CareerInfo.CAR_UNLOCKS_BLOCK:
                        offsets[13] = readerOffset;
                        goto default;

                    default:
                        readerOffset += 8 + *(int*) (bytePtrT + readerOffset + 4);
                        break;
                }
            }

            return offsets;
        }
    }
}