using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Sponsor
    {
        public unsafe void Assemble(byte* bytePtrT, MemoryWriter mw)
        {
            var pointer = (ushort) mw.Position;
            mw.WriteNullTerminated(CollName);
            *(ushort*) bytePtrT = pointer;
            *(short*) (bytePtrT + 2) = CashValuePerWin;
            *(bytePtrT + 4) = (byte) ReqSponsorRace1;
            *(bytePtrT + 5) = (byte) ReqSponsorRace2;
            *(bytePtrT + 6) = (byte) ReqSponsorRace3;
            *(uint*) (bytePtrT + 8) = BinKey;
            *(short*) (bytePtrT + 12) = SignCashBonus;
            *(short*) (bytePtrT + 14) = PotentialCashBonus;
        }
    }
}