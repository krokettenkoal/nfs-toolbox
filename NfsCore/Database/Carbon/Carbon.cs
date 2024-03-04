using NfsCore.Database.Collection;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Support.Carbon.Class;

namespace NfsCore.Database
{
    public partial class Carbon : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Carbon;

        public Root<Material> Materials { get; set; }
        public Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Root<PresetRide> PresetRides { get; set; }
        public Root<PresetSkin> PresetSkins { get; set; }
        public SlotType SlotTypes { get; set; }

        public Carbon()
        {
			Materials = new Root<Material>
			(
				"Materials",
				Material.MaxCNameLength,
				Material.CNameOffsetAt,
				Material.BaseClassSize,
				true,
				true,
				this
			);

			CarTypeInfos = new Root<CarTypeInfo>
			(
				"CarTypeInfos",
				CarTypeInfo.MaxCNameLength,
				CarTypeInfo.CNameOffsetAt,
				CarTypeInfo.BaseClassSize,
				true,
				true,
				this
			);

			PresetRides = new Root<PresetRide>
			(
				"PresetRides",
				PresetRide.MaxCNameLength,
				PresetRide.CNameOffsetAt,
				PresetRide.BaseClassSize,
				true,
				true,
				this
			);

			PresetSkins = new Root<PresetSkin>
			(
				"PresetSkins",
				PresetSkin.MaxCNameLength,
				PresetSkin.CNameOffsetAt,
				PresetSkin.BaseClassSize,
				true,
				true,
				this
			);

			SlotTypes = new SlotType();
        }

        ~Carbon()
        {
            _GlobalABUN = null;
            _GlobalBLZC = null;
            _LngGlobal = null;
            _LngLabels = null;
            CarTypeInfos = null;
            FNGroups = null;
            Materials = null;
            PresetRides = null;
            PresetSkins = null;
            TPKBlocks = null;
            SlotTypes = null;
            STRBlocks = null;
        }
    }
}
