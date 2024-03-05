using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        private eSpoiler _spoiler = eSpoiler.SPOILER;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eSpoiler Spoiler
        {
            get => _spoiler;
            set
            {
                if (Enum.IsDefined(typeof(eSpoiler), value))
                    _spoiler = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}