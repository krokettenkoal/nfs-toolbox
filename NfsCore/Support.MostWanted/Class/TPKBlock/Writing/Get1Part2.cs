using NfsCore.Reflection.ID;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 1 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part2.</returns>
        protected override unsafe byte[] Get1Part2()
        {
            var result = new byte[8 + _keys.Count * 8];
            fixed (byte* bytePtrT = &result[8])
            {
                *(uint*) (bytePtrT - 8) = TPK.INFO_PART2_BLOCKID; // write ID
                *(int*) (bytePtrT - 4) = _keys.Count * 8; // write size
                for (var a1 = 0; a1 < _keys.Count; ++a1)
                    *(uint*) (bytePtrT + a1 * 8) = _keys[a1];
            }

            return result;
        }
    }
}