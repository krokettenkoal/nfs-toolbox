using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Material
    {
        private float _brightColor2Level;
        private float _brightColor2Red;
        private float _brightColor2Green;
        private float _brightColor2Blue;

        /// <summary>
        /// Level value of the second bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor2Level
        {
            get => _brightColor2Level;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor2Level = value;
            }
        }

        /// <summary>
        /// Red value of the second bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor2Red
        {
            get => _brightColor2Red;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor2Red = value;
            }
        }

        /// <summary>
        /// Green value of the second bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor2Green
        {
            get => _brightColor2Green;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor2Green = value;
            }
        }

        /// <summary>
        /// Blue value of the second bright color of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BrightColor2Blue
        {
            get => _brightColor2Blue;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _brightColor2Blue = value;
            }
        }
    }
}