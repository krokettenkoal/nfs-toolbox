using NfsCore.Reflection;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerBrand
    {
        public unsafe void Assemble(byte* bytePtrT, MemoryWriter mw)
        {
            mw.WriteNullTerminated(CollectionName);

            for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                *(bytePtrT + a1) = (byte) CollectionName[a1];

            if (_inGameBrandName != BaseArguments.NULL)
            {
                for (var a1 = 0; a1 < _inGameBrandName.Length; ++a1)
                    *(bytePtrT + 0x20 + a1) = (byte) _inGameBrandName[a1];
            }

            *(uint*) (bytePtrT + 0x40) = BinKey;
        }
    }
}