using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground1.Class
{
    public partial class Material
    {
        private float _transparency1;
        private float _transparency2;

        /// <summary>
        /// First alpha value of the material colors.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float AlphaValue1
        {
            get => _transparency1;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _transparency1 = value;
            }
        }

        /// <summary>
        /// Second alpha value of the material colors.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float AlphaValue2
        {
            get => _transparency2;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _transparency2 = value;
            }
        }
    }
}