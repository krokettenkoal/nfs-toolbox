using System;
using NfsCore.Database.Collection;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Support.Underground2.Class;
using NfsCore.Support.Underground2.Gameplay;

namespace NfsCore.Database
{
    public class Underground2Db : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground2;

        #region Properties
    
        public Root<Material> Materials { get; private set; }
        public Root<CarTypeInfo> CarTypeInfos { get; private set; }
        public Root<PresetRide> PresetRides { get; private set; }
        public Root<SunInfo> SunInfos { get; private set; }
        public Root<Track> Tracks { get; private set; }
        public Root<GCareerRace> GCareerRaces { get; private set; }
        public Root<WorldShop> WorldShops { get; private set; }
        public Root<GCareerBrand> GCareerBrands { get; private set; }
        public Root<PartPerformance> PartPerformances { get; private set; }
        public Root<GShowcase> GShowcases { get; private set; }
        public Root<SmsMessage> SMSMessages { get; private set; }
        public Root<Sponsor> Sponsors { get; private set; }
        public Root<GCareerStage> GCareerStages { get; private set; }
        public Root<PerfSliderTuning> PerfSliderTunings { get; private set; }
        public Root<WorldChallenge> WorldChallenges { get; private set; }
        public Root<PartUnlockable> PartUnlockables { get; private set; }
        public Root<BankTrigger> BankTriggers { get; private set; }
        public Root<GCarUnlock> GCarUnlocks { get; private set; }
        public Root<AcidEffect> AcidEffects { get; private set; }
        public SlotType SlotTypes { get; private set; }

        #endregion

        public Underground2Db()
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

            SMSMessages = new Root<SmsMessage>
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

        ~Underground2Db()
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

        /// <summary>
        /// Throws <see cref="NotImplementedException"/>.
        /// </summary>
        public override bool TryAddCollision(string collectionName, string filename, out string error)
        {
            throw new NotImplementedException("Import of collisions is not supported for Underground 2");
        }

        /// <summary>
        /// Gets information about <see cref="Underground2Db"/> database.
        /// </summary>
        /// <returns></returns>
        public override string GetDatabaseInfo()
        {
            var nl = Environment.NewLine;
            const string equals = " = ";
            const string collections = " collections.";
            var info = ToString() + nl;
            info += $"{AcidEffects.ThisName}{equals}{AcidEffects.Length}{collections}{nl}";
            info += $"{BankTriggers.ThisName}{equals}{BankTriggers.Length}{collections}{nl}";
            info += $"{CarTypeInfos.ThisName}{equals}{CarTypeInfos.Length}{collections}{nl}";
            info += $"{GCareerBrands.ThisName}{equals}{GCareerBrands.Length}{collections}{nl}";
            info += $"{GCareerRaces.ThisName}{equals}{GCareerRaces.Length}{collections}{nl}";
            info += $"{GCareerStages.ThisName}{equals}{GCareerStages.Length}{collections}{nl}";
            info += $"{GCarUnlocks.ThisName}{equals}{GCarUnlocks.Length}{collections}{nl}";
            info += $"{GShowcases.ThisName}{equals}{GShowcases.Length}{collections}{nl}";
            info += $"{Materials.ThisName}{equals}{Materials.Length}{collections}{nl}";
            info += $"{PartPerformances.ThisName}{equals}{PartPerformances.Length}{collections}{nl}";
            info += $"{PartUnlockables.ThisName}{equals}{PartUnlockables.Length}{collections}{nl}";
            info += $"{PerfSliderTunings.ThisName}{equals}{PerfSliderTunings.Length}{collections}{nl}";
            info += $"{PresetRides.ThisName}{equals}{PresetRides.Length}{collections}{nl}";
            info += $"{SMSMessages.ThisName}{equals}{SMSMessages.Length}{collections}{nl}";
            info += $"{Sponsors.ThisName}{equals}{Sponsors.Length}{collections}{nl}";
            info += $"{SunInfos.ThisName}{equals}{SunInfos.Length}{collections}{nl}";
            info += $"{Tracks.ThisName}{equals}{Tracks.Length}{collections}{nl}";
            info += $"{WorldChallenges.ThisName}{equals}{WorldChallenges.Length}{collections}{nl}";
            info += $"{WorldShops.ThisName}{equals}{WorldShops.Length}{collections}{nl}";
            return info;
        }
    }
}