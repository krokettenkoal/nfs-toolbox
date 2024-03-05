using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace
    {
        private byte _numOfOpponents;
        private byte _numOfStages = 1;
        private string _playerCarType = BaseArguments.NULL;
        private eEventIconType _eventIconType = eEventIconType.REGULAR;
        private eTrackDifficulty _difficultyLevel = eTrackDifficulty.TRACK_DIFFICULTY_MEDIUM;
        private eBoolean _isDriveToGps = eBoolean.False;
        private eBoolean _isHiddenEvent = eBoolean.False;
        private byte _padding0;
        private byte _padding1;
        private int _padding2;
        private int _padding3;

        [AccessModifiable] [StaticModifiable] public int EarnableRespect { get; set; }

        [AccessModifiable]
        [StaticModifiable]
        public string PlayerCarType
        {
            get => _playerCarType;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _playerCarType = value;
            }
        }

        [AccessModifiable] [StaticModifiable] public int CashValue { get; set; }

        [AccessModifiable]
        [StaticModifiable]
        public eEventIconType EventIconType
        {
            get => _eventIconType;
            set
            {
                if (Enum.IsDefined(typeof(eEventIconType), value))
                    _eventIconType = value;
                else
                    throw new MappingFailException();
            }
        }

        [AccessModifiable]
        public eBoolean IsDriveToGPS
        {
            get => _isDriveToGps;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isDriveToGps = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eTrackDifficulty DifficultyLevel
        {
            get => _difficultyLevel;
            set
            {
                if (Enum.IsDefined(typeof(eTrackDifficulty), value))
                    _difficultyLevel = value;
                else
                    throw new MappingFailException();
            }
        }

        [AccessModifiable] [StaticModifiable] public byte BelongsToStage { get; set; }

        [AccessModifiable]
        [StaticModifiable]
        public byte NumOpponents
        {
            get => _numOfOpponents;
            set
            {
                if (value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be in range 0-5.");
                _numOfOpponents = value;
            }
        }

        [AccessModifiable] [StaticModifiable] public byte UnknownDragValue { get; set; }

        [AccessModifiable]
        [StaticModifiable]
        public byte NumStages
        {
            get => _numOfStages;
            set
            {
                if (value > 4)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be in range 0-4.");
                _numOfStages = value;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsHiddenEvent
        {
            get => _isHiddenEvent;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isHiddenEvent = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }
    }
}