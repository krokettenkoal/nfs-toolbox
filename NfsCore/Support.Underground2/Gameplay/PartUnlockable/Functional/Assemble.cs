using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartUnlockable
    {
        public unsafe void Assemble(byte* bytePtrT)
        {
            *(int*) bytePtrT = GetValidCollectionIndex();

            *(short*) (bytePtrT + 0x04) = (short) (VisualRating_Level1 * 500);
            *(short*) (bytePtrT + 0x10) = (short) (VisualRating_Level2 * 500);
            *(short*) (bytePtrT + 0x1C) = (short) (VisualRating_Level3 * 500);

            *(short*) (bytePtrT + 0x06) = PartPrice_Level1;
            *(short*) (bytePtrT + 0x12) = PartPrice_Level2;
            *(short*) (bytePtrT + 0x1E) = PartPrice_Level3;

            *(bytePtrT + 0x08) = (byte) _unlockMethodLevel1;
            *(bytePtrT + 0x14) = (byte) _unlockMethodLevel2;
            *(bytePtrT + 0x20) = (byte) _unlockMethodLevel3;

            *(bytePtrT + 0x09) = 1;
            *(bytePtrT + 0x15) = 2;
            *(bytePtrT + 0x21) = 3;

            if (_unlockMethodLevel1 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
                *(uint*) (bytePtrT + 0x0C) = Bin.SmartHash(UnlocksInShop_Level1);
            else
            {
                *(bytePtrT + 0x0C) = RequiredRacesWon_Level1;
                *(bytePtrT + 0x0E) = BelongsToStage_Level1;
            }

            if (_unlockMethodLevel2 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
                *(uint*) (bytePtrT + 0x18) = Bin.SmartHash(UnlocksInShop_Level2);
            else
            {
                *(bytePtrT + 0x18) = RequiredRacesWon_Level2;
                *(bytePtrT + 0x1A) = BelongsToStage_Level2;
            }

            if (_unlockMethodLevel3 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
                *(uint*) (bytePtrT + 0x24) = Bin.SmartHash(UnlocksInShop_Level3);
            else
            {
                *(bytePtrT + 0x24) = RequiredRacesWon_Level3;
                *(bytePtrT + 0x26) = BelongsToStage_Level3;
            }
        }
    }
}