using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldChallenge
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new WorldChallenge(collectionName, Database)
            {
                _worldTrigger = _worldTrigger,
                _useOutruns = _useOutruns,
                _smsLabel = _smsLabel,
                _padding0 = _padding0,
                _challengeType = _challengeType,
                _challengeParent = _challengeParent,
                UnlockablePart1_Index = UnlockablePart1_Index,
                UnlockablePart2_Index = UnlockablePart2_Index,
                UnlockablePart3_Index = UnlockablePart3_Index,
                TimeLimit = TimeLimit,
                RequiredRacesWon = RequiredRacesWon,
                BelongsToStage = BelongsToStage
            };
            return result;
        }
    }
}