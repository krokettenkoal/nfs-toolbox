using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground1.Class
{
    public partial class Material
    {
        private float _strong1To2Ratio = 0;
        private float _strong3To4Ratio = 0;

        /// <summary>
        /// Ratio between first and second strong colors of the material
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Strong1to2Ratio
        {
            get => _strong1To2Ratio;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strong1To2Ratio = value;
            }
        }

        /// <summary>
        /// Ratio between third and fourth strong colors of the material
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float Strong3to4Ratio
        {
            get => _strong3To4Ratio;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be positive.");
                _strong3To4Ratio = value;
            }
        }
    }
}