using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private ushort[] _rigidControls;
        private eBoolean _isSuv = eBoolean.False;

        /// <summary>
        /// Defines whether the car is an SUV.
        /// </summary>
        [AccessModifiable]
        public eBoolean IsSUV
        {
            get => _isSuv;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isSuv = value;
                else
                    throw new InvalidCastException("Value passed is not of boolean type.");
            }
        }

        public override string CollisionInternalName => CollName;
    }
}