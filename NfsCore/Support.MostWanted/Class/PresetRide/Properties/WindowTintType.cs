using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _windowTintType = BaseArguments.STOCK;

        /// <summary>
        /// Window tint type value of the preset ride.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string WindowTintType
        {
            get => _windowTintType;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value == BaseArguments.STOCK || Map.WindowTintMap.Contains(value))
                    _windowTintType = value;
                else
                    throw new MappingFailException("This value should be either a valid windshield type, or STOCK.");
                Modified = true;
            }
        }
    }
}