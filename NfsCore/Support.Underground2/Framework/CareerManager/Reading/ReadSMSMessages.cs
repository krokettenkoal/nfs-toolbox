using System.Collections.Generic;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        private static unsafe void ReadSMSMessages(byte* bytePtrT, IReadOnlyList<int> partOffsets,
            Database.Underground2Db db)
        {
            if (partOffsets[6] == -1) return; // if sms message block does not exist
            if (*(uint*) (bytePtrT + partOffsets[6]) != CareerInfo.SMS_MESSAGE_BLOCK)
                return; // check message block block ID

            var size = *(int*) (bytePtrT + partOffsets[6] + 4) / 0x14;
            for (var a1 = 0; a1 < size; ++a1)
            {
                var ptrString = partOffsets[0] + 8;
                var ptrHeader = partOffsets[6] + a1 * 0x14 + 8;
                var sms = new SmsMessage(bytePtrT + ptrHeader, bytePtrT + ptrString, db);
                db.SMSMessages.Collections.Add(sms);
            }
        }
    }
}