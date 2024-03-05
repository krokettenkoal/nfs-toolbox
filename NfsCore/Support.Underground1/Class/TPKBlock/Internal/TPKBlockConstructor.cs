using System.Collections.Generic;
using NfsCore.Support.Shared.Parts.TPKParts;

namespace NfsCore.Support.Underground1.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private readonly bool _useCurrentCname;
        private readonly List<uint> _keys = new(); // Part2
        private readonly List<CompSlot> _compressions = new(); // Part5

        public TPKBlock()
        {
            _useCurrentCname = true;
            Version = 4;
        }

        public unsafe TPKBlock(byte* bytePtrT, int index, Database.Underground1Db db)
        {
            if (index < 0) _useCurrentCname = true;
            Database = db;
            Index = index;
            Disassemble(bytePtrT);
        }
    }
}