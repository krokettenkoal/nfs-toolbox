using GlobalLib.Core;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground2;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public override Database.Underground2 Database { get; }
    }
}