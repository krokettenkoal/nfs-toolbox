using System.Collections.Generic;
using NfsCore.Support.Underground2.Parts.CarParts;


namespace NfsCore.Support.Underground2.Class
{
    public partial class SlotType : Shared.Class.SlotType
    {
        public List<Part56> Part56 { get; set; }
        public SpoilMirr SpoilMirrs { get; set; }

        public override string ToString()
        {
            return $"Part56 Count: {Part56.Count}"; // change later
        }
    }
}