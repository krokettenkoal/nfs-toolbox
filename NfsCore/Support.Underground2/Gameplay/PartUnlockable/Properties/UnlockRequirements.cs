using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private string _unlockShop1 = BaseArguments.NULL;
		private string _unlockShop2 = BaseArguments.NULL;
		private string _unlockShop3 = BaseArguments.NULL;


		[AccessModifiable]
		[StaticModifiable]
		public string UnlocksInShop_Level1
		{
			get => _unlockShop1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_unlockShop1 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string UnlocksInShop_Level2
		{
			get => _unlockShop2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_unlockShop2 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string UnlocksInShop_Level3
		{
			get => _unlockShop3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_unlockShop3 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public byte RequiredRacesWon_Level1 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte RequiredRacesWon_Level2 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte RequiredRacesWon_Level3 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte BelongsToStage_Level1 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte BelongsToStage_Level2 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte BelongsToStage_Level3 { get; set; }
	}
}
