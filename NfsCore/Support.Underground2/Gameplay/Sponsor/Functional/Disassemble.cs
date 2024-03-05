using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Sponsor
    {
        private unsafe void Disassemble(byte* ptrHeader, byte* ptrString)
        {
            // CollectionName
            var pointer = *(ushort*) ptrHeader;
            CollName = ScriptX.NullTerminatedString(ptrString + pointer);

            // Cash Values
            CashValuePerWin = *(short*) (ptrHeader + 2);
            SignCashBonus = *(short*) (ptrHeader + 12);
            PotentialCashBonus = *(short*) (ptrHeader + 14);

            // Required Sponsor Races
            ReqSponsorRace1 = (eSponsorRaceType) (*(ptrHeader + 4));
            ReqSponsorRace2 = (eSponsorRaceType) (*(ptrHeader + 5));
            ReqSponsorRace3 = (eSponsorRaceType) (*(ptrHeader + 6));
        }
    }
}