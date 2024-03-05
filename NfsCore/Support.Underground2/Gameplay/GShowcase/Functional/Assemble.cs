using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GShowcase
    {
        public unsafe void Assemble(byte* bytePtrT, MemoryWriter mw)
        {
            mw.WriteNullTerminated(CollName);
            for (var a1 = 0; a1 < CollName.Length; ++a1)
                *(bytePtrT + a1) = (byte) CollName[a1];

            *(uint*) (bytePtrT + 0x20) = BinKey;
            *(bytePtrT + 0x24) = (byte) TakePhotoMethod;
            *(bytePtrT + 0x25) = BelongsToStage;
            *(short*) (bytePtrT + 0x26) = CashValue;
            *(uint*) (bytePtrT + 0x28) = Bin.SmartHash(DescStringLabel);
            *(uint*) (bytePtrT + 0x2C) = Bin.SmartHash(DestinationPoint);
            *(bytePtrT + 0x34) = Unknown0x34;
            *(bytePtrT + 0x35) = Unknown0x35;
            *(uint*) (bytePtrT + 0x38) = Bin.SmartHash(DescAttrib);
            *(float*) (bytePtrT + 0x3C) = RequiredVisualRating;
        }
    }
}