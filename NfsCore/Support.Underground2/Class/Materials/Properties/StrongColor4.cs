using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Material
    {
        private float _strongColor4Level = 0;
        private float _strongColor4Red = 0;
        private float _strongColor4Green = 0;
        private float _strongColor4Blue = 0;

        /// <summary>
        /// Level value of the fourth strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor4Level
        {
            get => _strongColor4Level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor4Level = value;
            }
        }

        /// <summary>
        /// Red value of the fourth strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor4Red
        {
            get => _strongColor4Red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor4Red = value;
            }
        }

        /// <summary>
        /// Green value of the fourth strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor4Green
        {
            get => _strongColor4Green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor4Green = value;
            }
        }

        /// <summary>
        /// Blue value of the fourth strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor4Blue
        {
            get => _strongColor4Blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor4Blue = value;
            }
        }
    }
}