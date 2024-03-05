using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteGCareerStages(Database.Underground2Db db)
        {
            var result = new byte[8 + db.GCareerStages.Length * 0x50];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.STAGE_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var stage in db.GCareerStages.Collections)
                {
                    stage.Assemble(bytePtrT + offset);
                    offset += 0x50;
                }
            }

            return result;
        }
    }
}