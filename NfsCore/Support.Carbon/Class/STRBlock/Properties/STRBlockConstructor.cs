namespace NfsCore.Support.Carbon.Class
{
    public partial class STRBlock : Shared.Class.STRBlock
    {
        // Default constructor
        public STRBlock()
        {
        }

        // Default constructor: disassemble string block
        public unsafe STRBlock(byte* strPtr, byte* labPtr, int strLen, int labLen, Database.CarbonDb db)
        {
            Database = db;
            Disassemble(strPtr, strLen);
            DisperseLabels(labPtr, labLen);
        }

        ~STRBlock()
        {
        }
    }
}