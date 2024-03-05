using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Framework
{
    public static class Parse
    {
        public static string TrackCollectionName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            var tokens = name.Split(new char[] {' ', '\\', '/'}, System.StringSplitOptions.RemoveEmptyEntries);
            return tokens.Length < 1 ? null : tokens[^1];
        }

        public static string TrackDirectory(string regionName, string collectionName)
        {
            FormatX.GetInt32(regionName, "L{X}R#", out var area);
            return $"Location{area.ToString()}\\{collectionName}";
        }

        public static string RegionDirectory(string regionName)
        {
            FormatX.GetInt32(regionName, "L{X}R#", out var area);
            var loc = regionName.Substring(regionName.Length - 1, 1);
            return $"Location{area.ToString()}\\Region{loc.ToUpper()}";
        }
    }
}