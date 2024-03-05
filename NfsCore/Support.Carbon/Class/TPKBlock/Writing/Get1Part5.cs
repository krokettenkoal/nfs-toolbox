using NfsCore.Reflection.ID;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 1 part5 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part5.</returns>
        protected override unsafe byte[] Get1Part5()
        {
            var result = new byte[8 + _keys.Count * 0x18];
            fixed (byte* bytePtrT = &result[0x14])
            {
                *(uint*) (bytePtrT - 0x14) = TPK.INFO_PART5_BLOCKID; // write ID
                *(int*) (bytePtrT - 0x10) = _keys.Count * 0x18; // write size
                for (var a1 = 0; a1 < _keys.Count; ++a1)
                    *(uint*) (bytePtrT + a1 * 0x18) = _compressions[a1];
            }

            return result;
        }
    }
}