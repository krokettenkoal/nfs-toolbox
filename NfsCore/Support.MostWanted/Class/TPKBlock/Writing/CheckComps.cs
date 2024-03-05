using System.Linq;
using NfsCore.Support.Shared.Parts.TPKParts;
using NfsCore.Utils.EA;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Checks texture compressions and tpk compressions for matching.
        /// </summary>
        protected override void CheckComps()
        {
            _compressions.Clear();
            foreach (var slot in Textures.Select(t => new CompSlot
                     {
                         var1 = t.CompVal1,
                         var2 = t.CompVal2,
                         var3 = t.CompVal3,
                         comp = Comp.GetInt(t.Compression)
                     }))
            {
                _compressions.Add(slot);
            }
        }
    }
}