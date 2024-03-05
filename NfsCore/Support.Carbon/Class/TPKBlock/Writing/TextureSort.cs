namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Sorts textures by their binary memory hashes.
        /// </summary>
        protected override void TextureSort()
        {
            for (var a1 = 0; a1 < _keys.Count; ++a1)
            {
                for (var a2 = 0; a2 < _keys.Count - 1; ++a2)
                {
                    if (_keys[a2] <= _keys[a2 + 1]) continue;
                    // Switch keys, textures and compressions using deconstruction
                    (_keys[a2 + 1], _keys[a2]) = (_keys[a2], _keys[a2 + 1]);
                    (Textures[a2 + 1], Textures[a2]) = (Textures[a2], Textures[a2 + 1]);
                    (_compressions[a2 + 1], _compressions[a2]) = (_compressions[a2], _compressions[a2 + 1]);
                }
            }
        }
    }
}