using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _required_spec_race_won = BaseArguments.NULL;

		[AccessModifiable()]
		[StaticModifiable()]
		public string RequiredSpecificRaceWon
		{
			get => this._required_spec_race_won;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._required_spec_race_won = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte RequiredSpecificURLWon { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte SponsorChosenToUnlock { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte RequiredRacesWon { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte RequiredURLWon { get; set; }
	}
}