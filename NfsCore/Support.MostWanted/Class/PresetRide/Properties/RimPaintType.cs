using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _rim_paint = BaseArguments.NULL;

        /// <summary>
        /// Rim paint value of the preset ride.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string RimPaint
        {
            get => this._rim_paint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                if (value == BaseArguments.NULL || Map.BinKeys.ContainsValue(value))
                    this._rim_paint = value;
                else
                    throw new MappingFailException();
                this.Modified = true;
            }
        }
    }
}