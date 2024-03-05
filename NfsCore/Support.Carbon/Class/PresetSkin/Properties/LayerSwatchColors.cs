using System;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        private byte _swatch1;
        private byte _swatch2;
        private byte _swatch3;
        private byte _swatch4;

        /// <summary>
        /// Swatch color value of the first color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte SwatchColor1
        {
            get => _swatch1;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch1 = value;
            }
        }

        /// <summary>
        /// Swatch color value of the second color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte SwatchColor2
        {
            get => _swatch2;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch2 = value;
            }
        }

        /// <summary>
        /// Swatch color value of the third color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte SwatchColor3
        {
            get => _swatch3;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch3 = value;
            }
        }

        /// <summary>
        /// Swatch color value of the fourth color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte SwatchColor4
        {
            get => _swatch4;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch4 = value;
            }
        }
    }
}