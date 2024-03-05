using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
    {
        private eBoolean _isValidRace = eBoolean.True;
        private eBoolean _isLoopingRace = eBoolean.False;
        private eBoolean _reverseVersionExists = eBoolean.True;
        private eBoolean _isPerformanceTuning = eBoolean.False;

        /// <summary>
        /// Indicates whether race is valid.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsValidRace
        {
            get => _isValidRace;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isValidRace = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Indicates whether race is looping.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsLoopingRace
        {
            get => _isLoopingRace;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isLoopingRace = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Indicates whether reverse version of the race exists.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean ReverseVersionExists
        {
            get => _reverseVersionExists;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _reverseVersionExists = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Indicates whether the race is used in performance tuning events.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsPerformanceTuning
        {
            get => _isPerformanceTuning;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isPerformanceTuning = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }
    }
}