using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _vinylName = BaseArguments.NULL;

        /// <summary>
        /// Vinyl name value of the preset ride.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string VinylName
        {
            get => _vinylName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _vinylName = value;
                Modified = true;
            }
        }
    }
}