using NfsCore.Database.Collection;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Support.MostWanted.Class;

namespace NfsCore.Database
{
    public partial class MostWanted : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.MostWanted;

        public Root<Material> Materials { get; set; }
        public Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Root<PresetRide> PresetRides { get; set; }
        public SlotType SlotTypes { get; set; }

        public MostWanted()
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

            SlotTypes = new SlotType();
        }

        ~MostWanted()
        {
            _GlobalABUN = null;
            _GlobalBLZC = null;
            _LngGlobal = null;
            _LngLabels = null;
            CarTypeInfos = null;
            FNGroups = null;
            Materials = null;
            PresetRides = null;
            TPKBlocks = null;
            SlotTypes = null;
            STRBlocks = null;
        }
    }
}