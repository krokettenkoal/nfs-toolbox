﻿using NfsCore.Global;


namespace NfsCore.Support.MostWanted.Class
{
    public partial class FNGroup
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.MostWanted; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.MostWanted.ToString(); }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.MostWantedDb Database { get; set; }
    }
}