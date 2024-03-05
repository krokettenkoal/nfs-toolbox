using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Ecar : SubPart, ICopyable<Ecar>
    {
        public float EcarUnknown1 { get; set; } = 2F;
        public float EcarUnknown2 { get; set; } = 3F;
        public float HandlingBuffer { get; set; }
        public float TopSuspFrontHeightReduce { get; set; }
        public float TopSuspRearHeightReduce { get; set; }
        public int NumPlayerCameras { get; set; } = 6;
        public int NumAICameras { get; set; } = 6;
        public int Cost { get; set; }

        public Ecar()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Ecar PlainCopy()
        {
            var result = new Ecar();
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