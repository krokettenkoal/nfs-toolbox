namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        public static unsafe void Disassemble(byte* bytePtrT, Database.Underground2Db db)
        {
            var partOffsets = FindOffsets(bytePtrT);
            ReadStrings(bytePtrT, partOffsets);
            ReadGCareerRaces(bytePtrT, partOffsets, db);
            ReadWorldShops(bytePtrT, partOffsets, db);
            ReadGCareerBrands(bytePtrT, partOffsets, db);
            ReadPartPerformances(bytePtrT, partOffsets, db);
            ReadGShowcases(bytePtrT, partOffsets, db);
            ReadSMSMessages(bytePtrT, partOffsets, db);
            ReadSponsors(bytePtrT, partOffsets, db);
            ReadGCareerStages(bytePtrT, partOffsets, db);
            ReadPerfSliderTunings(bytePtrT, partOffsets, db);
            ReadWorldChallenges(bytePtrT, partOffsets, db);
            ReadPartUnlockables(bytePtrT, partOffsets, db);
            ReadBankTriggers(bytePtrT, partOffsets, db);
            ReadGCarUnlocks(bytePtrT, partOffsets, db);
        }
    }
}