using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class SmsMessage
    {
        private unsafe void Disassemble(byte* ptrHeader, byte* ptrString)
        {
            // CollectionName
            var pointer = *(ushort*) ptrHeader;
            CollName = ScriptX.NullTerminatedString(ptrString + pointer);

            // Unknown Yet Values
            _b0X02 = *(ptrHeader + 0x02);
            _b0X03 = *(ptrHeader + 0x03);
            _b0X04 = *(ptrHeader + 0x04);
            _b0X05 = *(ptrHeader + 0x05);
            _b0X06 = *(ptrHeader + 0x06);
            _b0X07 = *(ptrHeader + 0x07);
            _b0X08 = *(ptrHeader + 0x08);
            _b0X09 = *(ptrHeader + 0x09);
            _b0X0A = *(ptrHeader + 0x0A);
            _b0X0B = *(ptrHeader + 0x0B);

            // Cash and Sender
            CashValue = *(int*) (ptrHeader + 0x0C);
            var key = *(uint*) (ptrHeader + 0x10);
            MessageSenderLabel = Map.Lookup(key, true) ?? $"0x{key:X8}";
        }
    }
}