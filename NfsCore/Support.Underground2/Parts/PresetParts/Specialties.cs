using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.PresetParts
{
    public class Specialties : SubPart, ICopyable<Specialties>
    {
        #region Private Fields

        private string _neonBody = BaseArguments.NULL;
        private string _neonEngine = BaseArguments.NULL;
        private string _neonCabin = BaseArguments.NULL;
        private string _neonTrunk = BaseArguments.NULL;
        private byte _neonCabinStyle = 0;
        private string _headlightBulb = BaseArguments.STOCK;
        private string _doorStyle = BaseArguments.STOCK;
        private string _hydraulicsStyle = BaseArguments.NULL;
        private string _nosPurgeStyle = BaseArguments.NULL;

        #endregion

        #region Public Properties

        public string NeonBody
        {
            get => _neonBody;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _neonBody = value;
            }
        }

        public string NeonEngine
        {
            get => _neonEngine;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _neonEngine = value;
            }
        }

        public string NeonCabin
        {
            get => _neonCabin;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _neonCabin = value;
            }
        }

        public string NeonTrunk
        {
            get => _neonTrunk;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _neonTrunk = value;
            }
        }

        public byte NeonCabinStyle
        {
            get => _neonCabinStyle;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value), "This value should be in range 0-3.");
                _neonCabinStyle = value;
            }
        }

        public string HeadlightBulbStyle
        {
            get => _headlightBulb;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.STOCK && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _headlightBulb = value;
            }
        }

        public string DoorOpeningStyle
        {
            get => _doorStyle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.STOCK && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _doorStyle = value;
            }
        }

        public string HydraulicsStyle
        {
            get => _hydraulicsStyle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _hydraulicsStyle = value;
            }
        }

        public string NOSPurgeStyle
        {
            get => _nosPurgeStyle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _nosPurgeStyle = value;
            }
        }

        #endregion

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Specialties PlainCopy()
        {
            var result = new Specialties();
            var thisType = GetType();
            var resultType = result.GetType();
            foreach (var thisField in thisType.GetProperties())
            {
                var resultField = resultType.GetProperty(thisField.Name);
                resultField?.SetValue(result, thisField.GetValue(this));
            }

            return result;
        }
    }
}