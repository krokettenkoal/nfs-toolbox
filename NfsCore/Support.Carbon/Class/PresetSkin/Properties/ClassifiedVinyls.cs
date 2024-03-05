using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        private string _genericVinyl = BaseArguments.NULL;
        private string _vectorVinyl = BaseArguments.NULL;

        /// <summary>
        /// Generic vinyl value of the preset skin.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string GenericVinyl
        {
            get => _genericVinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _genericVinyl = value;
            }
        }

        /// <summary>
        /// Vector vinyl value of the preset skin.
        /// </summary>
        [AccessModifiable]
        public string VectorVinyl
        {
            get => _vectorVinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _vectorVinyl = value;
            }
        }
    }
}