namespace NfsCore.Support.MostWanted.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Reads .dds data from the tpk block.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block.</param>
        /// <param name="offset">Data offset from where to read.</param>
        /// <param name="forced">If forced, ignores internal offset and reads data 
        /// starting at the pointer passed.</param>
        public override unsafe void ReadData(byte* bytePtrT, int offset, bool forced)
        {
            // Initialize data
            var total = PaletteSize + Size;
            Data = new byte[total];
            fixed (byte* dataPtrT = &Data[0])
            {
                // Copy data using pointers
                if (forced)
                {
                    for (var a1 = 0; a1 < total; ++a1)
                        *(dataPtrT + a1) = *(bytePtrT + offset + a1);
                }
                else
                {
                    for (var a1 = 0; a1 < PaletteSize; ++a1)
                        *(dataPtrT + a1) = *(bytePtrT + offset + PaletteOffset + a1);
                    for (var a1 = 0; a1 < Size; ++a1)
                        *(dataPtrT + PaletteSize + a1) = *(bytePtrT + offset + Offset + a1);
                }
            }
        }
    }
}