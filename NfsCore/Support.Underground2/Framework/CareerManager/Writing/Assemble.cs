using System.IO;
using NfsCore.Global;
using NfsCore.Reflection.ID;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2.Framework
{
    public static partial class CareerManager
    {
        public static void Assemble(BinaryWriter bw, Database.Underground2Db db)
        {
            // Initialize MemoryWriter for string block to its maximum size
            var mw = new MemoryWriter(0xFFFF);
            mw.Write((byte) 0); // write null-termination
            mw.WriteNullTerminated(Process.Watermark);

            // Get arrays of all blocks
            var gCareerRacesBlock = WriteGCareerRaces(mw, db);
            var worldShopBlock = WriteWorldShops(mw, db);
            var gCareerBrandsBlock = WriteGCareerBrands(mw, db);
            var partPerformancesBlock = WritePartPerformances(db);
            var gShowcasesBlock = WriteGShowcases(mw, db);
            var smsMessagesBlock = WriteSMSMessages(mw, db);
            var sponsorsBlock = WriteSponsors(mw, db);
            var gCareerStagesBlock = WriteGCareerStages(db);
            var perfSliderTuningsBlock = WritePerfSliderTunings(db);
            var worldChallengesBlock = WriteWorldChallenges(mw, db);
            var partUnlockablesBlock = WritePartUnlockables(db);
            var bankTriggersBlock = WriteBankTriggers(db);
            var gCarUnlocksBlock = WriteGCarUnlocks(db);

            // Compress to the position
            mw.Position += 4 - (mw.Position % 4);
            mw.CompressToPosition();

            // Pre-calculate size
            var size = 8 + mw.Length;
            size += gCareerRacesBlock.Length;
            size += worldShopBlock.Length;
            size += gCareerBrandsBlock.Length;
            size += partPerformancesBlock.Length;
            size += gShowcasesBlock.Length;
            size += smsMessagesBlock.Length;
            size += sponsorsBlock.Length;
            size += gCareerStagesBlock.Length;
            size += perfSliderTuningsBlock.Length;
            size += worldChallengesBlock.Length;
            size += partUnlockablesBlock.Length;
            size += bankTriggersBlock.Length;
            size += gCarUnlocksBlock.Length;

            // Pre-calculate padding
            var padding = Resolve.GetPaddingArray(size + 0x50, 0x80);
            size += padding.Length;

            // Finally, write entire Career Block
            bw.Write(CareerInfo.MAINID);
            bw.Write(size);
            bw.Write(CareerInfo.STRING_BLOCK);
            bw.Write(mw.Length);
            bw.Write(mw.Data);
            bw.Write(gCareerRacesBlock);
            bw.Write(worldShopBlock);
            bw.Write(gCareerBrandsBlock);
            bw.Write(partPerformancesBlock);
            bw.Write(gShowcasesBlock);
            bw.Write(smsMessagesBlock);
            bw.Write(sponsorsBlock);
            bw.Write(gCareerStagesBlock);
            bw.Write(perfSliderTuningsBlock);
            bw.Write(worldChallengesBlock);
            bw.Write(partUnlockablesBlock);
            bw.Write(bankTriggersBlock);
            bw.Write(gCarUnlocksBlock);
            bw.Write(padding);
        }
    }
}