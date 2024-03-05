using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Parts.PresetParts
{
    public class Vinyl : SubPart, ICopyable<Vinyl>
    {
        private string _vectorVinyl = BaseArguments.NULL;
        private byte _swatch1;
        private byte _swatch2;
        private byte _swatch3;
        private byte _swatch4;

        public string VectorVinyl
        {
            get => _vectorVinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _vectorVinyl = value;
            }
        }

        public short PositionY { get; set; }
        public short PositionX { get; set; }
        public sbyte Rotation { get; set; }
        public sbyte Skew { get; set; }
        public sbyte ScaleY { get; set; }
        public sbyte ScaleX { get; set; }
        public byte Saturation1 { get; set; }
        public byte Brightness1 { get; set; }
        public byte Saturation2 { get; set; }
        public byte Brightness2 { get; set; }
        public byte Saturation3 { get; set; }
        public byte Brightness3 { get; set; }
        public byte Saturation4 { get; set; }
        public byte Brightness4 { get; set; }

        public byte SwatchColor1
        {
            get => _swatch1;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch1 = value;
            }
        }

        public byte SwatchColor2
        {
            get => _swatch2;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch2 = value;
            }
        }

        public byte SwatchColor3
        {
            get => _swatch3;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch3 = value;
            }
        }

        public byte SwatchColor4
        {
            get => _swatch4;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 90.");
                _swatch4 = value;
            }
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Vinyl PlainCopy()
        {
            var result = new Vinyl();
            var thisType = GetType();
            var resultType = result.GetType();
            foreach (var thisProperty in thisType.GetProperties())
            {
                var resultField = resultType.GetProperty(thisProperty.Name);
                resultField?.SetValue(result, thisProperty.GetValue(this));
            }

            return result;
        }

        public unsafe void Read(byte* bytePtrT)
        {
            var key = *(uint*) bytePtrT;
            _vectorVinyl = Map.Lookup(key, true) ?? $"0x{key:X8}";
            PositionY = *(short*) (bytePtrT + 0x04);
            PositionX = *(short*) (bytePtrT + 0x06);
            Rotation = *(sbyte*) (bytePtrT + 0x08);
            Skew = *(sbyte*) (bytePtrT + 0x09);
            ScaleY = *(sbyte*) (bytePtrT + 0x0A);
            ScaleX = *(sbyte*) (bytePtrT + 0x0B);
            SwatchColor1 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x0C), false));
            SwatchColor2 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x14), false));
            SwatchColor3 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x1C), false));
            SwatchColor4 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x24), false));
            Saturation1 = *(bytePtrT + 0x10);
            Saturation2 = *(bytePtrT + 0x18);
            Saturation3 = *(bytePtrT + 0x20);
            Saturation4 = *(bytePtrT + 0x28);
            Brightness1 = *(bytePtrT + 0x11);
            Brightness2 = *(bytePtrT + 0x19);
            Brightness3 = *(bytePtrT + 0x21);
            Brightness4 = *(bytePtrT + 0x29);
        }

        public unsafe void Write(byte* bytePtrT)
        {
            *(uint*) bytePtrT = Bin.SmartHash(VectorVinyl);
            *(short*) (bytePtrT + 0x04) = PositionY;
            *(short*) (bytePtrT + 0x06) = PositionX;
            *(bytePtrT + 0x08) = (byte) Rotation;
            *(bytePtrT + 0x09) = (byte) Skew;
            *(bytePtrT + 0x0A) = (byte) ScaleY;
            *(bytePtrT + 0x0B) = (byte) ScaleX;
            *(uint*) (bytePtrT + 0x0C) = Bin.Hash(Resolve.GetVinylString(SwatchColor1));
            *(uint*) (bytePtrT + 0x14) = Bin.Hash(Resolve.GetVinylString(SwatchColor2));
            *(uint*) (bytePtrT + 0x1C) = Bin.Hash(Resolve.GetVinylString(SwatchColor3));
            *(uint*) (bytePtrT + 0x24) = Bin.Hash(Resolve.GetVinylString(SwatchColor4));
            *(bytePtrT + 0x10) = Saturation1;
            *(bytePtrT + 0x18) = Saturation2;
            *(bytePtrT + 0x20) = Saturation3;
            *(bytePtrT + 0x28) = Saturation4;
            *(bytePtrT + 0x11) = Brightness1;
            *(bytePtrT + 0x19) = Brightness2;
            *(bytePtrT + 0x21) = Brightness3;
            *(bytePtrT + 0x29) = Brightness4;
        }
    }
}