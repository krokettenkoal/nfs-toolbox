using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _vinylname = BaseArguments.NULL;

        /// <summary>
        /// Vinyl name value of the preset ride.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string VinylName
        {
            get => this._vinylname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._vinylname = value;
                this.Modified = true;
            }
        }
    }
}