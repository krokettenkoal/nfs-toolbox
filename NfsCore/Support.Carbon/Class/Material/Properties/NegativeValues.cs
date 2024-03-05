using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        private float _grayscale;
        private float _linearNegative;
        private float _gradientNegative;

        /// <summary>
        /// Main grayscale value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Grayscale
        {
            get => _grayscale;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _grayscale = value;
            }
        }

        /// <summary>
        /// Linear negativity of the material colors.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float LinearNegative
        {
            get => _linearNegative;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _linearNegative = value;
            }
        }

        /// <summary>
        /// Gradient negativity of the material colors.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float GradientNegative
        {
            get => _gradientNegative;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _gradientNegative = value;
            }
        }
    }
}