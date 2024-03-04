using NfsCore.Database.Collection;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Support.Underground2.Class;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Database
{
    public partial class Underground2 : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground2;

        public Root<Material> Materials { get; set; }
        public Root<CarTypeInfo> CarTypeInfos { get; set; }
        public Root<PresetRide> PresetRides { get; set; }
        public Root<SunInfo> SunInfos { get; set; }
        public Root<Track> Tracks { get; set; }
        public Root<GCareerRace> GCareerRaces { get; set; }
        public Root<WorldShop> WorldShops { get; set; }
        public Root<GCareerBrand> GCareerBrands { get; set; }
        public Root<PartPerformance> PartPerformances { get; set; }
        public Root<GShowcase> GShowcases { get; set; }
        public Root<SMSMessage> SMSMessages { get; set; }
        public Root<Sponsor> Sponsors { get; set; }
        public Root<GCareerStage> GCareerStages { get; set; }
        public Root<PerfSliderTuning> PerfSliderTunings { get; set; }
        public Root<WorldChallenge> WorldChallenges { get; set; }
        public Root<PartUnlockable> PartUnlockables { get; set; }
        public Root<BankTrigger> BankTriggers { get; set; }
        public Root<GCarUnlock> GCarUnlocks { get; set; }
        public Root<AcidEffect> AcidEffects { get; set; }
        
        public SlotType SlotTypes { get; set; }

        public Underground2()
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

			SunInfos = new Root<SunInfo>
			(
				"SunInfos",
				SunInfo.MaxCNameLength,
				SunInfo.CNameOffsetAt,
				SunInfo.BaseClassSize,
				true,
				false,
				this
			);

			Tracks = new Root<Track>
			(
				"Tracks",
				Track.MaxCNameLength,
				Track.CNameOffsetAt,
				Track.BaseClassSize,
				true,
				false,
				this
			);

			GCareerRaces = new Root<GCareerRace>
			(
				"GCareerRaces",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			WorldShops = new Root<WorldShop>
			(
				"WorldShops",
				0x1F,
				-1,
				-1,
				true,
				false,
				this
			);

			GCareerBrands = new Root<GCareerBrand>
			(
				"GCareerBrands",
				0x1F,
				-1,
				-1,
				true,
				false,
				this
			);
			
			PartPerformances = new Root<PartPerformance>
			(
				"PartPerformances",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			GShowcases = new Root<GShowcase>
			(
				"GShowcases",
				0x1F,
				-1,
				-1,
				true,
				false,
				this
			);

			SMSMessages = new Root<SMSMessage>
			(
				"SMSMessages",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			Sponsors = new Root<Sponsor>
			(
				"Sponsors",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			GCareerStages = new Root<GCareerStage>
			(
				"GCareerStages",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			PerfSliderTunings = new Root<PerfSliderTuning>
			(
				"PerfSliderTunings",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			WorldChallenges = new Root<WorldChallenge>
			(
				"WorldChallenges",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			PartUnlockables = new Root<PartUnlockable>
			(
				"PartUnlockables",
				-1,
				-1,
				-1,
				false,
				false,
				this
			);

			BankTriggers = new Root<BankTrigger>
			(
				"BankTriggers",
				-1,
				-1,
				-1,
				true,
				true,
				this
			);

			GCarUnlocks = new Root<GCarUnlock>
			(
				"GCarUnlocks",
				-1,
				-1,
				-1,
				true,
				false,
				this
			);

			AcidEffects = new Root<AcidEffect>
			(
				"AcidEffects",
				AcidEffect.MaxCNameLength,
				AcidEffect.CNameOffsetAt,
				AcidEffect.BaseClassSize,
				true,
				false,
				this
			);

			SlotTypes = new SlotType();
        }

        ~Underground2()
        {
            _GlobalABUN = null;
            _GlobalBLZC = null;
            _LngGlobal = null;
            _LngLabels = null;
            CarTypeInfos = null;
            FNGroups = null;
            Materials = null;
            PresetRides = null;
            SunInfos = null;
            Tracks = null;
            TPKBlocks = null;
            SlotTypes = null;
            STRBlocks = null;
            GCareerRaces = null;
            WorldShops = null;
            GCareerBrands = null;
            PartPerformances = null;
            GShowcases = null;
            SMSMessages = null;
            Sponsors = null;
            GCareerStages = null;
            PerfSliderTunings = null;
            WorldChallenges = null;
            PartUnlockables = null;
            BankTriggers = null;
            GCarUnlocks = null;
            AcidEffects = null;
        }
    }
}