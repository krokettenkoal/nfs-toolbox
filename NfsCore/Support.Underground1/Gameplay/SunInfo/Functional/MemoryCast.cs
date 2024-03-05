using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground1.Gameplay
{
    public partial class SunInfo
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new SunInfo(collectionName, Database)
            {
                Version = Version,
                PositionX = PositionX,
                PositionY = PositionY,
                PositionZ = PositionZ,
                CarShadowPositionX = CarShadowPositionX,
                CarShadowPositionY = CarShadowPositionY,
                CarShadowPositionZ = CarShadowPositionZ,
                SUNLAYER1 = SUNLAYER1.PlainCopy(),
                SUNLAYER2 = SUNLAYER2.PlainCopy(),
                SUNLAYER3 = SUNLAYER3.PlainCopy(),
                SUNLAYER4 = SUNLAYER4.PlainCopy(),
                SUNLAYER5 = SUNLAYER5.PlainCopy(),
                SUNLAYER6 = SUNLAYER6.PlainCopy()
            };
            return result;
        }
    }
}