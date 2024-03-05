using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground1.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 2 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part1.</returns>
        protected override unsafe byte[] Get2Part1()
        {
            var result = new byte[0x78];
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = TPK.DATA_PART1_BLOCKID; // write ID
                *(int*) (bytePtrT + 4) = 0x18; // write size
                *(int*) (bytePtrT + 0x10) = 1;
                *(uint*) (bytePtrT + 0x14) = FilenameHash;
                *(int*) (bytePtrT + 0x24) = 0x50;
            }

            return result;
        }
    }
}