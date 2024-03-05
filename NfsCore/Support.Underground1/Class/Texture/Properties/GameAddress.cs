using NfsCore.Global;

namespace NfsCore.Support.Underground1.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground1;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.Underground1Db Database { get; }
    }
}