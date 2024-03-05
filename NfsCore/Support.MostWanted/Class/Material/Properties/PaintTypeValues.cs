using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _shadowLevel;
        private float _matteLevel;
        private float _chromeLevel;

        /// <summary>
        /// Shadow level value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float ShadowLevel
        {
            get => _shadowLevel;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _shadowLevel = value;
            }
        }

        /// <summary>
        /// Matte level value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float MatteLevel
        {
            get => _matteLevel;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _matteLevel = value;
            }
        }

        /// <summary>
        /// Chrome level value of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float ChromeLevel
        {
            get => _chromeLevel;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _chromeLevel = value;
            }
        }
    }
}