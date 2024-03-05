using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		public override Collectable MemoryCast(string collectionName)
		{
			var result = new PartUnlockable(collectionName, Database)
			{
				_unlockMethodLevel1 = _unlockMethodLevel1,
				_unlockMethodLevel2 = _unlockMethodLevel2,
				_unlockMethodLevel3 = _unlockMethodLevel3,
				_unlockShop1 = _unlockShop1,
				_unlockShop2 = _unlockShop2,
				_unlockShop3 = _unlockShop3,
				BelongsToStage_Level1 = BelongsToStage_Level1,
				BelongsToStage_Level2 = BelongsToStage_Level2,
				BelongsToStage_Level3 = BelongsToStage_Level3,
				PartPrice_Level1 = PartPrice_Level1,
				PartPrice_Level2 = PartPrice_Level2,
				PartPrice_Level3 = PartPrice_Level3,
				RequiredRacesWon_Level1 = RequiredRacesWon_Level1,
				RequiredRacesWon_Level2 = RequiredRacesWon_Level2,
				RequiredRacesWon_Level3 = RequiredRacesWon_Level3,
				VisualRating_Level1 = VisualRating_Level1,
				VisualRating_Level2 = VisualRating_Level2,
				VisualRating_Level3 = VisualRating_Level3
			};
			return result;
		}
	}
}