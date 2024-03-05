using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldChallenge
    {
        public unsafe void Assemble(byte* bytePtrT, MemoryWriter mw)
        {
            var pointer = (ushort) mw.Position;
            mw.WriteNullTerminated(CollName);
            *(ushort*) bytePtrT = pointer;

            pointer = (ushort) mw.Position;
            mw.WriteNullTerminated(_worldTrigger);
            *(ushort*) (bytePtrT + 0x02) = pointer;

            *(bytePtrT + 0x04) = BelongsToStage;
            *(bytePtrT + 0x06) = (byte) ((byte) UseOutrunsAsReqRaces * 2);
            *(bytePtrT + 0x07) = RequiredRacesWon;
            *(uint*) (bytePtrT + 0x08) = Bin.SmartHash(ChallengeSMSLabel);
            *(uint*) (bytePtrT + 0x0C) = Bin.SmartHash(ChallengeParent);
            *(int*) (bytePtrT + 0x10) = TimeLimit;
            *(bytePtrT + 0x14) = (byte) WorldChallengeType;
            *(bytePtrT + 0x15) = UnlockablePart1_Index;
            *(bytePtrT + 0x16) = UnlockablePart2_Index;
            *(bytePtrT + 0x17) = UnlockablePart3_Index;
        }
    }
}