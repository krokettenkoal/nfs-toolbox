namespace NfsCore.Support.Underground1.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Tries to find <see cref="Texture"/> based on the key passed.
        /// </summary>
        /// <param name="key">Key of the <see cref="Texture"/> Collection Name.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <returns>Texture if it is found; null otherwise.</returns>
        public override Shared.Class.Texture FindTexture(uint key, Reflection.Enum.eKeyType type)
        {
            return type switch
            {
                Reflection.Enum.eKeyType.BINKEY => Textures.Find(t => t.BinKey == key),
                Reflection.Enum.eKeyType.VLTKEY => Textures.Find(t => t.VltKey == key),
                Reflection.Enum.eKeyType.CUSTOM => throw new System.NotImplementedException(),
                _ => null
            };
        }
    }
}