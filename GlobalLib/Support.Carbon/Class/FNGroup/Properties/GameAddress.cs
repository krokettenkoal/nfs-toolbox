﻿namespace GlobalLib.Support.Carbon.Class
{
    public partial class FNGroup
    {
        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public Core.GameINT GameINT { get => Core.GameINT.Carbon; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR { get => Core.GameSTR.Carbon; }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.Carbon Database { get; set; }
    }
}