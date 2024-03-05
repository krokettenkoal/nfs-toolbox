using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Turbo : SubPart, ICopyable<Turbo>
    {
        public float TurboBraking { get; set; }
        public float TurboVacuum { get; set; }
        public float TurboHeatHigh { get; set; }
        public float TurboHeatLow { get; set; }
        public float TurboHighBoost { get; set; }
        public float TurboLowBoost { get; set; }
        public float TurboSpool { get; set; }
        public float TurboSpoolTimeDown { get; set; }
        public float TurboSpoolTimeUp { get; set; }

        public Turbo()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Turbo PlainCopy()
        {
            var result = new Turbo();
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