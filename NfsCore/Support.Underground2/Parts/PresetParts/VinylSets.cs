using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.PresetParts
{
    public class VinylSets : SubPart, ICopyable<VinylSets>
    {
        #region Private Fields

        private string _vinylLayer0 = BaseArguments.NULL;
        private string _vinylLayer1 = BaseArguments.NULL;
        private string _vinylLayer2 = BaseArguments.NULL;
        private string _vinylLayer3 = BaseArguments.NULL;
        private string _vinyl0Color0 = BaseArguments.NULL;
        private string _vinyl0Color1 = BaseArguments.NULL;
        private string _vinyl0Color2 = BaseArguments.NULL;
        private string _vinyl0Color3 = BaseArguments.NULL;
        private string _vinyl1Color0 = BaseArguments.NULL;
        private string _vinyl1Color1 = BaseArguments.NULL;
        private string _vinyl1Color2 = BaseArguments.NULL;
        private string _vinyl1Color3 = BaseArguments.NULL;
        private string _vinyl2Color0 = BaseArguments.NULL;
        private string _vinyl2Color1 = BaseArguments.NULL;
        private string _vinyl2Color2 = BaseArguments.NULL;
        private string _vinyl2Color3 = BaseArguments.NULL;
        private string _vinyl3Color0 = BaseArguments.NULL;
        private string _vinyl3Color1 = BaseArguments.NULL;
        private string _vinyl3Color2 = BaseArguments.NULL;
        private string _vinyl3Color3 = BaseArguments.NULL;

        #endregion

        #region Public Properties

        public string VinylLayer0
        {
            get => _vinylLayer0;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _vinylLayer0 = value;
            }
        }

        public string VinylLayer1
        {
            get => _vinylLayer1;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _vinylLayer1 = value;
            }
        }

        public string VinylLayer2
        {
            get => _vinylLayer2;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _vinylLayer2 = value;
            }
        }

        public string VinylLayer3
        {
            get => _vinylLayer3;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _vinylLayer3 = value;
            }
        }

        public string Vinyl0_Color0
        {
            get => _vinyl0Color0;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl0Color0 = value;
            }
        }

        public string Vinyl0_Color1
        {
            get => _vinyl0Color1;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl0Color1 = value;
            }
        }

        public string Vinyl0_Color2
        {
            get => _vinyl0Color2;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl0Color2 = value;
            }
        }

        public string Vinyl0_Color3
        {
            get => _vinyl0Color3;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl0Color3 = value;
            }
        }

        public string Vinyl1_Color0
        {
            get => _vinyl1Color0;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl1Color0 = value;
            }
        }

        public string Vinyl1_Color1
        {
            get => _vinyl1Color1;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl1Color1 = value;
            }
        }

        public string Vinyl1_Color2
        {
            get => _vinyl1Color2;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl1Color2 = value;
            }
        }

        public string Vinyl1_Color3
        {
            get => _vinyl1Color3;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl1Color3 = value;
            }
        }

        public string Vinyl2_Color0
        {
            get => _vinyl2Color0;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl2Color0 = value;
            }
        }

        public string Vinyl2_Color1
        {
            get => _vinyl2Color1;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl2Color1 = value;
            }
        }

        public string Vinyl2_Color2
        {
            get => _vinyl2Color2;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl2Color2 = value;
            }
        }

        public string Vinyl2_Color3
        {
            get => _vinyl2Color3;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl2Color3 = value;
            }
        }

        public string Vinyl3_Color0
        {
            get => _vinyl3Color0;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl3Color0 = value;
            }
        }

        public string Vinyl3_Color1
        {
            get => _vinyl3Color1;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl3Color1 = value;
            }
        }

        public string Vinyl3_Color2
        {
            get => _vinyl3Color2;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl3Color2 = value;
            }
        }

        public string Vinyl3_Color3
        {
            get => _vinyl3Color3;
            set
            {
                if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
                    throw new MappingFailException();
                _vinyl3Color3 = value;
            }
        }

        #endregion

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public VinylSets PlainCopy()
        {
            var result = new VinylSets();
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