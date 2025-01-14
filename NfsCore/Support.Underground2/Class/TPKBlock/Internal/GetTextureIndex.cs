﻿using System;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets index of the <see cref="Texture"/> in the <see cref="TPKBlock"/>.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/>.</param>
        /// <param name="type">Key type passed.</param>
        /// <returns>Index number as an integer. If element does not exist, returns -1.</returns>
        public override int GetTextureIndex(uint key, eKeyType type)
        {
            switch (type)
            {
                case eKeyType.BINKEY:
                    for (var a1 = 0; a1 < Textures.Count; ++a1)
                    {
                        if (Textures[a1].BinKey == key) return a1;
                    }

                    break;

                case eKeyType.VLTKEY:
                    for (var a1 = 0; a1 < Textures.Count; ++a1)
                    {
                        if (Textures[a1].VltKey == key) return a1;
                    }

                    break;

                case eKeyType.CUSTOM:
                    throw new NotImplementedException();
                case eKeyType.DEFAULT:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return -1;
        }
    }
}