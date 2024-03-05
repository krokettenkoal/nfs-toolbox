using NfsCore.Global;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Carbon;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.CarbonDb Database { get; }

        public const int MaxCNameLength = 0x1B;
        public const int CNameOffsetAt = 0x1C;
        public const int BaseClassSize = 0xF4;
    }
}