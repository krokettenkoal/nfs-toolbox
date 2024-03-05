using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Engine : SubPart, ICopyable<Engine>
    {
        public float SpeedRefreshRate { get; set; }
        public float EngineTorque1 { get; set; }
        public float EngineTorque2 { get; set; }
        public float EngineTorque3 { get; set; }
        public float EngineTorque4 { get; set; }
        public float EngineTorque5 { get; set; }
        public float EngineTorque6 { get; set; }
        public float EngineTorque7 { get; set; }
        public float EngineTorque8 { get; set; }
        public float EngineTorque9 { get; set; }
        public float EngineBraking1 { get; set; }
        public float EngineBraking2 { get; set; }
        public float EngineBraking3 { get; set; }

        public Engine()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Engine PlainCopy()
        {
            var result = new Engine();
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