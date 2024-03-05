using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class BankTrigger
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new BankTrigger(collectionName, Database)
            {
                _initially_unlocked = _initially_unlocked,
                CashValue = CashValue,
                RequiredStagesCompleted = RequiredStagesCompleted
            };
            return result;
        }
    }
}