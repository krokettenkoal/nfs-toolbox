using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Brakes : SubPart, ICopyable<Brakes>
    {
        public float FrontDownForce { get; set; }
        public float RearDownForce { get; set; }
        public float BumpJumpForce { get; set; }
        public float SteeringRatio { get; set; }
        public float BrakeStrength { get; set; }
        public float HandBrakeStrength { get; set; }
        public float BrakeBias { get; set; }

        public Brakes()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Brakes PlainCopy()
        {
            var result = new Brakes();
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