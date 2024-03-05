using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        private float _shadowOuterRadius = 0;
        private float _optimalLightReflection = 0;

        /// <summary>
        /// Outer radius of the shadow fading.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float ShadowOuterRadius
        {
            get => _shadowOuterRadius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _shadowOuterRadius = value;
            }
        }

        /// <summary>
        /// Value of the optimal light reflection on the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float OptimalLightReflection
        {
            get => _optimalLightReflection;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _optimalLightReflection = value;
            }
        }
    }
}