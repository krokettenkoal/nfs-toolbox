﻿using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.TPKParts;



namespace GlobalLib.Support.Underground1.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private bool _use_current_cname = false;
        private List<uint> keys = new List<uint>(); // Part2
        private List<CompSlot> compressions = new List<CompSlot>(); // Part5

        public TPKBlock() { this._use_current_cname = true; this.Version = 4; }

        public unsafe TPKBlock(byte* byteptr_t, int index, Database.Underground1 db)
        {
            if (index < 0) this._use_current_cname = true;
            this.Database = db;
            this.Index = index;
            this.Disassemble(byteptr_t);
        }
    }
}