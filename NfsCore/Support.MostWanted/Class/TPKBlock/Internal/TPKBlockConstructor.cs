using System.Collections.Generic;
using NfsCore.Support.Shared.Parts.TPKParts;


namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private bool _use_current_cname = false;
        private List<uint> keys = []; // Part2
        private List<CompSlot> compressions = []; // Part5

        public TPKBlock() { this._use_current_cname = true; this.Version = 5; }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.MostWantedDb db)
        {
            if (index < 0) this._use_current_cname = true;
            this.Database = db;
            this.Index = index;
            Disassemble(byteptr_t);
        }
    }
}