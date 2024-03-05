using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class SmsMessage : NfsUnderground2Collectable
    {
        // Default constructor
        public SmsMessage()
        {
        }

        // Default constructor: create new sms message
        public SmsMessage(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble sms message
        public unsafe SmsMessage(byte* ptrHeader, byte* ptrString, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(ptrHeader, ptrString);
        }

        ~SmsMessage()
        {
        }
    }
}