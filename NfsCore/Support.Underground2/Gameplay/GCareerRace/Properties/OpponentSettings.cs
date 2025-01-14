﻿using NfsCore.Reflection.Attributes;
using NfsCore.Support.Underground2.Parts.GameParts;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		[Expandable("Opponents")]
		public Opponent OPPONENT1 { get; set; }

		[Expandable("Opponents")]
		public Opponent OPPONENT2 { get; set; }

		[Expandable("Opponents")]
		public Opponent OPPONENT3 { get; set; }

		[Expandable("Opponents")]
		public Opponent OPPONENT4 { get; set; }

		[Expandable("Opponents")]
		public Opponent OPPONENT5 { get; set; }
	}
}