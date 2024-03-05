using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldShop
    {
        public unsafe void Assemble(byte* bytePtrT, MemoryWriter mw)
        {
            mw.WriteNullTerminated(CollName);
            mw.WriteNullTerminated(_shopFilename);
            mw.WriteNullTerminated(_shopTrigger);

            for (var a1 = 0; a1 < CollName.Length; ++a1)
                *(bytePtrT + a1) = (byte) CollName[a1];

            if (_introMovie != BaseArguments.NULL)
            {
                mw.WriteNullTerminated(IntroMovie);
                for (var a1 = 0; a1 < IntroMovie.Length; ++a1)
                    *(bytePtrT + 0x20 + a1) = (byte) IntroMovie[a1];
            }

            *(uint*) (bytePtrT + 0x38) = BinKey;
            *(uint*) (bytePtrT + 0x3C) = Bin.SmartHash(_shopTrigger);

            for (var a1 = 0; a1 < _shopFilename.Length; ++a1)
                *(bytePtrT + 0x40 + a1) = (byte) _shopFilename[a1];

            *(bytePtrT + 0x50) = (byte) ShopType;
            *(bytePtrT + 0x51) = InitiallyHidden == eBoolean.True ? (byte) 1 : (byte) 0;
            *(uint*) (bytePtrT + 0x74) = Bin.SmartHash(_eventToComplete);
            *(bytePtrT + 0x9C) = (byte) RequiresEventCompleted;
            *(bytePtrT + 0x9D) = BelongsToStage;
        }
    }
}