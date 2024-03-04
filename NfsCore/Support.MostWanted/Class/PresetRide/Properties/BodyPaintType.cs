using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _body_paint = BaseArguments.BPAINT;

        /// <summary>
        /// Body paint value of the preset ride.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string BodyPaint
        {
            get => this._body_paint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                if (Map.BinKeys.ContainsValue(value))
                    this._body_paint = value;
                else
                    throw new MappingFailException();
                this.Modified = true;
            }
        }
    }
}