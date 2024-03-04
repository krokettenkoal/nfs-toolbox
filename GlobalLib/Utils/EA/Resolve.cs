using System;
using System.IO;
using System.Linq;
using GlobalLib.Core;

namespace GlobalLib.Utils.EA
{
    /// <summary>
    /// Collection of functions to resolve major disassembly/assembly tasks.
    /// </summary>
    public static class Resolve
    {
        /// <summary>
        /// Gets swatch string from swatch number specified.
        /// </summary>
        /// <param name="swatch">Swatch number to be converted.</param>
        /// <returns>String value of swatch number passed.</returns>
        public static string GetSwatchString(byte swatch)
        {
            return swatch switch
            {
                >= 1 and <= 9 => "SWATCH_COLOR0" + swatch,
                <= 90 => "SWATCH_COLOR" + swatch,
                _ => "SWATCH_COLOR01"
            };
        }

        /// <summary>
        /// Gets vinyl string from vinyl number specified.
        /// </summary>
        /// <param name="swatch">Vinyl number to be converted.</param>
        /// <returns>String value of vinyl number passed.</returns>
        public static string GetVinylString(byte swatch)
        {
            return swatch switch
            {
                0 => null,
                <= 9 => "VINYL_L1_COLOR0" + swatch,
                <= 90 => "VINYL_L1_COLOR" + swatch,
                _ => null
            };
        }

        /// <summary>
        /// Gets the index of SWATCH_COLOR and VINYL_L1_COLOR.
        /// </summary>
        /// <param name="swatch">String to get the index from.</param>
        /// <returns>Swatch index as a byte.</returns>
        public static byte GetSwatchIndex(string swatch)
        {
            if (string.IsNullOrWhiteSpace(swatch)) return 0;
            if (!byte.TryParse(swatch.AsSpan(swatch.Length - 2, 2), out var result))
                result = 0;
            return result;
        }

        /// <summary>
        /// Gets pearl window tint string from a string passed.
        /// </summary>
        /// <param name="tint">String to get pearl window tint from.</param>
        /// <returns>Pearl tint string if was resolved, null otherwise.</returns>
        public static void GetWindowTintString(string tint)
        {
            try
            {
                if (!tint.StartsWith("WINDSHIELD_TINT")) return;
                if (!int.TryParse(tint.AsSpan(17, 1), out var level)) return;
                if (level == 3)
                {
                    var color = FormatX.GetString(tint, "WINDSHIELD_TINT_L3_{X}");
                    var var1 = "WINDSHIELD_TINT_L3_PEARL_" + color;
                    var var2 = "WINDSHIELD_TINT_L3_PEARL " + color;
                    Map.WindowTintMap.Add(var1);
                    Map.WindowTintMap.Add(var2);
                    Bin.Hash(var1);
                    Bin.Hash(var2);
                    return;
                }
                
                if (!Map.WindowTintMap.Contains(tint))
                    Map.WindowTintMap.Add(tint);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        /// Removes all special characters from the string passed.
        /// </summary>
        /// <param name="name">String to get clear one from.</param>
        /// <returns>String without any special characters.</returns>
        public static string GetPathFromCollection(string name)
        {
            var result = name;
            var illegal = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            return illegal.Aggregate(result, (current, letter) => current.Replace(letter.ToString(), "."));
        }

        /// <summary>
        /// Determines whether number is odd or even.
        /// </summary>
        /// <param name="number">Number passed to be based on.</param>
        /// <returns>True if odd, false if even.</returns>
        public static bool IsOdd(int number) => number % 2 != 0;

        /// <summary>
        /// Determines if values passed can make a color.
        /// </summary>
        /// <param name="a">Alpha value as an unsigned int.</param>
        /// <param name="r">Red value as an unsigned int.</param>
        /// <param name="g">Green value as an unsigned int.</param>
        /// <param name="b">Blue value as an unsigned int.</param>
        /// <returns>True if values passed can form a color.</returns>
        public static bool IsColor(uint a, uint r, uint g, uint b) =>
            b <= byte.MaxValue && g <= byte.MaxValue && r <= byte.MaxValue && a <= byte.MaxValue;

        /// <summary>
        /// Returns byte array of padding bytes required to start at offset % start_at = 0
        /// </summary>
        /// <param name="length">Length of the current stream to be added to.</param>
        /// <param name="startAt">Offset at which padding ends.</param>
        /// <returns>Byte array of padding bytes.</returns>
        public static byte[] GetPaddingArray(int length, byte startAt)
        {
            byte[] result;
            var difference = startAt - (length % startAt);
            if (difference == startAt) difference = -1;
            switch (difference)
            {
                case -1:
                    result = Array.Empty<byte>();
                    return result;
                case 4:
                    result = new byte[4 + startAt];
                    result[4] = (byte)(startAt - 4);
                    return result;
                case 8:
                    result = new byte[8];
                    return result;
                default:
                    result = new byte[difference];
                    result[4] = (byte)(difference - 8);
                    return result;
            }
        }
    
        /// <summary>
        /// Checks if the file is of supported image format and if it exists.
        /// </summary>
        /// <param name="filepath">File to be checked.</param>
        /// <returns>True if file exists and is of valid image format.</returns>
        public static bool IsImageFormat(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
                return false;
            if (!File.Exists(filepath))
                return false;
            var ext = Path.GetExtension(filepath);
            switch (ext)
            {
                case ".png":
                case ".jpg":
                case ".bmp":
                case ".tiff":
                    return true;
                default:
                    return false;
            }
        }    
    }
}