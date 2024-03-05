using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldChallenge
    {
        private string _smsLabel = BaseArguments.NULL;
        private string _challengeParent = BaseArguments.NULL;
        private string _worldTrigger = BaseArguments.NULL;
        private eBoolean _useOutruns = eBoolean.False;
        private eWorldChallengeType _challengeType = eWorldChallengeType.Showcase;

        [AccessModifiable]
        public string WorldChallengeTrigger
        {
            get => _worldTrigger;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _worldTrigger = value;
            }
        }

        [AccessModifiable] [StaticModifiable] public byte BelongsToStage { get; set; }

        public byte _padding0 { get; set; }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean UseOutrunsAsReqRaces
        {
            get => _useOutruns;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _useOutruns = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable] [StaticModifiable] public byte RequiredRacesWon { get; set; }

        [AccessModifiable]
        public string ChallengeSMSLabel
        {
            get => _smsLabel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _smsLabel = value;
            }
        }

        [AccessModifiable]
        public string ChallengeParent
        {
            get => _challengeParent;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _challengeParent = value;
            }
        }

        [AccessModifiable] [StaticModifiable] public int TimeLimit { get; set; }

        [AccessModifiable]
        public eWorldChallengeType WorldChallengeType
        {
            get => _challengeType;
            set
            {
                if (!Enum.IsDefined(typeof(eWorldChallengeType), value))
                    throw new MappingFailException();
                _challengeType = value;
            }
        }

        [AccessModifiable] public byte UnlockablePart1_Index { get; set; }

        [AccessModifiable] public byte UnlockablePart2_Index { get; set; }

        [AccessModifiable] public byte UnlockablePart3_Index { get; set; }
    }
}