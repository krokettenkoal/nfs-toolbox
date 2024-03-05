using NfsCore.Global;
using NfsCore.Reflection;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerStage
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            // CollectionName
            CollName = $"STAGE_{*bytePtrT}";

            // Sponsor Settings
            NumberOfSponsorsToChoose = *(bytePtrT + 0x01);
            var key = *(uint*) (bytePtrT + 0x08);
            _stageSponsor1 = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x0C);
            _stageSponsor2 = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x10);
            _stageSponsor3 = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x14);
            _stageSponsor4 = Map.Lookup(key, true) ?? $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x18);
            _stageSponsor5 = Map.Lookup(key, true) ?? $"0x{key:X8}";
            AttribSponsor1 = *(short*) (bytePtrT + 0x1C);
            AttribSponsor2 = *(short*) (bytePtrT + 0x1E);
            AttribSponsor3 = *(short*) (bytePtrT + 0x20);
            AttribSponsor4 = *(short*) (bytePtrT + 0x22);
            AttribSponsor5 = *(short*) (bytePtrT + 0x24);

            // Race Settings
            OutrunCashValue = *(short*) (bytePtrT + 0x02);
            MaxCircuitsShownOnMap = *(bytePtrT + 0x30);
            MaxDragsShownOnMap = *(bytePtrT + 0x31);
            MaxStreetXShownOnMap = *(bytePtrT + 0x32);
            MaxDriftsShownOnMap = *(bytePtrT + 0x33);
            MaxSprintsShownOnMap = *(bytePtrT + 0x34);
            MaxOutrunEvents = *(bytePtrT + 0x40);
            key = *(uint*) (bytePtrT + 0x28);
            _lastStageEvent = Map.Lookup(key, true) ?? BaseArguments.NULL;

            // Unknown Yet Values
            Unknown0x04 = *(short*) (bytePtrT + 0x04);
            Unknown0x06 = *(short*) (bytePtrT + 0x06);
            Unknown0x26 = *(short*) (bytePtrT + 0x26);
            Unknown0x2C = *(bytePtrT + 0x2C);
            Unknown0x2D = *(bytePtrT + 0x2D);
            Unknown0x2E = *(bytePtrT + 0x2E);
            Unknown0x2F = *(bytePtrT + 0x2F);
            Unknown0x35 = *(bytePtrT + 0x35);
            Unknown0x36 = *(bytePtrT + 0x36);
            Unknown0x37 = *(bytePtrT + 0x37);
            Unknown0x38 = *(bytePtrT + 0x38);
            Unknown0x39 = *(bytePtrT + 0x39);
            Unknown0x3A = *(bytePtrT + 0x3A);
            Unknown0x3B = *(bytePtrT + 0x3B);
            Unknown0x3C = *(bytePtrT + 0x3C);
            Unknown0x3D = *(bytePtrT + 0x3D);
            Unknown0x3E = *(bytePtrT + 0x3E);
            Unknown0x3F = *(bytePtrT + 0x3F);
            Unknown0x41 = *(bytePtrT + 0x41);
            Unknown0x42 = *(bytePtrT + 0x42);
            Unknown0x43 = *(bytePtrT + 0x43);
            Unknown0x44 = *(float*) (bytePtrT + 0x44);
            Unknown0x48 = *(float*) (bytePtrT + 0x48);
            Unknown0x4C = *(float*) (bytePtrT + 0x4C);
        }
    }
}