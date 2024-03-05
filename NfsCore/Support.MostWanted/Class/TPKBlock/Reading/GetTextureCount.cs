using NfsCore.Reflection.ID;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets amount of textures in the tpk block.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        /// <returns>Number of textures in the tpk block.</returns>
        protected override unsafe int GetTextureCount(byte* bytePtrT, int offset)
        {
            if (offset == -1) return 0; // check if Part2 even exists
            var readerId = *(uint*) (bytePtrT + offset);
            var readerSize = *(int*) (bytePtrT + offset + 4);
            if (readerId != TPK.INFO_PART2_BLOCKID) return 0; // check if ID matches

            return readerSize / 8; // 8 bytes for one texture
        }
    }
}