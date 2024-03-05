using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.GameParts
{
    public class Opponent : SubPart, ICopyable<Opponent>
    {
        private string _name = BaseArguments.NULL;
        private string _presetRide = BaseArguments.RANDOM;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _name = value;
            }
        }

        public ushort StatsMultiplier { get; set; }

        public string PresetRide
        {
            get => _presetRide;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _presetRide = value;
            }
        }

        public byte SkillEasy { get; set; }
        public byte SkillMedium { get; set; }
        public byte SkillHard { get; set; }
        public byte CatchUp { get; set; }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Opponent PlainCopy()
        {
            var result = new Opponent();
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