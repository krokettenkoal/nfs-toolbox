using NfsCore.Reflection.ID;
using NfsCore.Support.Shared.Parts.TPKParts;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets list of offset slots of the textures in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part3 offset in the tpk block array.</param>
        protected override unsafe void GetOffsetSlots(byte* bytePtrT, int offset)
        {
            if (offset == -1) return; // if Part3 does not exist
            if (*(uint*) (bytePtrT + offset) != TPK.INFO_PART3_BLOCKID)
                return; // check Part3 ID

            var readerSize = 8 + *(int*) (bytePtrT + offset + 4);
            var current = 8;
            while (current < readerSize)
            {
                var offSlot = new OffSlot
                {
                    Key = *(uint*) (bytePtrT + offset + current),
                    AbsoluteOffset = *(int*) (bytePtrT + offset + current + 4),
                    CompressedSize = *(int*) (bytePtrT + offset + current + 8),
                    ActualSize = *(int*) (bytePtrT + offset + current + 0xC),
                    ToHeaderOffset = *(int*) (bytePtrT + offset + current + 0x10),
                    UnknownInt32 = *(int*) (bytePtrT + offset + current + 0x14)
                };
                _offSlots.Add(offSlot);
                current += 0x18;
            }
        }
    }
}