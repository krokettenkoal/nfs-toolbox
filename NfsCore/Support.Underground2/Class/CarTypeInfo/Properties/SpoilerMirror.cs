using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
        private eSpoiler _spoiler = eSpoiler.SPOILER;
        private eMirrorTypes _mirrors = eMirrorTypes.MIRRORS;

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

        [AccessModifiable()]
        [StaticModifiable()]
        public eMirrorTypes Mirrors
        {
            get => this._mirrors;
            set
            {
                if (Enum.IsDefined(typeof(eMirrorTypes), value))
                    this._mirrors = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}