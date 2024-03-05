using NfsCore.Support.Underground2.Framework;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartUnlockable
    {
        private static string GetValidCollectionName(int index)
        {
            return index > PartCNames.PartUnlockablesList.Count
                ? $"UnknownPart{index}"
                : PartCNames.PartUnlockablesList[index - 1];
        }

        private int GetValidCollectionIndex()
        {
            if (PartCNames.PartUnlockablesList.Contains(CollName))
                return PartCNames.PartUnlockablesList.FindIndex(c => c == CollName) + 1;
            
            return PartCNames.PartUnlockablesList.Count + 1;
        }
    }
}