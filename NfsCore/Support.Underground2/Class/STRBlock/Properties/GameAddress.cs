using NfsCore.Global;

namespace NfsCore.Support.Underground2.Class
{
    public partial class STRBlock
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground2;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.Underground2Db Database { get; }
    }
}