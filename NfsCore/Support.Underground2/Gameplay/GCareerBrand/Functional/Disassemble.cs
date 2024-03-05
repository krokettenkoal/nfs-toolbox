using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerBrand
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            // CollectionName
            CollectionName = ScriptX.NullTerminatedString(bytePtrT, 0x20);

            // In-game Brand Name
            _inGameBrandName = ScriptX.NullTerminatedString(bytePtrT + 0x20, 0x20);
        }
    }
}