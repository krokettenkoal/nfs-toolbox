using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground1.Class
{
    public partial class Material
    {
        private float _brightColor1Level;
        private float _brightColor1Red;
        private float _brightColor1Green;
        private float _brightColor1Blue;

        /// <summary>
        /// Level value of the first bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor1Level
        {
            get => _brightColor1Level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor1Level = value;
            }
        }

        /// <summary>
        /// Red value of the first bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor1Red
        {
            get => _brightColor1Red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor1Red = value;
            }
        }

        /// <summary>
        /// Green value of the first bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor1Green
        {
            get => _brightColor1Green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor1Green = value;
            }
        }

        /// <summary>
        /// Blue value of the first bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor1Blue
        {
            get => _brightColor1Blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor1Blue = value;
            }
        }
    }
}