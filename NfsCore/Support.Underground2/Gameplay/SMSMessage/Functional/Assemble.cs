using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class SmsMessage
    {
        public unsafe void Assemble(byte* bytePtrT, MemoryWriter mw)
        {
            var pointer = (ushort) mw.Position;
            mw.WriteNullTerminated(CollName);
            *(ushort*) bytePtrT = pointer;

            *(bytePtrT + 0x02) = _b0X02;
            *(bytePtrT + 0x03) = _b0X03;
            *(bytePtrT + 0x04) = _b0X04;
            *(bytePtrT + 0x05) = _b0X05;
            *(bytePtrT + 0x06) = _b0X06;
            *(bytePtrT + 0x07) = _b0X07;
            *(bytePtrT + 0x08) = _b0X08;
            *(bytePtrT + 0x09) = _b0X09;
            *(bytePtrT + 0x0A) = _b0X0A;
            *(bytePtrT + 0x0B) = _b0X0B;

            *(int*) (bytePtrT + 0x0C) = CashValue;
            *(uint*) (bytePtrT + 0x10) = Bin.SmartHash(MessageSenderLabel);
        }
    }
}