using System;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Carbon.Parts.PresetParts
{
    public class Autosculpt : SubPart, ICopyable<Autosculpt>
    {
        private byte _zone1;
        private byte _zone2;
        private byte _zone3;
        private byte _zone4;
        private byte _zone5;
        private byte _zone6;
        private byte _zone7;
        private byte _zone8;
        private byte _zone9;

        public byte AutosculptZone1
        {
            get => _zone1;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone1 = value;
            }
        }

        public byte AutosculptZone2
        {
            get => _zone2;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone2 = value;
            }
        }

        public byte AutosculptZone3
        {
            get => _zone3;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone3 = value;
            }
        }

        public byte AutosculptZone4
        {
            get => _zone4;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone4 = value;
            }
        }

        public byte AutosculptZone5
        {
            get => _zone5;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone5 = value;
            }
        }

        public byte AutosculptZone6
        {
            get => _zone6;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone6 = value;
            }
        }

        public byte AutosculptZone7
        {
            get => _zone7;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone7 = value;
            }
        }

        public byte AutosculptZone8
        {
            get => _zone8;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone8 = value;
            }
        }

        public byte AutosculptZone9
        {
            get => _zone9;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0 to 100.");
                _zone9 = value;
            }
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Autosculpt PlainCopy()
        {
            var result = new Autosculpt();
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