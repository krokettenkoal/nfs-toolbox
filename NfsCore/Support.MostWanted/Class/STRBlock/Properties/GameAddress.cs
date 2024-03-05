using NfsCore.Global;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.MostWanted;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.MostWantedDb Database { get; }
    }
}