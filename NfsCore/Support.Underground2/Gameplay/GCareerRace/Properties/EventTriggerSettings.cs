using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace
    {
        private string _eventTrigger = BaseArguments.NULL;
        private eUnlockCondition _unlockMethod = eUnlockCondition.SPECIFIC_RACE_WON;
        private eBoolean _isSuvRace = eBoolean.False;
        private eEventBehaviorType _eventBehavior = eEventBehaviorType.Circuit;

        [AccessModifiable]
        public string EventTrigger
        {
            get => _eventTrigger;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _eventTrigger = value;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eUnlockCondition UnlockMethod
        {
            get => _unlockMethod;
            set
            {
                if (Enum.IsDefined(typeof(eUnlockCondition), value))
                    _unlockMethod = value;
                else
                    throw new MappingFailException();
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsSUVRace
        {
            get => _isSuvRace;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isSuvRace = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable]
        public eEventBehaviorType EventBehaviorType
        {
            get => _eventBehavior;
            set
            {
                if (Enum.IsDefined(typeof(eEventBehaviorType), value))
                    _eventBehavior = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}