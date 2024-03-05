using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Suspension : SubPart, ICopyable<Suspension>
    {
        // Front values
        public float ShockStiffnessFront { get; set; }
        public float ShockExtStiffnessFront { get; set; }
        public float SpringProgressionFront { get; set; }
        public float ShockValvingFront { get; set; }
        public float SwayBarFront { get; set; }
        public float TrackWidthFront { get; set; }
        public float CounterBiasFront { get; set; }
        public float ShockDigressionFront { get; set; }

        // Read values
        public float ShockStiffnessRear { get; set; }
        public float ShockExtStiffnessRear { get; set; }
        public float SpringProgressionRear { get; set; }
        public float ShockValvingRear { get; set; }
        public float SwayBarRear { get; set; }
        public float TrackWidthRear { get; set; }
        public float CounterBiasRear { get; set; }
        public float ShockDigressionRear { get; set; }

        public Suspension()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Suspension PlainCopy()
        {
            var result = new Suspension();
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