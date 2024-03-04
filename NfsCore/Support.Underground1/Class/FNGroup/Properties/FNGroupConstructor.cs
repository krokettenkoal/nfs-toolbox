namespace NfsCore.Support.Underground1.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        // Default constructor
        public FNGroup() { }

        // Default constructor: disassemble frontend group
        public FNGroup(byte[] data, Database.Underground1Db db)
        {
            this.Database = db;
            this.Disassemble(data);
        }

        ~FNGroup() { }
    }
}