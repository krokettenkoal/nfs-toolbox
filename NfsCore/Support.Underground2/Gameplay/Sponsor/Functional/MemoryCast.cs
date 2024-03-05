using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Sponsor
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new Sponsor(collectionName, Database)
            {
                CashValuePerWin = CashValuePerWin,
                SignCashBonus = SignCashBonus,
                PotentialCashBonus = PotentialCashBonus,
                _sponsorRace1 = _sponsorRace1,
                _sponsorRace2 = _sponsorRace2,
                _sponsorRace3 = _sponsorRace3
            };
            return result;
        }
    }
}