using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _transparency;

        /// <summary>
        /// First alpha value of the material colors.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float AlphaValue
        {
            get => _transparency;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _transparency = value;
            }
        }
    }
}