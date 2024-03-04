using System;
using NfsCore.Database.Collection;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Support.Underground1.Class;
using NfsCore.Support.Underground1.Gameplay;

namespace NfsCore.Database
{
    public class Underground1Db : BasicBase
    {
        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT => GameINT.Underground1;

        public Root<Material> Materials { get; set; }
        public Root<SunInfo> SunInfos { get; set; }

        public Underground1Db()
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

        ~Underground1Db()
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
        
        /// <summary>
        /// Throws <see cref="NotImplementedException"/>.
        /// </summary>
        public override bool TryAddCollision(string CName, string filename, out string error)
        {
            throw new NotImplementedException("Import of collisions is not supported for Underground 1");
        }

        /// <summary>
        /// Gets information about <see cref="Underground2Db"/> database.
        /// </summary>
        /// <returns></returns>
        public override string GetDatabaseInfo()
        {
            var nl = Environment.NewLine;
            var info = ToString() + nl;
            //info += $"{this.CarTypeInfos.ThisName} = {this.CarTypeInfos.Length} collections.{nl}";
            info += $"{Materials.ThisName} = {Materials.Length} collections.{nl}";
            //info += $"{this.PresetRides.ThisName} = {this.PresetRides.Length} collections.{nl}";
            info += $"{SunInfos.ThisName} = {SunInfos.Length} collections.{nl}";
            //info += $"{this.Tracks.ThisName} = {this.Tracks.Length} collections.{nl}";
            return info;
        }
    }
}