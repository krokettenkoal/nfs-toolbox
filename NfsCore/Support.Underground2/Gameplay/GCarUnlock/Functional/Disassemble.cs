using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCarUnlock
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            var key = *(uint*) bytePtrT;
            CollName = Map.Lookup(key, false) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 4);
            _reqEventCompleted1 = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 8);
            _reqEventCompleted2 = Map.Lookup(key, true) ?? $"0x{key:X8}";
        }
    }
}