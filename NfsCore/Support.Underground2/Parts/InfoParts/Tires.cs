using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Tires : SubPart, ICopyable<Tires>
    {
        public float StaticGripScale { get; set; }
        public float YawSpeedScale { get; set; }
        public float SteeringAmplifier { get; set; }
        public float DynamicGripScale { get; set; }
        public float SteeringResponse { get; set; }
        public float DriftYawControl { get; set; }
        public float DriftCounterSteerBuildUp { get; set; }
        public float DriftCounterSteerReduction { get; set; }
        public float PowerSlideBreakThru1 { get; set; }
        public float PowerSlideBreakThru2 { get; set; }

        public Tires()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Tires PlainCopy()
        {
            var result = new Tires();
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