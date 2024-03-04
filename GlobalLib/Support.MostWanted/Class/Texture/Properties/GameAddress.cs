﻿using GlobalLib.Core;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.MostWanted;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public override Database.MostWanted Database { get; }
    }
}