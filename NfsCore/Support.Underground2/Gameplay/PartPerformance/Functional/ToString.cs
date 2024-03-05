using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartPerformance
    {
        public override string ToString()
        {
            var resolvedName = Map.Lookup(BinKey, false) ?? CollectionName;
            return $"Collection Name: {resolvedName} | " +
                   $"BinKey: {BinKey:X8} | Game: {GameSTR}";
        }
    }
}