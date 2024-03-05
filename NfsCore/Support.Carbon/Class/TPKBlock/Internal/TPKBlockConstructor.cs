using System.Collections.Generic;
using NfsCore.Support.Shared.Parts.TPKParts;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
    {
        private readonly bool _useCurrentCname;
        private readonly List<uint> _keys = new(); // Part2
        private readonly List<OffSlot> _offSlots = new(); // Part3
        private readonly List<uint> _compressions = new(); // Part5

        public TPKBlock()
        {
            _useCurrentCname = true;
            Version = 8;
        }

        public unsafe TPKBlock(byte* bytePtrT, int index, Database.CarbonDb db)
        {
            if (index < 0) _useCurrentCname = true;
            Database = db;
            Index = index;
            Disassemble(bytePtrT);
        }
    }
}