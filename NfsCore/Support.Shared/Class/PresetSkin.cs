using System;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;
using NfsCore.Utils;

namespace NfsCore.Support.Shared.Class
{
    public class PresetSkin : Collectable
    {
        #region Private Fields

        private eCarbonPaint _painttype = eCarbonPaint.GLOSS;
        private byte _paintswatch = 1;
        private float _paintsaturation = 0;
        private float _paintbrightness = 0;

        #endregion

        #region AccessModifiable Properties

        /// <summary>
        /// Paint type value of the preset skin.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eCarbonPaint PaintType
        {
            get => _painttype;
            set
            {
                if (Enum.IsDefined(typeof(eCarbonPaint), value))
                    _painttype = value;
                else
                    throw new MappingFailException();
            }
        }

        /// <summary>
        /// Gradient color value of the paint of the preset skin. Range: 0-90.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public byte PaintSwatch
        {
            get => _paintswatch;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be in range 0 to 90.");
                _paintswatch = value;
            }
        }

        /// <summary>
        /// Saturation value of the paint of the preset skin. Range: (float)0-1.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float PaintSaturation
        {
            get => _paintsaturation;
            set
            {
                if (value is > 1 or < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be in range 0 to 1.");
                _paintsaturation = value;
            }
        }

        /// <summary>
        /// Brightness value of the paint of the preset skin. Range: (float)0-1.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public float PaintBrightness
        {
            get => _paintbrightness;
            set
            {
                if (value is > 1 or < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed should be in range 0 to 1.");
                _paintbrightness = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles preset skin into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset skin.</returns>
        public virtual byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles preset skin array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the preset skin array.</param>
        protected virtual unsafe void Disassemble(byte* bytePtrT) { }

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}