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

        [AccessModifiable]
        [StaticModifiable]
        public eMirrorTypes Mirrors
        {
            get => _mirrors;
            set
            {
                if (Enum.IsDefined(typeof(eMirrorTypes), value))
                    _mirrors = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}