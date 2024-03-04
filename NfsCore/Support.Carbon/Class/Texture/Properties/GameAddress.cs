using NfsCore.Global;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Carbon;
        
        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public override Database.Carbon Database { get; }
    }
}