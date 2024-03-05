using NfsCore.Global;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.MostWanted;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.MostWantedDb Database { get; }

        public const int MaxCNameLength = 0x1B;
        public const int CNameOffsetAt = 0x1C;
        public const int BaseClassSize = 0xB0;
    }
}