using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        private eSpoiler _spoiler = eSpoiler.SPOILER;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eSpoiler Spoiler
        {
            get => this._spoiler;
            set
            {
                if (Enum.IsDefined(typeof(eSpoiler), value))
                    this._spoiler = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}