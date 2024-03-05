using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new Material(collectionName, Database)
            {
                _shadowOuterRadius = _shadowOuterRadius,
                _optimalLightReflection = _optimalLightReflection,
                _disable_reflection = _disable_reflection,
                _stronger_reflection = _stronger_reflection,
                _blend_strong_colors = _blend_strong_colors,
                _disable_strong_colors = _disable_strong_colors,
                _strongColor1Level = _strongColor1Level,
                _strongColor1Red = _strongColor1Red,
                _strongColor1Green = _strongColor1Green,
                _strongColor1Blue = _strongColor1Blue,
                _strongColor2Level = _strongColor2Level,
                _strongColor2Red = _strongColor2Red,
                _strongColor2Green = _strongColor2Green,
                _strongColor2Blue = _strongColor2Blue,
                _brightcolor2_level = _brightcolor2_level,
                _brightcolor2_red = _brightcolor2_red,
                _brightcolor2_green = _brightcolor2_green,
                _brightcolor2_blue = _brightcolor2_blue,
                _brightcolor1_level = _brightcolor1_level,
                _brightcolor1_red = _brightcolor1_red,
                _brightcolor1_green = _brightcolor1_green,
                _brightcolor1_blue = _brightcolor1_blue,
                _grayscale = _grayscale,
                _linearNegative = _linearNegative,
                _gradientNegative = _gradientNegative,
                _reflectionColorLevel = _reflectionColorLevel,
                _reflectionColorRed = _reflectionColorRed,
                _reflectionColorGreen = _reflectionColorGreen,
                _reflectionColorBlue = _reflectionColorBlue,
                _transparency1 = _transparency1,
                _transparency2 = _transparency2,
                _unk1 = _unk1,
                _unk2 = _unk2,
                _unk3 = _unk3,
                _unk4 = _unk4,
                _unk5 = _unk5,
                _unk6 = _unk6,
                _unk7 = _unk7
            };

            return result;
        }
    }
}