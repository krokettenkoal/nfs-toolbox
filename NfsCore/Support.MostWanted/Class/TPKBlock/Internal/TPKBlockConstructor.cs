using System.Collections.Generic;
using NfsCore.Support.Shared.Parts.TPKParts;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private bool _use_current_cname = false;
        private List<uint> keys = new(); // Part2
        private List<CompSlot> compressions = new(); // Part5

        public TPKBlock() { _use_current_cname = true; Version = 5; }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.MostWantedDb db)
        {
            if (index < 0) _use_current_cname = true;
            Database = db;
            Index = index;
            Disassemble(byteptr_t);
        }
    }
}