using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.Interface;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Parts.CarParts
{
    public class CarSkin : SubPart, ICopyable<CarSkin>
    {
        private string _skinDescription = "Silver";
        private string _materialUsed = BaseArguments.NULL;
        private eCarSkinClass _skinClassKey = eCarSkinClass.Racing;

        public string SkinDescription
        {
            get => _skinDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _skinDescription = value;
            }
        }

        public string MaterialUsed
        {
            get => _materialUsed;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _materialUsed = value;
            }
        }

        public eCarSkinClass SkinClassKey
        {
            get => _skinClassKey;
            set
            {
                if (!Enum.IsDefined(typeof(eCarSkinClass), value))
                    throw new MappingFailException();
                _skinClassKey = value;
            }
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public CarSkin PlainCopy()
        {
            var result = new CarSkin();
            var thisType = GetType();
            var resultType = result.GetType();
            foreach (var thisProperty in thisType.GetProperties())
            {
                var resultField = resultType.GetProperty(thisProperty.Name);
                resultField?.SetValue(result, thisProperty.GetValue(this));
            }

            return result;
        }

        public unsafe void Read(byte* bytePtrT, out int id, out int index)
        {
            id = *(int*) bytePtrT;
            index = *(int*) (bytePtrT + 4);
            _skinDescription = ScriptX.NullTerminatedString(bytePtrT + 8, 0x20);
            var key = *(uint*) (bytePtrT + 0x2C);
            _materialUsed = Map.Lookup(key, true) ?? $"0x{key:X8}";
            _skinClassKey = (eCarSkinClass) (*(uint*) (bytePtrT + 0x30));
        }

        public unsafe void Write(byte* bytePtrT, int id, int index)
        {
            *(int*) bytePtrT = id;
            *(int*) (bytePtrT + 4) = index;
            for (var a1 = 0; a1 < _skinDescription.Length; ++a1)
                *(bytePtrT + 8 + a1) = (byte) _skinDescription[a1];
            *(uint*) (bytePtrT + 0x2C) = Bin.SmartHash(_materialUsed);
            *(uint*) (bytePtrT + 0x30) = (uint) _skinClassKey;
        }
    }
}