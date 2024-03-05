using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class BankTrigger
    {
        public unsafe void Assemble(byte* bytePtrT)
        {
            *(ushort*) bytePtrT = CashValue;
            *(bytePtrT + 2) = InitiallyUnlocked == eBoolean.False ? (byte) 1 : (byte) 0;
            *(bytePtrT + 3) = BankIndex;
            *(int*) (bytePtrT + 4) = RequiredStagesCompleted;
            *(uint*) (bytePtrT + 8) = BinKey;
        }
    }
}