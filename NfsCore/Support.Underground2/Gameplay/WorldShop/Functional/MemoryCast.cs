using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldShop
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new WorldShop(collectionName, Database)
            {
                _eventToComplete = _eventToComplete,
                _initiallyHidden = _initiallyHidden,
                _introMovie = _introMovie,
                _shopFilename = _shopFilename,
                _shopTrigger = _shopTrigger,
                _shopType = _shopType,
                _unlockedByEvent = _unlockedByEvent,
                BelongsToStage = BelongsToStage
            };
            return result;
        }
    }
}