using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class CarInfoWheel : SubPart, ICopyable<CarInfoWheel>
    {
        public float XValue { get; set; }
        public float Springs { get; set; }
        public float RideHeight { get; set; }
        public float UnknownVal { get; set; }
        public float Diameter { get; set; }
        public float TireSkidWidth { get; set; }
        public int WheelID { get; set; }
        public float YValue { get; set; }
        public float WideBodyYValue { get; set; }

        public CarInfoWheel()
        {
        }

        public CarInfoWheel(int id)
        {
            WheelID = id;
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public CarInfoWheel PlainCopy()
        {
            var result = new CarInfoWheel();
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