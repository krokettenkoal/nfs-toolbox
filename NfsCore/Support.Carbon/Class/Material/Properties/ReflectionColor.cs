using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        private float _reflectionColorLevel;
        private float _reflectionColorRed;
        private float _reflectionColorGreen;
        private float _reflectionColorBlue;

        /// <summary>
        /// Level value of the reflection color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float ReflectionColorLevel
        {
            get => _reflectionColorLevel;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _reflectionColorLevel = value;
            }
        }

        /// <summary>
        /// Red value of the reflection color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float ReflectionColorRed
        {
            get => _reflectionColorRed;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _reflectionColorRed = value;
            }
        }

        /// <summary>
        /// Green value of the reflection color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float ReflectionColorGreen
        {
            get => _reflectionColorGreen;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _reflectionColorGreen = value;
            }
        }

        /// <summary>
        /// Blue value of the reflection color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float ReflectionColorBlue
        {
            get => _reflectionColorBlue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _reflectionColorBlue = value;
            }
        }
    }
}