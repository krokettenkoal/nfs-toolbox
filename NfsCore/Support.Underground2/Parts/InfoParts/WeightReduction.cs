using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class WeightReduction : SubPart, ICopyable<WeightReduction>
    {
        public float WeightReductionMassMultiplier { get; set; }
        public float WeightReductionGripAddon { get; set; }
        public float WeightReductionHandlingRating { get; set; }

        public WeightReduction()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public WeightReduction PlainCopy()
        {
            var result = new WeightReduction();
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