using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldChallenge
    {
        protected unsafe void Disassemble(byte* ptrHeader, byte* ptrString)
        {
            var pointer = *(ushort*) ptrHeader;
            CollName = ScriptX.NullTerminatedString(ptrString + pointer);

            // Challenge Trigger
            pointer = *(ushort*) (ptrHeader + 2);
            _worldTrigger = ScriptX.NullTerminatedString(ptrString + pointer);

            // Stage and Unlock settings
            BelongsToStage = *(ptrHeader + 4);
            _padding0 = *(ptrHeader + 5);
            UseOutrunsAsReqRaces = (*(ptrHeader + 6) == 2) ? eBoolean.True : eBoolean.False;
            RequiredRacesWon = *(ptrHeader + 7);

            // Hashes
            var key = *(uint*) (ptrHeader + 0x8); // for reading keys and comparison
            _smsLabel = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (ptrHeader + 0xC);
            _challengeParent = Map.Lookup(key, true) ?? $"0x{key:X8}";

            // Time Limit
            TimeLimit = *(int*) (ptrHeader + 0x10);

            // Type and Unlockables
            WorldChallengeType = (eWorldChallengeType) (*(ptrHeader + 0x14));
            UnlockablePart1_Index = *(ptrHeader + 0x15);
            UnlockablePart2_Index = *(ptrHeader + 0x16);
            UnlockablePart3_Index = *(ptrHeader + 0x17);
        }
    }
}