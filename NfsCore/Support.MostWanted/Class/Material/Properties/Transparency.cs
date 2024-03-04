using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        private float _transparency = 0;

        /// <summary>
        /// First alpha value of the material colors.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public float AlphaValue
        {
            get => this._transparency;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("This value should be positive.");
                else
                    this._transparency = value;
            }
        }
    }
}