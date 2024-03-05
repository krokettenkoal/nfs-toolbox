using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerBrand
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new GCareerBrand(collectionName, Database)
            {
                _inGameBrandName = _inGameBrandName
            };
            return result;
        }
    }
}