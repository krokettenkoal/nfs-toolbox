using NfsCore.Global;

namespace NfsCore.Support.Underground1.Class
{
    public partial class Material
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground1;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.Underground1Db Database { get; set; }

        public const int MaxCNameLength = 0x1B;
        public const int CNameOffsetAt = 0x1C;
        public const int BaseClassSize = 0xA8;
    }
}