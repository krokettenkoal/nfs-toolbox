using NfsCore.Global;


namespace NfsCore.Support.Underground2.Class
{
    public partial class Material
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground2;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.Underground2Db Database { get; }

        public const int MaxCNameLength = 0x1B;
        public const int CNameOffsetAt = 0x1C;
        public const int BaseClassSize = 0xA8;
    }
}