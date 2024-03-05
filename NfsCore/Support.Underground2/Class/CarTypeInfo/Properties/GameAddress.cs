using NfsCore.Global;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground2;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.Underground2Db Database { get; }

        public const int MaxCNameLength = 0xD;
        public const int CNameOffsetAt = 0;
        public const int BaseClassSize = 0x890;
    }
}