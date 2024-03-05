using NfsCore.Reflection.ID;
using NfsCore.Support.Shared.Parts.TPKParts;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground1.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets list of compressions of the textures in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part5 offset in the tpk block array.</param>
        protected override unsafe void GetCompressionList(byte* bytePtrT, int offset)
        {
            if (offset == -1) return; // if Part5 does not exist
            if (*(uint*) (bytePtrT + offset) != TPK.INFO_PART5_BLOCKID)
                return; // check Part5 ID

            var readerSize = 8 + *(int*) (bytePtrT + offset + 4);
            var current = 0x10;
            while (current < readerSize)
            {
                var comp = *(uint*) (bytePtrT + offset + current + 12);
                if (Comp.IsComp(comp))
                {
                    var slot = new CompSlot
                    {
                        var1 = *(int*) (bytePtrT + offset + current),
                        var2 = *(int*) (bytePtrT + offset + current + 4),
                        var3 = *(int*) (bytePtrT + offset + current + 8),
                        comp = comp
                    };
                    _compressions.Add(slot);
                }

                current += 0x20;
            }
        }
    }
}