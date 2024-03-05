using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private eBoolean _carbonBody = eBoolean.False;
        private eBoolean _carbonHood = eBoolean.False;
        private eBoolean _carbonDoors = eBoolean.False;
        private eBoolean _carbonTrunk = eBoolean.False;

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean HasCarbonfibreBody
        {
            get => _carbonBody;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _carbonBody = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean HasCarbonfibreHood
        {
            get => _carbonHood;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _carbonHood = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean HasCarbonfibreDoors
        {
            get => _carbonDoors;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _carbonDoors = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean HasCarbonfibreTrunk
        {
            get => _carbonTrunk;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                {
                    _carbonTrunk = value;
                    Modified = true;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }
    }
}