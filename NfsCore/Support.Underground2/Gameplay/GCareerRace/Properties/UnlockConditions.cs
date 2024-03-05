using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _requiredSpecRaceWon = BaseArguments.NULL;

		[AccessModifiable]
		[StaticModifiable]
		public string RequiredSpecificRaceWon
		{
			get => _requiredSpecRaceWon;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_requiredSpecRaceWon = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public byte RequiredSpecificURLWon { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte SponsorChosenToUnlock { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte RequiredRacesWon { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte RequiredURLWon { get; set; }
	}
}