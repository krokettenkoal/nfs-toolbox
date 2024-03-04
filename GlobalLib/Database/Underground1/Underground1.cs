using GlobalLib.Core;
using GlobalLib.Database.Collection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Support.Underground1.Class;
using GlobalLib.Support.Underground1.Gameplay;

namespace GlobalLib.Database
{
    public partial class Underground1 : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground1;

        public Root<Material> Materials { get; set; }
        public Root<SunInfo> SunInfos { get; set; }

        public Underground1()
        {
            Materials = new Root<Material>
            (
                "Materials",
                Material.MaxCNameLength,
                Material.CNameOffsetAt,
                Material.BaseClassSize,
                true,
                true,
                this
            );

            SunInfos = new Root<SunInfo>
            (
                "SunInfos",
                SunInfo.MaxCNameLength,
                SunInfo.CNameOffsetAt,
                SunInfo.BaseClassSize,
                true,
                false,
                this
            );
        }

        ~Underground1()
        {
            _GlobalABUN = null;
            _GlobalBLZC = null;
            _LngGlobal = null;
            _LngLabels = null;
            FNGroups = null;
            Materials = null;
            SunInfos = null;
            TPKBlocks = null;
            STRBlocks = null;
        }
    }
}