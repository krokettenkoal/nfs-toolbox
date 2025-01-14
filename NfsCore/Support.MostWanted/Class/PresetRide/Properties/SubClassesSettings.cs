﻿using NfsCore.Reflection.Attributes;
using NfsCore.Support.MostWanted.Parts.PresetParts;


namespace NfsCore.Support.MostWanted.Class
{
	public partial class PresetRide
	{
		[Expandable("Decals")]
		public DecalArray DECALS_FRONT_WINDOW { get; set; }

		[Expandable("Decals")]
		public DecalArray DECALS_REAR_WINDOW { get; set; }

		[Expandable("Decals")]
		public DecalArray DECALS_LEFT_DOOR { get; set; }

		[Expandable("Decals")]
		public DecalArray DECALS_RIGHT_DOOR { get; set; }

		[Expandable("Decals")]
		public DecalArray DECALS_LEFT_QUARTER { get; set; }

		[Expandable("Decals")]
		public DecalArray DECALS_RIGHT_QUARTER { get; set; }
	}
}