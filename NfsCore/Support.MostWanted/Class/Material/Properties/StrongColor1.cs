using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _strongColor1Level;
        private float _strongColor1Red;
        private float _strongColor1Green;
        private float _strongColor1Blue;

        /// <summary>
        /// Level value of the first strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor1Level
        {
            get => _strongColor1Level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor1Level = value;
            }
        }

        /// <summary>
        /// Red value of the first strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor1Red
        {
            get => _strongColor1Red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor1Red = value;
            }
        }

        /// <summary>
        /// Green value of the first strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor1Green
        {
            get => _strongColor1Green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor1Green = value;
            }
        }

        /// <summary>
        /// Blue value of the first strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor1Blue
        {
            get => _strongColor1Blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor1Blue = value;
            }
        }
    }
}