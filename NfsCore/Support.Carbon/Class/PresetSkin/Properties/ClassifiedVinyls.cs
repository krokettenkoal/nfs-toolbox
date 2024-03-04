using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        private string _genericvinyl = BaseArguments.NULL;
        private string _vectorvinyl = BaseArguments.NULL;

        /// <summary>
        /// Generic vinyl value of the preset skin.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string GenericVinyl
        {
            get => this._genericvinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._genericvinyl = value;
            }
        }

        /// <summary>
        /// Vector vinyl value of the preset skin.
        /// </summary>
        [AccessModifiable()]
        public string VectorVinyl
        {
            get => this._vectorvinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._vectorvinyl = value;
            }
        }
    }
}