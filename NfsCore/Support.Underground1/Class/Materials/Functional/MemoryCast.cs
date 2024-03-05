using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground1.Class
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
                _brightColor1Blue = _brightColor1Blue,
                _brightColor1Green = _brightColor1Green,
                _brightColor1Level = _brightColor1Level,
                _brightColor1Red = _brightColor1Red,
                _brightColor2Blue = _brightColor2Blue,
                _brightColor2Green = _brightColor2Green,
                _brightColor2Level = _brightColor2Level,
                _brightColor2Red = _brightColor2Red,
                _strongColor1Blue = _strongColor1Blue,
                _strongColor1Green = _strongColor1Green,
                _strongColor1Level = _strongColor1Level,
                _strongColor1Red = _strongColor1Red,
                _strongColor2Blue = _strongColor2Blue,
                _strongColor2Green = _strongColor2Green,
                _strongColor2Level = _strongColor2Level,
                _strongColor2Red = _strongColor2Red,
                _strongColor3Blue = _strongColor3Blue,
                _strongColor3Green = _strongColor3Green,
                _strongColor3Level = _strongColor3Level,
                _strongColor3Red = _strongColor3Red,
                _strongColor4Blue = _strongColor4Blue,
                _strongColor4Green = _strongColor4Green,
                _strongColor4Level = _strongColor4Level,
                _strongColor4Red = _strongColor4Red,
                _strong1To2Ratio = _strong1To2Ratio,
                _strong3To4Ratio = _strong3To4Ratio,
                _transparency1 = _transparency1,
                _transparency2 = _transparency2
            };

            return result;
        }
    }
}