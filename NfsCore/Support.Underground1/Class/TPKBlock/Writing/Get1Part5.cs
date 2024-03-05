using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground1.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 1 part5 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part5.</returns>
        protected override unsafe byte[] Get1Part5()
        {
            var result = new byte[8 + _keys.Count * 0x20];
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = TPK.INFO_PART5_BLOCKID; // write ID
                *(int*) (bytePtrT + 4) = _keys.Count * 0x20; // write size
                for (var a1 = 0; a1 < _keys.Count; ++a1)
                {
                    *(int*) (bytePtrT + 0x10 + a1 * 0x20) = _compressions[a1].var1;
                    *(int*) (bytePtrT + 0x14 + a1 * 0x20) = _compressions[a1].var2;
                    *(int*) (bytePtrT + 0x18 + a1 * 0x20) = _compressions[a1].var3;
                    *(uint*) (bytePtrT + 0x1C + a1 * 0x20) = _compressions[a1].comp;
                }
            }

            return result;
        }
    }
}