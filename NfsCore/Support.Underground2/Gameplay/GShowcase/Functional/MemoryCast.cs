using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GShowcase
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new GShowcase(collectionName, Database)
            {
                _descAttrib = _descAttrib,
                _descStringLabel = _descStringLabel,
                _destinationPoint = _destinationPoint,
                _takePhoto = _takePhoto,
                BelongsToStage = BelongsToStage,
                CashValue = CashValue,
                RequiredVisualRating = RequiredVisualRating,
                Unknown0x34 = Unknown0x34,
                Unknown0x35 = Unknown0x35
            };
            return result;
        }
    }
}