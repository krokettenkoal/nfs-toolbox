using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private string _specificVinyl = BaseArguments.NULL;
        private string _genericVinyl = BaseArguments.NULL;

        /// <summary>
        /// Specific vinyl value of the preset ride.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string SpecificVinyl
        {
            get => _specificVinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _specificVinyl = value;
                Modified = true;
            }
        }

        /// <summary>
        /// Generic vinyl value of the preset car.
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
                Modified = true;
            }
        }
    }
}