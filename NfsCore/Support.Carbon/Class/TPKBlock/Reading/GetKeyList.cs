namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets list of keys of the textures in the tpk block array.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part2 offset in the tpk block array.</param>
        protected override unsafe void GetKeyList(byte* bytePtrT, int offset)
        {
            var readerSize = 8 + *(int*) (bytePtrT + offset + 4);
            var current = 8;
            while (current < readerSize)
            {
                _keys.Add(*(uint*) (bytePtrT + offset + current));
                current += 8;
            }
        }
    }
}