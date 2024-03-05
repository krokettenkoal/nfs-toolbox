using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteGShowcases(MemoryWriter mw, Database.Underground2Db db)
        {
            var result = new byte[8 + db.GShowcases.Length * 0x40];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.SHOWCASE_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var showcase in db.GShowcases.Collections)
                {
                    showcase.Assemble(bytePtrT + offset, mw);
                    offset += 0x40;
                }
            }

            return result;
        }
    }
}