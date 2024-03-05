using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Finds offsets of all partials and its parts in the tpk block.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <returns>Array of all offsets.</returns>
        protected override unsafe int[] FindOffsets(byte* bytePtrT)
        {
            var offsets = new[] {-1, -1, -1, -1, -1, -1, -1, -1};
            var readerOffset = 8; // start after ID and size
            uint readerId = 0;
            var infoBlockSize = 0;
            var dataBlockSize = 0;

            while (readerId != TPK.INFO_BLOCKID)
            {
                readerId = *(uint*) (bytePtrT + readerOffset);
                infoBlockSize = *(int*) (bytePtrT + readerOffset + 4);
                if (readerId != TPK.INFO_BLOCKID) readerOffset += infoBlockSize;
                readerOffset += 8;
            }

            infoBlockSize += readerOffset; // relative offset
            while (readerOffset < infoBlockSize)
            {
                readerId = *(uint*) (bytePtrT + readerOffset);
                switch (readerId)
                {
                    case TPK.INFO_PART1_BLOCKID:
                        offsets[0] = readerOffset;
                        goto default;

                    case TPK.INFO_PART2_BLOCKID:
                        offsets[1] = readerOffset;
                        goto default;

                    case TPK.INFO_PART3_BLOCKID:
                        offsets[2] = readerOffset;
                        goto default;

                    case TPK.INFO_PART4_BLOCKID:
                        offsets[3] = readerOffset;
                        goto default;

                    case TPK.INFO_PART5_BLOCKID:
                        offsets[4] = readerOffset;
                        goto default;

                    default:
                        readerOffset += 8 + *(int*) (bytePtrT + readerOffset + 4);
                        break;
                }
            }

            while (readerId != TPK.DATA_BLOCKID)
            {
                readerId = *(uint*) (bytePtrT + readerOffset);
                dataBlockSize = *(int*) (bytePtrT + readerOffset + 4);
                if (readerId != TPK.DATA_BLOCKID) readerOffset += dataBlockSize;
                readerOffset += 8;
            }

            dataBlockSize += readerOffset; // relative offset
            while (readerOffset < dataBlockSize)
            {
                readerId = *(uint*) (bytePtrT + readerOffset);
                switch (readerId)
                {
                    case TPK.DATA_PART1_BLOCKID:
                        offsets[5] = readerOffset;
                        goto default;

                    case TPK.DATA_PART2_BLOCKID:
                        offsets[6] = readerOffset;
                        goto default;

                    case TPK.DATA_PART3_BLOCKID:
                        offsets[7] = readerOffset;
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