using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldShop
    {
        private string _introMovie = BaseArguments.NULL;
        private string _shopTrigger = BaseArguments.NULL;
        private string _eventToComplete = BaseArguments.NULL;
        private eWorldShopType _shopType = eWorldShopType.PAINTSHOP;
        private eBoolean _initiallyHidden = eBoolean.True;
        private eBoolean _unlockedByEvent = eBoolean.False;

        [AccessModifiable]
        public string IntroMovie
        {
            get => _introMovie;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value.Length > 0x17)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 23 characters.");
                _introMovie = value;
            }
        }

        [AccessModifiable]
        public string ShopTrigger
        {
            get => _shopTrigger;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _shopTrigger = value;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eWorldShopType ShopType
        {
            get => _shopType;
            set
            {
                if (Enum.IsDefined(typeof(eWorldShopType), value))
                    _shopType = value;
                else
                    throw new MappingFailException();
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean InitiallyHidden
        {
            get => _initiallyHidden;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _initiallyHidden = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eBoolean RequiresEventCompleted
        {
            get => _unlockedByEvent;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _unlockedByEvent = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        [AccessModifiable] [StaticModifiable] public byte BelongsToStage { get; set; }

        [AccessModifiable]
        [StaticModifiable]
        public string EventToBeCompleted
        {
            get => _eventToComplete;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _eventToComplete = value;
            }
        }
    }
}