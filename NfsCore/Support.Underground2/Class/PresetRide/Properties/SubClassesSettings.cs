using NfsCore.Reflection.Attributes;
using NfsCore.Support.Underground2.Parts.PresetParts;

namespace NfsCore.Support.Underground2.Class
{
	public partial class PresetRide
	{
		[Expandable("Visuals")]
		public PaintTypes PAINT_TYPES { get; set; }

		[Expandable("Visuals")]
		public VinylSets VINYL_SETS { get; set; }

		[Expandable("Visuals")]
		public Specialties SPECIALTIES { get; set; }

		[Expandable("Visuals")]
		public AudioBuffers AUDIO_COMP { get; set; }

		[Expandable("Decals")]
		public DecalArray DECALS_HOOD { get; set; }

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