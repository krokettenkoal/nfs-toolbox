using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _unk1;
        private float _unk2;
        private float _unk3;
        private float _unk4;
        private float _unk5;
        private float _unk6;
        private float _unk7;
        private float _unk8;
        private float _unk9;

        /// <summary>
        /// Unknown 1 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown1
        {
            get => _unk1;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk1 = value;
            }
        }

        /// <summary>
        /// Unknown 2 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown2
        {
            get => _unk2;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk2 = value;
            }
        }

        /// <summary>
        /// Unknown 3 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown3
        {
            get => _unk3;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk3 = value;
            }
        }

        /// <summary>
        /// Unknown 4 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown4
        {
            get => _unk4;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk4 = value;
            }
        }

        /// <summary>
        /// Unknown 5 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown5
        {
            get => _unk5;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk5 = value;
            }
        }

        /// <summary>
        /// Unknown 6 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown6
        {
            get => _unk6;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk6 = value;
            }
        }

        /// <summary>
        /// Unknown 7 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown7
        {
            get => _unk7;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk7 = value;
            }
        }

        /// <summary>
        /// Unknown 8 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown8
        {
            get => _unk8;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk8 = value;
            }
        }

        /// <summary>
        /// Unknown 9 value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Unknown9
        {
            get => _unk9;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _unk9 = value;
            }
        }
    }
}