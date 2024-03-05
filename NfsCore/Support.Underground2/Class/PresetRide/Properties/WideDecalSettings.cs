using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private eDecalType _decalTypeHood = eDecalType.MEDIUM;
        private eDecalType _decalTypeLeftQuarter = eDecalType.MEDIUM;
        private eDecalType _decalTypeRightQuarter = eDecalType.MEDIUM;
        private eWideDecalType _decalWideLeftDoor = eWideDecalType.NONE;
        private eWideDecalType _decalWideRightDoor = eWideDecalType.NONE;
        private eWideDecalType _decalWideLeftQuarter = eWideDecalType.NONE;
        private eWideDecalType _decalWideRightQuarter = eWideDecalType.NONE;

        [AccessModifiable]
        [StaticModifiable]
        public eDecalType DecalTypeHood
        {
            get => _decalTypeHood;
            set
            {
                if (!Enum.IsDefined(typeof(eDecalType), value))
                    throw new MappingFailException();
                _decalTypeHood = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eDecalType DecalTypeLeftQuarter
        {
            get => _decalTypeLeftQuarter;
            set
            {
                if (!Enum.IsDefined(typeof(eDecalType), value))
                    throw new MappingFailException();
                _decalTypeLeftQuarter = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eDecalType DecalTypeRightQuarter
        {
            get => _decalTypeRightQuarter;
            set
            {
                if (!Enum.IsDefined(typeof(eDecalType), value))
                    throw new MappingFailException();
                _decalTypeRightQuarter = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eWideDecalType DecalWideLeftDoor
        {
            get => _decalWideLeftDoor;
            set
            {
                if (!Enum.IsDefined(typeof(eWideDecalType), value))
                    throw new MappingFailException();
                _decalWideLeftDoor = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eWideDecalType DecalWideRightDoor
        {
            get => _decalWideRightDoor;
            set
            {
                if (!Enum.IsDefined(typeof(eWideDecalType), value))
                    throw new MappingFailException();
                _decalWideRightDoor = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eWideDecalType DecalWideLeftQuarter
        {
            get => _decalWideLeftQuarter;
            set
            {
                if (!Enum.IsDefined(typeof(eWideDecalType), value))
                    throw new MappingFailException();
                _decalWideLeftQuarter = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public eWideDecalType DecalWideRightQuarter
        {
            get => _decalWideRightQuarter;
            set
            {
                if (!Enum.IsDefined(typeof(eWideDecalType), value))
                    throw new MappingFailException();
                _decalWideRightQuarter = value;
                Modified = true;
            }
        }
    }
}