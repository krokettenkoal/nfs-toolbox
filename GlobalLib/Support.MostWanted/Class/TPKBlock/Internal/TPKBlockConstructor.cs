using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.TPKParts;



namespace GlobalLib.Support.MostWanted.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private bool _use_current_cname = false;
        private List<uint> keys = []; // Part2
        private List<CompSlot> compressions = []; // Part5

        public TPKBlock() { this._use_current_cname = true; this.Version = 5; }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.MostWanted db)
        {
            if (index < 0) this._use_current_cname = true;
            this.Database = db;
            this.Index = index;
            Disassemble(byteptr_t);
        }
    }
}