using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Material
    {
        private float _strongColor3Level;
        private float _strongColor3Red;
        private float _strongColor3Green;
        private float _strongColor3Blue;

        /// <summary>
        /// Level value of the third strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor3Level
        {
            get => _strongColor3Level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor3Level = value;
            }
        }

        /// <summary>
        /// Red value of the third strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor3Red
        {
            get => _strongColor3Red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor3Red = value;
            }
        }

        /// <summary>
        /// Green value of the third strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor3Green
        {
            get => _strongColor3Green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor3Green = value;
            }
        }

        /// <summary>
        /// Blue value of the third strong color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongColor3Blue
        {
            get => _strongColor3Blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strongColor3Blue = value;
            }
        }
    }
}