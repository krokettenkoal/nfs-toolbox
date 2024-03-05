using System;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Disassembles preset skin array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the preset skin array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            var key = *(uint*) (bytePtrT + 0x28);
            if (Enum.IsDefined(typeof(eCarbonPaint), key))
                PaintType = (eCarbonPaint) key;
            else
                PaintType = eCarbonPaint.GLOSS;

            // Paint Swatch
            PaintSwatch = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x2C), false));

            // Saturation and Brightness
            PaintSaturation = *(float*) (bytePtrT + 0x30);
            PaintBrightness = *(float*) (bytePtrT + 0x34);

            // Generic vinyl
            key = *(uint*) (bytePtrT + 0x38);
            _genericVinyl = Map.Lookup(key, true) ?? $"0x{key:X8}";

            // Vinyl
            key = *(uint*) (bytePtrT + 0x3C);
            _vectorVinyl = Map.Lookup(key, true) ?? $"0x{key:X8}";
            PositionY = *(short*) (bytePtrT + 0x40);
            PositionX = *(short*) (bytePtrT + 0x42);
            Rotation = *(sbyte*) (bytePtrT + 0x44);
            Skew = *(sbyte*) (bytePtrT + 0x45);
            ScaleY = *(sbyte*) (bytePtrT + 0x46);
            ScaleX = *(sbyte*) (bytePtrT + 0x47);
            SwatchColor1 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x48), false));
            SwatchColor2 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x50), false));
            SwatchColor3 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x58), false));
            SwatchColor4 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x60), false));
            Saturation1 = *(bytePtrT + 0x4C);
            Saturation2 = *(bytePtrT + 0x54);
            Saturation3 = *(bytePtrT + 0x5C);
            Saturation4 = *(bytePtrT + 0x64);
            Brightness1 = *(bytePtrT + 0x4D);
            Brightness2 = *(bytePtrT + 0x55);
            Brightness3 = *(bytePtrT + 0x5D);
            Brightness4 = *(bytePtrT + 0x65);
        }
    }
}