using System;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		protected override void ValidateCollectionName(string collectionName)
		{
			throw new NotSupportedException("CollectionName of PartUnlockables cannot be changed.");
		}
	}
}