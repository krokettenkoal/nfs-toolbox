using System;

namespace NfsCore.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Sorts <see cref="Texture"/> by their CollectionNames or BinKeys.
        /// </summary>
        /// <param name="byName">True if sort by name; false is sort by hash.</param>
        public override void SortTexturesByType(bool byName)
        {
            if (byName)
                Textures.Sort((x, y) => string.Compare(x.CollectionName, y.CollectionName, StringComparison.Ordinal));
            else
                Textures.Sort((x, y) => x.BinKey.CompareTo(y.BinKey));
        }
    }
}