using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GShowcase
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            // Collection Name
            CollName = ScriptX.NullTerminatedString(bytePtrT, 0x20);

            // Take Photo Settings
            _takePhoto = (eTakePhotoMethod) (*(bytePtrT + 0x24));
            BelongsToStage = *(bytePtrT + 0x25);
            CashValue = *(short*) (bytePtrT + 0x26);
            Unknown0x34 = *(bytePtrT + 0x34);
            Unknown0x35 = *(bytePtrT + 0x35);
            RequiredVisualRating = *(float*) (bytePtrT + 0x3C);

            // Showcase Strings
            var key = *(uint*) (bytePtrT + 0x28);
            _descStringLabel = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x2C);
            _destinationPoint = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x38);
            _descAttrib = Map.Lookup(key, true) ?? $"0x{key:X8}";
        }
    }
}