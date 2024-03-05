using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldShop
    {
        protected unsafe void Disassemble(byte* bytePtrT)
        {
            // Collection Name
            CollName = ScriptX.NullTerminatedString(bytePtrT, 0x20);

            // Intro Movie
            var str = ScriptX.NullTerminatedString(bytePtrT + 0x20, 0x18);
            if (!string.IsNullOrWhiteSpace(str)) _introMovie = str;

            // Shop Trigger
            var key = *(uint*) (bytePtrT + 0x3C); // for reading keys and comparison
            var guess = $"TRIGGER_{CollName}";
            var hash = Bin.Hash(guess);
            if (key == hash)
                _shopTrigger = guess;
            else
                _shopTrigger = Map.Lookup(key, true) ?? $"0x{key:X8}";

            // Shop Filename
            _shopFilename = ScriptX.NullTerminatedString(bytePtrT + 0x40, 0x10);

            // Types and Unlocks
            _shopType = (eWorldShopType) (*(bytePtrT + 0x50));
            _initiallyHidden = (*(bytePtrT + 0x51) == 1) ? eBoolean.True : eBoolean.False;

            key = *(uint*) (bytePtrT + 0x74);
            _eventToComplete = Map.Lookup(key, true) ?? $"0x{key:X8}";

            _unlockedByEvent = (*(bytePtrT + 0x9C) == 1) ? eBoolean.True : eBoolean.False;
            BelongsToStage = *(bytePtrT + 0x9D);
        }
    }
}