using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _rimPaint = BaseArguments.NULL;

        /// <summary>
        /// Rim paint value of the preset ride.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string RimPaint
        {
            get => _rimPaint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value == BaseArguments.NULL || Map.BinKeys.ContainsValue(value))
                    _rimPaint = value;
                else
                    throw new MappingFailException();
                Modified = true;
            }
        }
    }
}