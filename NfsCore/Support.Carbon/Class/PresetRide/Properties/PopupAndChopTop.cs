using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private eBoolean _popupHeadlightsExist = eBoolean.False;
        private eBoolean _popupHeadlightsOn = eBoolean.False;
        private eBoolean _chopTopIsOn = eBoolean.False;
        private byte _chopTopSize = 0;

        /// <summary>
        /// True if popup headlights of the preset ride model exist, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean PopupHeadlightsExist
        {
            get => _popupHeadlightsExist;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _popupHeadlightsExist = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if preset ride's popup headlights are on, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean PopupHeadlightsOn
        {
            get => _popupHeadlightsOn;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _popupHeadlightsOn = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if preset ride's roof is a chop top, false otherwise.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean ChopTopIsOn
        {
            get => _chopTopIsOn;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _chopTopIsOn = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Choptop size value of the preset car. Range: 0-100.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte ChopTopSize
        {
            get => _chopTopSize;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _chopTopSize = value;
                Modified = true;
            }
        }
    }
}