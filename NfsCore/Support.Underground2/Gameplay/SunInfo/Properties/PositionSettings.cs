﻿using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class SunInfo
	{
		[AccessModifiable]
		[StaticModifiable]
		public int Version { get; set; } = 2;

		[AccessModifiable]
		[StaticModifiable]
		public float PositionX { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float PositionY { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float PositionZ { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float CarShadowPositionX { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float CarShadowPositionY { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float CarShadowPositionZ { get; set; }
	}
}