using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class SmsMessage
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new SmsMessage(collectionName, Database)
            {
                _b0X02 = _b0X02,
                _b0X03 = _b0X03,
                _b0X04 = _b0X04,
                _b0X05 = _b0X05,
                _b0X06 = _b0X06,
                _b0X07 = _b0X07,
                _b0X08 = _b0X08,
                _b0X09 = _b0X09,
                _b0X0A = _b0X0A,
                _b0X0B = _b0X0B,
                CashValue = CashValue,
                _messageLabel = _messageLabel
            };
            return result;
        }
    }
}