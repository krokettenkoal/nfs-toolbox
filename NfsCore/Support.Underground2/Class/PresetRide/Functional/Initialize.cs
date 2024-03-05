using NfsCore.Support.Underground2.Parts.PresetParts;

namespace NfsCore.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private void Initialize()
		{
			AUDIO_COMP = new AudioBuffers();
			DECALS_FRONT_WINDOW = new DecalArray();
			DECALS_HOOD = new DecalArray();
			DECALS_LEFT_DOOR = new DecalArray();
			DECALS_LEFT_QUARTER = new DecalArray();
			DECALS_REAR_WINDOW = new DecalArray();
			DECALS_RIGHT_DOOR = new DecalArray();
			DECALS_RIGHT_QUARTER = new DecalArray();
			PAINT_TYPES = new PaintTypes();
			SPECIALTIES = new Specialties();
			VINYL_SETS = new VinylSets();
		}
	}
}