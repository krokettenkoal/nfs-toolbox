using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCarUnlock
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new GCarUnlock(collectionName, Database)
            {
                _reqEventCompleted1 = _reqEventCompleted1,
                _reqEventCompleted2 = _reqEventCompleted2
            };
            return result;
        }
    }
}