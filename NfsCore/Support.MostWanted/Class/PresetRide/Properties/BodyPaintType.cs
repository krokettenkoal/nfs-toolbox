using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        private string _bodyPaint = BaseArguments.BPAINT;

        /// <summary>
        /// Body paint value of the preset ride.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string BodyPaint
        {
            get => _bodyPaint;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (Map.BinKeys.ContainsValue(value))
                    _bodyPaint = value;
                else
                    throw new MappingFailException();
                Modified = true;
            }
        }
    }
}