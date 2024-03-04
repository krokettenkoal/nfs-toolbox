using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Shared.Class;
using Pfim;
using SixLabors.ImageSharp;
using NfsTextures.Extensions.Internal;

namespace NfsTextures.Extensions;

/// <summary>
/// Collection of extension methods for <see cref="Texture"/> objects
/// </summary>
public static class TextureExtensionMethods
{
    /// <summary>
    /// Gets an ImageSharp image of the NFS texture
    /// </summary>
    /// <returns>An ImageSharp image object for further use (e.g., saving and stuff)</returns>
    public static Image GetImage(this Texture texture)
    {
        var data = texture.GetDDSArray();
        using var dataStream = new MemoryStream(data);
        using var image = Pfimage.FromStream(dataStream);
        byte[] imgDataNormalized;

        // Since image sharp can't handle data with line padding in a stride
        // we create an stripped down array if any padding is detected
        var tightStride = image.Width * image.BitsPerPixel / 8;
        if (image.Stride != tightStride)
        {
            imgDataNormalized = new byte[image.Height * tightStride];
            for (var i = 0; i < image.Height; i++)
            {
                Buffer.BlockCopy(image.Data, i * image.Stride, imgDataNormalized, i * tightStride, tightStride);
            }
        }
        else
        {
            imgDataNormalized = image.Data;
        }

        return image.ToImageSharp(imgDataNormalized);
    }

    /// <summary>
    /// Exports a texture image to the given <paramref name="path"/>
    /// </summary>
    /// <param name="block">The TPK block to export the texture from</param>
    /// <param name="key">Collection key of the <see cref="Texture"/> to be exported</param>
    /// <param name="type">Type of the provided collection key</param>
    /// <param name="path">Path where the texture should be exported</param>
    /// <returns><c>true</c> if the texture was exported successfully, <c>false</c> otherwise.</returns>
    /// <remarks>The provided <paramref name="path"/> is used to determine the target format. Therefore, all formats supported by ImageSharp can be used.</remarks>
    public static void ExportTexture(this TPKBlock block, uint key, eKeyType type, string path)
    {
        var tex = block.FindTexture(key, type);
        if (tex == null) return;
        var img = tex.GetImage();
        img.Save(path);
    }
    
    /// <summary>
    /// Exports all textures from the database to the given <paramref name="destination"/>
    /// </summary>
    /// <param name="db">The database to export textures from</param>
    /// <param name="destination">The destination folder to export textures to</param>
    /// <param name="format">The format to export textures in</param>
    public static void ExportTextures(this BasicBase db, string destination, string format)
    {
        Directory.CreateDirectory(destination);
        foreach (var tpk in db.TPKBlocks.Collections)
        {
            var tpkDir = tpk.CollectionName.Substring(2, tpk.CollectionName.Length - 2);
            tpkDir = Path.Combine(destination, tpkDir);
            Directory.CreateDirectory(tpkDir);
            foreach (var tex in tpk.Textures)
            {
                var texPath = Path.Combine(tpkDir, tex.CollectionName) + format;
                var img = tex.GetImage();
                img.Save(texPath);
            }
        }
    }
}