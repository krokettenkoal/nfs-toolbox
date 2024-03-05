using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
    {
        private eLocationType _locationType = eLocationType.CITY_CORE;
        private eDriftType _driftType = eDriftType.VS_AI;
        private eRaceGameplayMode _raceGameplayMode = eRaceGameplayMode.SPRINT;
        private eTrackDifficulty _difficultyForward = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;
        private eTrackDifficulty _difficultyReverse = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;

        /// <summary>
        /// Location type of the track.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eLocationType LocationType
        {
            get => _locationType;
            set
            {
                if (!Enum.IsDefined(typeof(eLocationType), value))
                    throw new MappingFailException();
                _locationType = value;
            }
        }

        /// <summary>
        /// Drift type of the track.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eDriftType DriftType
        {
            get => _driftType;
            set
            {
                if (!Enum.IsDefined(typeof(eDriftType), value))
                    throw new MappingFailException();
                _driftType = value;
            }
        }

        /// <summary>
        /// Represents the race gameplay mode of the track.
        /// </summary>
        [AccessModifiable]
        public eRaceGameplayMode RaceGameplayMode
        {
            get => _raceGameplayMode;
            set
            {
                if (!Enum.IsDefined(typeof(eRaceGameplayMode), value))
                    throw new MappingFailException();
                _raceGameplayMode = value;
            }
        }

        /// <summary>
        /// Difficulty of the track when it has a forward direction.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eTrackDifficulty DifficultyForward
        {
            get => _difficultyForward;
            set
            {
                if (!Enum.IsDefined(typeof(eTrackDifficulty), value))
                    throw new MappingFailException();
                _difficultyForward = value;
            }
        }

        /// <summary>
        /// Difficulty of the track when it has a reverse direction.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eTrackDifficulty DifficultyReverse
        {
            get => _difficultyReverse;
            set
            {
                if (!Enum.IsDefined(typeof(eTrackDifficulty), value))
                    throw new MappingFailException();
                _difficultyReverse = value;
            }
        }
    }
}