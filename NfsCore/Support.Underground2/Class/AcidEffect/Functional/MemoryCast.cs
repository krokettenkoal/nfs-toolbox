using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Class
{
    public partial class AcidEffect
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new AcidEffect(collectionName, Database)
            {
                ClassKey = ClassKey,
                Flags = Flags,
                NumEmitters = NumEmitters,
                SectionNumber = SectionNumber,
                LocalWorldVec1X = LocalWorldVec1X,
                LocalWorldVec1Y = LocalWorldVec1Y,
                LocalWorldVec1Z = LocalWorldVec1Z,
                LocalWorldVec1W = LocalWorldVec1W,
                LocalWorldVec2X = LocalWorldVec2X,
                LocalWorldVec2Y = LocalWorldVec2Y,
                LocalWorldVec2Z = LocalWorldVec2Z,
                LocalWorldVec2W = LocalWorldVec2W,
                LocalWorldVec3X = LocalWorldVec3X,
                LocalWorldVec3Y = LocalWorldVec3Y,
                LocalWorldVec3Z = LocalWorldVec3Z,
                LocalWorldVec3W = LocalWorldVec3W,
                LocalWorldVec4X = LocalWorldVec4X,
                LocalWorldVec4Y = LocalWorldVec4Y,
                LocalWorldVec4Z = LocalWorldVec4Z,
                LocalWorldVec4W = LocalWorldVec4W,
                _inheritanceKey = _inheritanceKey,
                FarClip = FarClip,
                Intensity = Intensity,
                LastPositionX = LastPositionX,
                LastPositionY = LastPositionY,
                LastPositionZ = LastPositionZ,
                LastPositionW = LastPositionW,
                NumZeroParticleFrames = NumZeroParticleFrames,
                CreationTimeStamp = CreationTimeStamp
            };

            return result;
        }
    }
}