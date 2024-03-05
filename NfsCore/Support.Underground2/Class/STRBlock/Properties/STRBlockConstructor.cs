namespace NfsCore.Support.Underground2.Class
{
    public partial class STRBlock : Shared.Class.STRBlock
    {
        // Default constructor
        public STRBlock()
        {
        }

        /// <summary>
        /// Default constructor: disassemble string block
        /// </summary>
        /// <param name="strPtr">The pointer to the string block</param>
        /// <param name="labPtr">The pointer to the label block</param>
        /// <param name="strLen">The length of the string block</param>
        /// <param name="labLen">The length of the label block</param>
        /// <param name="db">The database this item is assigned to</param>
        public unsafe STRBlock(byte* strPtr, byte* labPtr, int strLen, int labLen, Database.Underground2Db db)
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