using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _reflection1;
        private float _reflection2;
        private float _reflection3;

        /// <summary>
        /// First reflection value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Reflection1
        {
            get => _reflection1;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _reflection1 = value;
            }
        }

        /// <summary>
        /// Second reflection value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Reflection2
        {
            get => _reflection2;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _reflection2 = value;
            }
        }

        /// <summary>
        /// Third reflection value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Reflection3
        {
            get => _reflection3;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _reflection3 = value;
            }
        }
    }
}