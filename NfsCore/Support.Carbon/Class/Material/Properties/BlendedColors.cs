using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        private float _disable_reflection = 0;
        private float _stronger_reflection = 0;
        private float _blend_strong_colors = 0;
        private float _disable_strong_colors = 0;

        /// <summary>
        /// Disable value of reflection colors of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float DisableReflection
        {
            get => _disable_reflection;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    _disable_reflection = value;
            }
        }

        /// <summary>
        /// Increment value of reflection colors of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float StrongerReflection
        {
            get => _stronger_reflection;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    _stronger_reflection = value;
            }
        }

        /// <summary>
        /// Blend value of strong colors of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float BlendStrongColors
        {
            get => _blend_strong_colors;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    _blend_strong_colors = value;
            }
        }

        /// <summary>
        /// Disable value of strong colors of the material.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float DisableStrongColors
        {
            get => _disable_strong_colors;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    _disable_strong_colors = value;
            }
        }
    }
}