using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		private string _last_stage_event = BaseArguments.NULL;

		[AccessModifiable()]
		[StaticModifiable()]
		public short OutrunCashValue { get; set; }

		[AccessModifiable()]
		public string LastStageEvent
		{
			get => this._last_stage_event;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._last_stage_event = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxCircuitsShownOnMap { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxDragsShownOnMap { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxStreetXShownOnMap { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxDriftsShownOnMap { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxSprintsShownOnMap { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxOutrunEvents { get; set; }
	}
}