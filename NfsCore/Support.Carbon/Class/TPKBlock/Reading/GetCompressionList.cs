using NfsCore.Reflection.ID;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
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
            var current = 0x14;
            while (current < readerSize)
            {
                var comp = *(uint*) (bytePtrT + offset + current);
                if (Comp.IsComp(comp))
                    _compressions.Add(comp);
                current += 0x18;
            }
        }
    }
}