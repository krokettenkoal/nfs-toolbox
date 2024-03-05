using NfsCore.Global;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.MostWanted;

        /// <summary>
        /// Database to which the class belongs to.
        /// </summary>
        public new Database.MostWantedDb Database { get; }

        public const int MaxCNameLength = 0x1F;
        public const int CNameOffsetAt = 0x28;
        public const int BaseClassSize = 0x290;
    }
}