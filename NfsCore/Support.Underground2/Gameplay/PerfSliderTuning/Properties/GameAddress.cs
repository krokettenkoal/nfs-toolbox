﻿using NfsCore.Global;


namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.Underground2; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.Underground2.ToString(); }

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public Database.Underground2Db Database { get; set; }
    }
}