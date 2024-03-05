using NfsCore.Global;

namespace NfsCore.Support.Carbon.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Carbon;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.CarbonDb Database { get; }
    }
}