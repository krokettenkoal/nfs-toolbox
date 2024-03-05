using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Camera : SubPart, ICopyable<Camera>
    {
        public float CameraAngle { get; set; }
        public float CameraLag { get; set; }
        public float CameraHeight { get; set; }
        public float CameraLatOffset { get; set; }

        public Camera()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Camera PlainCopy()
        {
            var result = new Camera();
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