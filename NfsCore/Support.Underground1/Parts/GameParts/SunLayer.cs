using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground1.Parts.GameParts
{
    public class SunLayer : SubPart, ICopyable<SunLayer>
    {
        /* 0x0000 */
        public eSunTexture SunTextureType { get; set; }

        /* 0x0004 */
        public eSunAlpha SunAlphaType { get; set; }

        /* 0x0008 */
        public float IntensityScale { get; set; }

        /* 0x000C */
        public float Size { get; set; }

        /* 0x0010 */
        public float OffsetX { get; set; }

        /* 0x0014 */
        public float OffsetY { get; set; }

        /* 0x0018 */
        public byte ColorAlpha { get; set; }

        /* 0x0019 */
        public byte ColorRed { get; set; }

        /* 0x001A */
        public byte ColorGreen { get; set; }

        /* 0x001B */
        public byte ColorBlue { get; set; }

        /* 0x001C */
        public int Angle { get; set; }

        /* 0x0020 */
        public float SweepAngleAmount { get; set; }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public SunLayer PlainCopy()
        {
            var result = new SunLayer();
            var thisType = GetType();
            var resultType = result.GetType();
            foreach (var thisProperty in thisType.GetProperties())
            {
                var resultField = resultType.GetProperty(thisProperty.Name);
                if (resultField == null)
                    continue;
                resultField.SetValue(result, thisProperty.GetValue(this));
            }

            return result;
        }

        public unsafe void Read(byte* bytePtrT)
        {
            SunTextureType = (eSunTexture) (*(int*) bytePtrT);
            SunAlphaType = (eSunAlpha) (*(int*) (bytePtrT + 4));
            IntensityScale = *(float*) (bytePtrT + 8);
            Size = *(float*) (bytePtrT + 0xC);
            OffsetX = *(float*) (bytePtrT + 0x10);
            OffsetY = *(float*) (bytePtrT + 0x14);
            ColorAlpha = *(bytePtrT + 0x18);
            ColorRed = *(bytePtrT + 0x19);
            ColorGreen = *(bytePtrT + 0x1A);
            ColorBlue = *(bytePtrT + 0x1B);
            Angle = *(int*) (bytePtrT + 0x1C);
            SweepAngleAmount = *(float*) (bytePtrT + 0x20);
        }

        public unsafe void Write(byte* bytePtrT)
        {
            *(int*) bytePtrT = (int) SunTextureType;
            *(int*) (bytePtrT + 4) = (int) SunAlphaType;
            *(float*) (bytePtrT + 8) = IntensityScale;
            *(float*) (bytePtrT + 0xC) = Size;
            *(float*) (bytePtrT + 0x10) = OffsetX;
            *(float*) (bytePtrT + 0x14) = OffsetY;
            *(bytePtrT + 0x18) = ColorAlpha;
            *(bytePtrT + 0x19) = ColorRed;
            *(bytePtrT + 0x1A) = ColorGreen;
            *(bytePtrT + 0x1B) = ColorBlue;
            *(int*) (bytePtrT + 0x1C) = Angle;
            *(float*) (bytePtrT + 0x20) = SweepAngleAmount;
        }
    }
}