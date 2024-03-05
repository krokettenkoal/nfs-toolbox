using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private string _wingMirrorStyle = BaseArguments.STOCK;

        /// <summary>
        /// Wing mirror style value of the preset ride. Range: 0-40.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string WingMirrorStyle
        {
            get => _wingMirrorStyle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value == BaseArguments.NULL)
                    throw new Exception("This value can be only STOCK or a hexadecimal hash of a mirror style.");
                _wingMirrorStyle = value;
                Modified = true;
            }
        }
    }
}