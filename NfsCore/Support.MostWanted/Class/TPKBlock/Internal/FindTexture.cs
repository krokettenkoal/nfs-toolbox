using System;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Tries to find <see cref="Texture"/> based on the key passed.
        /// </summary>
        /// <param name="key">Key of the <see cref="Texture"/> Collection Name.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <returns>Texture if it is found; null otherwise.</returns>
        public override Shared.Class.Texture FindTexture(uint key, eKeyType type)
        {
            return type switch
            {
                eKeyType.BINKEY => Textures.Find(t => t.BinKey == key),
                eKeyType.VLTKEY => Textures.Find(t => t.VltKey == key),
                eKeyType.CUSTOM => throw new NotImplementedException(),
                _ => null
            };
        }
    }
}