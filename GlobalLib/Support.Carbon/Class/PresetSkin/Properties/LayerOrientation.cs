﻿namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Y-Position value of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public short PositionY { get; set; } = 0;

        /// <summary>
        /// X-Position value of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public short PositionX { get; set; } = 0;

        /// <summary>
        /// Rotation value of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public sbyte Rotation { get; set; } = 0;

        /// <summary>
        /// Skew value of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public sbyte Skew { get; set; } = 0;

        /// <summary>
        /// Y-Scale value of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public sbyte ScaleY { get; set; } = 0;

        /// <summary>
        /// X-Scale value of the vector vinyl of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public sbyte ScaleX { get; set; } = 0;
    }
}