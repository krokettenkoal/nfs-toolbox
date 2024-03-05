using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Material
    {
        private float _strongColor2Level;
        private float _strongColor2Red;
        private float _strongColor2Green;
        private float _strongColor2Blue;

        /// <summary>
        /// Level value of the second strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor2Level
        {
            get => _strongColor2Level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor2Level = value;
            }
        }

        /// <summary>
        /// Red value of the second strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor2Red
        {
            get => _strongColor2Red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor2Red = value;
            }
        }

        /// <summary>
        /// Green value of the second strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor2Green
        {
            get => _strongColor2Green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor2Green = value;
            }
        }

        /// <summary>
        /// Blue value of the second strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor2Blue
        {
            get => _strongColor2Blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor2Blue = value;
            }
        }
    }
}