﻿using NfsCore.Reflection.Enum;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attemps to replace texture specified in the TPKBlock data with a new one.
        /// </summary>
        /// <param name="key">Collection key of the texture to be replaced.</param>
        /// <param name="type">The type of the given <paramref name="key"/></param>
        /// <param name="fileName">Path of the texture that replaces the current one.</param>
        /// <returns>True if texture replacing was successful, false otherwise.</returns>
        public override bool TryReplaceTexture(uint key, eKeyType type, string fileName)
        {
            var tex = (Texture) FindTexture(key, type);
            if (tex == null) return false;
            if (!Comp.IsDDSTexture(fileName)) return false;
            tex.Reload(fileName);
            return true;
        }

        /// <summary>
        /// Attemps to replace <see cref="Texture"/> specified in the <see cref="TPKBlock"/> data with a new one.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to be replaced.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="fileName">Path of the texture that replaces the current one.</param>
        /// <param name="error">If an error occurs, the message is written to this parameter.</param>
        /// <returns>True if texture replacing was successful, false otherwise.</returns>
        public override bool TryReplaceTexture(uint key, eKeyType type, string fileName, out string error)
        {
            error = null;
            var tex = (Texture) FindTexture(key, type);
            if (tex == null)
            {
                error = $"Texture with key 0x{key:X8} does not exist.";
                return false;
            }

            if (!Comp.IsDDSTexture(fileName))
            {
                error = $"File {fileName} is not a valid DDS texture.";
                return false;
            }

            tex.Reload(fileName);
            return true;
        }
    }
}