using NfsCore.Global;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class BankTrigger
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            CashValue = *(ushort*) bytePtrT;
            _initially_unlocked = *(bytePtrT + 2) == 1 ? eBoolean.False : eBoolean.True;
            BankIndex = *(bytePtrT + 3);
            RequiredStagesCompleted = *(int*) (bytePtrT + 4);
            var key = *(uint*) (bytePtrT + 8);
            CollectionName = Map.Lookup(key, false) ?? $"0x{key:X8}";
        }
    }
}