using System.Collections.Generic;
using NfsCore.Support.Shared.Parts.TPKParts;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private bool _use_current_cname;
        private List<uint> keys = new(); // Part2
        private List<OffSlot> offslots = new(); // Part3
        private List<uint> compressions = new(); // Part5

        public TPKBlock() { _use_current_cname = true; Version = 8; }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.CarbonDb db)
        {
            if (index < 0) _use_current_cname = true;
            Database = db;
            Index = index;
            Disassemble(byteptr_t);
        }
    }
}