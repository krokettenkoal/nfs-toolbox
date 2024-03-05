using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerStage
    {
        public unsafe void Assemble(byte* bytePtrT)
        {
            FormatX.GetByte(CollectionName, "STAGE_{X}", out var stage);
            *bytePtrT = stage;
            *(bytePtrT + 0x01) = NumberOfSponsorsToChoose;
            *(short*) (bytePtrT + 0x02) = OutrunCashValue;
            *(short*) (bytePtrT + 0x04) = Unknown0x04;
            *(short*) (bytePtrT + 0x06) = Unknown0x06;

            *(uint*) (bytePtrT + 0x08) = Bin.SmartHash(_stageSponsor1);
            *(uint*) (bytePtrT + 0x0C) = Bin.SmartHash(_stageSponsor2);
            *(uint*) (bytePtrT + 0x10) = Bin.SmartHash(_stageSponsor3);
            *(uint*) (bytePtrT + 0x14) = Bin.SmartHash(_stageSponsor4);
            *(uint*) (bytePtrT + 0x18) = Bin.SmartHash(_stageSponsor5);

            *(short*) (bytePtrT + 0x1C) = AttribSponsor1;
            *(short*) (bytePtrT + 0x1E) = AttribSponsor2;
            *(short*) (bytePtrT + 0x20) = AttribSponsor3;
            *(short*) (bytePtrT + 0x22) = AttribSponsor4;
            *(short*) (bytePtrT + 0x24) = AttribSponsor5;
            *(short*) (bytePtrT + 0x26) = Unknown0x26;

            *(uint*) (bytePtrT + 0x28) = Bin.SmartHash(_lastStageEvent);

            *(bytePtrT + 0x2C) = Unknown0x2C;
            *(bytePtrT + 0x2D) = Unknown0x2D;
            *(bytePtrT + 0x2E) = Unknown0x2E;
            *(bytePtrT + 0x2F) = Unknown0x2F;

            *(bytePtrT + 0x30) = MaxCircuitsShownOnMap;
            *(bytePtrT + 0x31) = MaxDragsShownOnMap;
            *(bytePtrT + 0x32) = MaxStreetXShownOnMap;
            *(bytePtrT + 0x33) = MaxDriftsShownOnMap;
            *(bytePtrT + 0x34) = MaxSprintsShownOnMap;

            *(bytePtrT + 0x35) = Unknown0x35;
            *(bytePtrT + 0x36) = Unknown0x36;
            *(bytePtrT + 0x37) = Unknown0x37;
            *(bytePtrT + 0x38) = Unknown0x38;
            *(bytePtrT + 0x39) = Unknown0x39;
            *(bytePtrT + 0x3A) = Unknown0x3A;
            *(bytePtrT + 0x3B) = Unknown0x3B;
            *(bytePtrT + 0x3C) = Unknown0x3C;
            *(bytePtrT + 0x3D) = Unknown0x3D;
            *(bytePtrT + 0x3E) = Unknown0x3E;
            *(bytePtrT + 0x3F) = Unknown0x3F;

            *(bytePtrT + 0x40) = MaxOutrunEvents;
            *(bytePtrT + 0x41) = Unknown0x41;
            *(bytePtrT + 0x42) = Unknown0x42;
            *(bytePtrT + 0x43) = Unknown0x43;
            *(float*) (bytePtrT + 0x44) = Unknown0x44;
            *(float*) (bytePtrT + 0x48) = Unknown0x48;
            *(float*) (bytePtrT + 0x4C) = Unknown0x4C;
        }
    }
}