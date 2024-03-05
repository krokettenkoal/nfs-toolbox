using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerStage
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new GCareerStage(collectionName, Database)
            {
                _stageSponsor1 = _stageSponsor1,
                _stageSponsor2 = _stageSponsor2,
                _stageSponsor3 = _stageSponsor3,
                _stageSponsor4 = _stageSponsor4,
                _stageSponsor5 = _stageSponsor5,
                _lastStageEvent = _lastStageEvent,
                AttribSponsor1 = AttribSponsor1,
                AttribSponsor2 = AttribSponsor2,
                AttribSponsor3 = AttribSponsor3,
                AttribSponsor4 = AttribSponsor4,
                AttribSponsor5 = AttribSponsor5,
                OutrunCashValue = OutrunCashValue,
                MaxCircuitsShownOnMap = MaxCircuitsShownOnMap,
                MaxDragsShownOnMap = MaxDragsShownOnMap,
                MaxStreetXShownOnMap = MaxStreetXShownOnMap,
                MaxDriftsShownOnMap = MaxDriftsShownOnMap,
                MaxSprintsShownOnMap = MaxSprintsShownOnMap,
                MaxOutrunEvents = MaxOutrunEvents,
                Unknown0x04 = Unknown0x04,
                Unknown0x06 = Unknown0x06,
                Unknown0x26 = Unknown0x26,
                Unknown0x2C = Unknown0x2C,
                Unknown0x2D = Unknown0x2D,
                Unknown0x2E = Unknown0x2E,
                Unknown0x2F = Unknown0x2F,
                Unknown0x35 = Unknown0x35,
                Unknown0x36 = Unknown0x36,
                Unknown0x37 = Unknown0x37,
                Unknown0x38 = Unknown0x38,
                Unknown0x39 = Unknown0x39,
                Unknown0x3A = Unknown0x3A,
                Unknown0x3B = Unknown0x3B,
                Unknown0x3C = Unknown0x3C,
                Unknown0x3D = Unknown0x3D,
                Unknown0x3E = Unknown0x3E,
                Unknown0x3F = Unknown0x3F,
                Unknown0x41 = Unknown0x41,
                Unknown0x42 = Unknown0x42,
                Unknown0x43 = Unknown0x43,
                Unknown0x44 = Unknown0x44,
                Unknown0x48 = Unknown0x48,
                Unknown0x4C = Unknown0x4C
            };
            return result;
        }
    }
}