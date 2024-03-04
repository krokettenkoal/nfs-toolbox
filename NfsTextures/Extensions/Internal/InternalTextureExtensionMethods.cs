using Pfim;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace NfsTextures.Extensions.Internal;

/// <summary>
/// Collection of (internal) extension methods for <see cref="IImage"/> objects
/// </summary>
internal static class InternalTextureExtensionMethods
{
    /// <summary>
    /// Creates an ImageSharp image from Pfim image data.
    /// </summary>
    /// <param name="image">The Pfim image to create an ImageSharp image object from</param>
    /// <param name="imgData">The byte data of the image. This is a separate parameter since <see cref="IImage.Data"/> may contain incompatible padding.</param>
    /// <returns>A new ImageSharp image object for further use</returns>
    /// <exception cref="NotSupportedException">The pixel format of the image is not supported.</exception>
    /// <seealso href="https://github.com/nickbabcock/Pfim/blob/5ba6ee13b3071dbddbc5f85890b913f0e3f93b6b/src/Pfim.ImageSharp/Program.cs"/>
    public static Image ToImageSharp(this IImage image, byte[] imgData)
    {
        return image.Format switch
        {
            ImageFormat.Rgba32 => Image.LoadPixelData<Bgra32>(imgData, image.Width, image.Height),
            ImageFormat.Rgb24 => Image.LoadPixelData<Bgr24>(imgData, image.Width, image.Height),
            ImageFormat.Rgba16 => Image.LoadPixelData<Bgra4444>(imgData, image.Width, image.Height),
            ImageFormat.R5g5b5 => Image.LoadPixelData<Bgra5551>(
                imgData.Select((bt, i) => (byte) (i % 2 == 0 ? bt : bt | 128)).ToArray(), image.Width, image.Height),
            ImageFormat.R5g5b5a1 => Image.LoadPixelData<Bgra5551>(imgData, image.Width, image.Height),
            ImageFormat.R5g6b5 => Image.LoadPixelData<Bgr565>(imgData, image.Width, image.Height),
            ImageFormat.Rgb8 => Image.LoadPixelData<L8>(imgData, image.Width, image.Height),
            _ => throw new NotSupportedException("The pixel format of the image is not supported.")
        };
    }
}