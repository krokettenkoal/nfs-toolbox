using NfsCore.Reflection.Enum;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attempts to add <see cref="Texture"/> to the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="collectionName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="fileName">Path of the texture to be imported.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public override bool TryAddTexture(string collectionName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(collectionName)) return false;

            if (FindTexture(Bin.Hash(collectionName), eKeyType.BINKEY) != null)
                return false;

            if (!Comp.IsDDSTexture(fileName))
                return false;

            var texture = new Texture(collectionName, CollectionName, fileName, Database);
            Textures.Add(texture);
            return true;
        }

        /// <summary>
        /// Attempts to add <see cref="Texture"/> to the <see cref="TPKBlock"/> data.
        /// </summary>
        /// <param name="collectionName">Collection Name of the new <see cref="Texture"/>.</param>
        /// <param name="fileName">Path of the texture to be imported.</param>
        /// <param name="error">Error occured when trying to add a texture.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public override bool TryAddTexture(string collectionName, string fileName, out string error)
        {
            error = null;
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                error = $"Collection Name cannot be empty or whitespace.";
                return false;
            }

            if (FindTexture(Bin.Hash(collectionName), eKeyType.BINKEY) != null)
            {
                error = $"Texture named {collectionName} already exists.";
                return false;
            }

            if (!Comp.IsDDSTexture(fileName))
            {
                error = $"Texture passed is not a DDS texture.";
                return false;
            }

            var texture = new Texture(collectionName, CollectionName, fileName, Database);
            Textures.Add(texture);
            return true;
        }
    }
}