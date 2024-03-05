using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attempts to clone <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="newName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to clone.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <returns>True if texture cloning was successful, false otherwise.</returns>
        public override bool TryCloneTexture(string newName, uint key, eKeyType type)
        {
            if (string.IsNullOrWhiteSpace(newName)) return false;

            if (FindTexture(Bin.Hash(newName), type) != null)
                return false;

            var copyFrom = (Texture) FindTexture(key, type);
            if (copyFrom == null) return false;

            var texture = (Texture) copyFrom.MemoryCast(newName);
            Textures.Add(texture);
            return true;
        }

        /// <summary>
        /// Attempts to clone <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="newName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to clone.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="error">Error occured when trying to clone a texture.</param>
        /// <returns>True if texture cloning was successful, false otherwise.</returns>
        public override bool TryCloneTexture(string newName, uint key, eKeyType type, out string error)
        {
            error = null;
            if (string.IsNullOrWhiteSpace(newName))
            {
                error = "CollectionName cannot be empty or whitespace.";
                return false;
            }

            if (FindTexture(Bin.Hash(newName), type) != null)
            {
                error = $"Texture with CollectionName {newName} already exists.";
                return false;
            }

            var copyFrom = (Texture) FindTexture(key, type);
            if (copyFrom == null)
            {
                error = $"Texture with key 0x{key:X8} does not exist.";
                return false;
            }

            var texture = (Texture) copyFrom.MemoryCast(newName);
            Textures.Add(texture);
            return true;
        }
    }
}