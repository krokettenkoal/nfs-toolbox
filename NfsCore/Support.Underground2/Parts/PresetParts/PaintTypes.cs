using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.PresetParts
{
    public class PaintTypes : SubPart, ICopyable<PaintTypes>
    {
        #region Private Fields

        private string _basePaintType = BaseArguments.NULL;
        private string _enginePaintType = BaseArguments.NULL;
        private string _spoilerPaintType = BaseArguments.NULL;
        private string _brakesPaintType = BaseArguments.NULL;
        private string _exhaustPaintType = BaseArguments.NULL;
        private string _audioPaintType = BaseArguments.NULL;
        private string _rimsPaintType = BaseArguments.NULL;
        private string _spinnersPaintType = BaseArguments.NULL;
        private string _roofPaintType = BaseArguments.NULL;
        private string _mirrorsPaintType = BaseArguments.NULL;

        #endregion

        #region Public Properties

        public string BasePaintType
        {
            get => _basePaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
                    throw new MappingFailException();
                _basePaintType = value;
            }
        }

        public string EnginePaintType
        {
            get => _enginePaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
                    throw new MappingFailException();
                _enginePaintType = value;
            }
        }

        public string SpoilerPaintType
        {
            get => _spoilerPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
                    throw new MappingFailException();
                _spoilerPaintType = value;
            }
        }

        public string BrakesPaintType
        {
            get => _brakesPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2CaliperPaints.Contains(value))
                    throw new MappingFailException();
                _brakesPaintType = value;
            }
        }

        public string ExhaustPaintType
        {
            get => _exhaustPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
                    throw new MappingFailException();
                _exhaustPaintType = value;
            }
        }

        public string AudioPaintType
        {
            get => _audioPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
                    throw new MappingFailException();
                _audioPaintType = value;
            }
        }

        public string RimsPaintType
        {
            get => _rimsPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2RimPaints.Contains(value))
                    throw new MappingFailException();
                _rimsPaintType = value;
            }
        }

        public string SpinnersPaintType
        {
            get => _spinnersPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2RimPaints.Contains(value))
                    throw new MappingFailException();
                _spinnersPaintType = value;
            }
        }

        public string RoofPaintType
        {
            get => _roofPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
                    throw new MappingFailException();
                _roofPaintType = value;
            }
        }

        public string MirrorsPaintType
        {
            get => _mirrorsPaintType;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
                    throw new MappingFailException();
                _mirrorsPaintType = value;
            }
        }

        #endregion

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public PaintTypes PlainCopy()
        {
            var result = new PaintTypes();
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