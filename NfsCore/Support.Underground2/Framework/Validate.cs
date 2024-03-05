using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static class Validate
    {
        public static bool TrackRegionName(string regionName)
        {
            // Allowed format: L#R&, where # = int number, & = ascii char
            if (!regionName.StartsWith("L")) return false;
            if (regionName.Substring(regionName.Length - 2, 1) != "R") return false;
            return (byte) regionName[^1] <= sbyte.MaxValue && FormatX.GetInt32(regionName, "L{X}R#", out _);
        }

        public static bool TrackCollectionName(string collectionName)
        {
            // Allowed format: Track_#, where # is ushort
            if (!collectionName.StartsWith("Track_")) return false;
            if (!FormatX.GetInt32(collectionName, "Track_{X}", out var result)) return false;
            return result <= ushort.MaxValue;
        }

        public static bool PartPerformanceCollectionName(string collectionName)
        {
            if (collectionName.Length != 10) return false;
            try
            {
                _ = System.Convert.ToUInt32(collectionName, 16);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public static bool PerfSliderCollectionName(string collectionName)
        {
            if (collectionName.Length != 10) return false;
            try
            {
                _ = System.Convert.ToUInt32(collectionName, 16);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public static bool PartUnlockableCollectionName(string collectionName)
        {
            if (collectionName.Length != 10) return false;
            if (!collectionName.StartsWith("CARPART_")) return false;
            var index = FormatX.GetString(collectionName, "CARPART_{X}");
            return ConvertX.ToInt32(index) != 0;
        }

        public static bool CareerStageCollectionName(string collectionName)
        {
            if (!collectionName.StartsWith("STAGE_")) return false;
            var index = FormatX.GetString(collectionName, "STAGE_{X}");
            return byte.TryParse(index, out _);
        }

        public static bool BankTriggerCollectionName(string collectionName)
        {
            if (collectionName.Length != 15) return false;
            if (!collectionName.StartsWith("BANK_TRIGGER_")) return false;
            var index = FormatX.GetString(collectionName, "BANK_TRIGGER_{X}");
            return byte.TryParse(index, out _);
        }
    }
}