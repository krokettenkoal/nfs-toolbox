using NfsCore.Reflection.ID;

namespace NfsCore.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Decompile entire carparts block into separate elements.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of carparts block in Global data.</param>
        /// <param name="length">Length of the block to be read.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_CarParts(byte* bytePtrT, uint length, Database.MostWantedDb db)
        {
            uint offset = 0;
            var part5PtrT = bytePtrT; // pointer to the part5 of the block
            var part6PtrT = bytePtrT; // pointer to the part6 of the block

            while (offset < length)
            {
                var id = *(uint*) (bytePtrT + offset);
                var size = *(uint*) (bytePtrT + offset + 4);
                if (offset + size > length) return; // in case of reading beyong the stream

                switch (id)
                {
                    case CarParts.Part0:
                        db.SlotTypes.Part0.Data = CPE_Part0(bytePtrT + offset, size + 8);
                        goto default;

                    case CarParts.Part1:
                        db.SlotTypes.Part1.Data = CPE_Part1(bytePtrT + offset, size + 8);
                        goto default;

                    case CarParts.Part2:
                        db.SlotTypes.Part2.Data = CPE_Part2(bytePtrT + offset, size + 8);
                        goto default;

                    case CarParts.Part3:
                        db.SlotTypes.Part3.Data = CPE_Part3(bytePtrT + offset, size + 8);
                        goto default;

                    case CarParts.Part4:
                        db.SlotTypes.Part4.Data = CPE_Part4(bytePtrT + offset, size + 8);
                        goto default;

                    case CarParts.Part5:
                        part5PtrT = bytePtrT + offset;
                        goto default;

                    case CarParts.Part6:
                        part6PtrT = bytePtrT + offset;
                        goto default;

                    default:
                        offset += 8 + size;
                        break;
                }
            }

            // Disassemble part5 and part6
            CPE_Part56(part5PtrT, part6PtrT, db);
        }
    }
}