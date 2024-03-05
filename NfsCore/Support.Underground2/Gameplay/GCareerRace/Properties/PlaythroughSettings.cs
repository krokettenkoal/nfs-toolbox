using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace
    {
        private string _introMovie = BaseArguments.NULL;
        private string _outroMovie = BaseArguments.NULL;
        private string _gpsDestination = BaseArguments.NULL;

        [AccessModifiable]
        public string IntroMovie
        {
            get => _introMovie;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _introMovie = value;
            }
        }

        [AccessModifiable]
        public string OutroMovie
        {
            get => _outroMovie;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _outroMovie = value;
            }
        }

        [AccessModifiable] public byte NumMapItems { get; set; }

        [AccessModifiable] public byte Unknown0x3A { get; set; }

        [AccessModifiable] public byte Unknown0x3B { get; set; }

        [AccessModifiable]
        public string GPSDestination
        {
            get => _gpsDestination;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _gpsDestination = value;
            }
        }

        private eDriftType DriftTypeIfDriftRace
        {
            get
            {
                if (EventBehaviorType != eEventBehaviorType.Drift)
                    return eDriftType.VS_AI;

                var track1 = Database.Tracks.FindCollection($"Track_{TrackID_Stage1}");
                var track2 = Database.Tracks.FindCollection($"Track_{TrackID_Stage2}");
                var track3 = Database.Tracks.FindCollection($"Track_{TrackID_Stage3}");
                var track4 = Database.Tracks.FindCollection($"Track_{TrackID_Stage4}");

                var drift1 = track1?.DriftType ?? eDriftType.VS_AI;
                var drift2 = track2?.DriftType ?? eDriftType.VS_AI;
                var drift3 = track3?.DriftType ?? eDriftType.VS_AI;
                var drift4 = track4?.DriftType ?? eDriftType.VS_AI;

                if (drift1 == eDriftType.DOWNHILL ||
                    drift2 == eDriftType.DOWNHILL ||
                    drift3 == eDriftType.DOWNHILL ||
                    drift4 == eDriftType.DOWNHILL)
                    return eDriftType.DOWNHILL;

                return eDriftType.VS_AI;
            }
        }
    }
}