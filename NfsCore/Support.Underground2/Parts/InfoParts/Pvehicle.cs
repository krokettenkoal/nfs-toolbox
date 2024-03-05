using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Pvehicle : SubPart, ICopyable<Pvehicle>
    {
        public float Massx1000Multiplier { get; set; } = 1;
        public float TensorScaleX { get; set; } = 4;
        public float TensorScaleY { get; set; } = 3;
        public float TensorScaleZ { get; set; } = 2;
        public float TensorScaleW { get; set; } = 1;
        public float InitialHandlingRating { get; set; }
        public float TopSpeedUnderflow { get; set; }
        public float StockTopSpeedLimiter { get; set; }

        public Pvehicle()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Pvehicle PlainCopy()
        {
            var result = new Pvehicle();
            var thisType = GetType();
            var resultType = result.GetType();
            foreach (var thisProperty in thisType.GetProperties())
            {
                var resultField = resultType.GetProperty(thisProperty.Name);
                resultField?.SetValue(result, thisProperty.GetValue(this));
            }

            return result;
        }
    }
}