using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Checks texture compressions and tpk compressions for matching.
        /// </summary>
        protected override void CheckComps()
        {
            _compressions.Clear();
            foreach (var t in Textures)
                _compressions.Add(Comp.GetInt(t.Compression));
        }
    }
}