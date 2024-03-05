using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartUnlockable
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            uint key;

            // CollectionName
            CollName = GetValidCollectionName(*(int*) bytePtrT);

            // Visual Ratings
            VisualRating_Level1 = (float) ((float) *(short*) (bytePtrT + 0x04) * 0.002);
            VisualRating_Level2 = (float) ((float) *(short*) (bytePtrT + 0x10) * 0.002);
            VisualRating_Level3 = (float) ((float) *(short*) (bytePtrT + 0x1C) * 0.002);

            // Part Prices
            PartPrice_Level1 = *(short*) (bytePtrT + 0x06);
            PartPrice_Level2 = *(short*) (bytePtrT + 0x12);
            PartPrice_Level3 = *(short*) (bytePtrT + 0x1E);

            // Required Stages Done
            _unlockMethodLevel1 = (ePartUnlockReq) (*(bytePtrT + 0x08));
            _unlockMethodLevel2 = (ePartUnlockReq) (*(bytePtrT + 0x14));
            _unlockMethodLevel3 = (ePartUnlockReq) (*(bytePtrT + 0x20));

            // Unlocking Requirements
            if (_unlockMethodLevel1 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
            {
                key = *(uint*) (bytePtrT + 0x0C);
                UnlocksInShop_Level1 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            }
            else
            {
                RequiredRacesWon_Level1 = *(bytePtrT + 0x0C);
                BelongsToStage_Level1 = *(bytePtrT + 0x0E);
            }

            if (_unlockMethodLevel2 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
            {
                key = *(uint*) (bytePtrT + 0x18);
                UnlocksInShop_Level2 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            }
            else
            {
                RequiredRacesWon_Level2 = *(bytePtrT + 0x18);
                BelongsToStage_Level2 = *(bytePtrT + 0x1A);
            }

            if (_unlockMethodLevel3 == ePartUnlockReq.SPECIFIC_SHOP_FOUND)
            {
                key = *(uint*) (bytePtrT + 0x24);
                UnlocksInShop_Level3 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            }
            else
            {
                RequiredRacesWon_Level3 = *(bytePtrT + 0x24);
                BelongsToStage_Level3 = *(bytePtrT + 0x26);
            }
        }
    }
}