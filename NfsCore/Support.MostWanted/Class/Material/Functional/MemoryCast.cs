using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.MostWanted.Class
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
                _brightColor1Level = _brightColor1Level,
                _brightColor1Red = _brightColor1Red,
                _brightColor1Green = _brightColor1Green,
                _brightColor1Blue = _brightColor1Blue,
                _brightColor2Level = _brightColor2Level,
                _brightColor2Red = _brightColor2Red,
                _brightColor2Green = _brightColor2Green,
                _brightColor2Blue = _brightColor2Blue,
                _linearNegative = _linearNegative,
                _gradientNegative = _gradientNegative,
                _shadowLevel = _shadowLevel,
                _matteLevel = _matteLevel,
                _chromeLevel = _chromeLevel,
                _reflection1 = _reflection1,
                _reflection2 = _reflection2,
                _reflection3 = _reflection3,
                _strongColor1Level = _strongColor1Level,
                _strongColor1Red = _strongColor1Red,
                _strongColor1Green = _strongColor1Green,
                _strongColor1Blue = _strongColor1Blue,
                _transparency = _transparency,
                _unk1 = _unk1,
                _unk2 = _unk2,
                _unk3 = _unk3,
                _unk4 = _unk4,
                _unk5 = _unk5,
                _unk6 = _unk6,
                _unk7 = _unk7,
                _unk8 = _unk8,
                _unk9 = _unk9
            };

            return result;
        }
    }
}