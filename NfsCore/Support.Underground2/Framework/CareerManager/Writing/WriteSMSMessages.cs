﻿using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe byte[] WriteSMSMessages(MemoryWriter mw, Database.Underground2Db db)
        {
            var result = new byte[8 + db.SMSMessages.Length * 0x14];
            var offset = 8; // for calculating offsets
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = CareerInfo.SMS_MESSAGE_BLOCK; // write ID
                *(int*) (bytePtrT + 4) = result.Length - 8; // write size
                foreach (var message in db.SMSMessages.Collections)
                {
                    message.Assemble(bytePtrT + offset, mw);
                    offset += 0x14;
                }
            }

            return result;
        }
    }
}