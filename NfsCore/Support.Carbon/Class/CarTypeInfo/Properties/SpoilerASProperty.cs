using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        private eSpoilerAS2 _spoilerAs = eSpoilerAS2.SPOILER_AS2;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eSpoilerAS2 SpoilerAS
        {
            get => _spoilerAs;
            set
            {
                if (Enum.IsDefined(typeof(eSpoilerAS2), value))
                    _spoilerAs = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}