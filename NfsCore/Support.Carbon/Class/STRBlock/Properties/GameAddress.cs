﻿using NfsCore.Global;


namespace NfsCore.Support.Carbon.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.Carbon; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.Carbon.ToString(); }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.CarbonDb Database { get; set; }
    }
}