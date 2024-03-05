using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private eCarbonPaint _paintType = eCarbonPaint.GLOSS;

        /// <summary>
        /// Paint type value of the preset ride.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eCarbonPaint PaintType
        {
            get => _paintType;
            set
            {
                if (Enum.IsDefined(typeof(eCarbonPaint), value))
                {
                    _paintType = value;
                    Modified = true;
                }
                else
                    throw new MappingFailException();
            }
        }
    }
}