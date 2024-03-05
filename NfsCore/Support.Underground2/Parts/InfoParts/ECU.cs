using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class ECU : SubPart, ICopyable<ECU>
    {
        public float ECUx1000Add { get; set; }
        public float ECUx2000Add { get; set; }
        public float ECUx3000Add { get; set; }
        public float ECUx4000Add { get; set; }
        public float ECUx5000Add { get; set; }
        public float ECUx6000Add { get; set; }
        public float ECUx7000Add { get; set; }
        public float ECUx8000Add { get; set; }
        public float ECUx9000Add { get; set; }
        public float ECUx10000Add { get; set; }
        public float ECUx11000Add { get; set; }
        public float ECUx12000Add { get; set; }

        public ECU()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public ECU PlainCopy()
        {
            var result = new ECU();
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