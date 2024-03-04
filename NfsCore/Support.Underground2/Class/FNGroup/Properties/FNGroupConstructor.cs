﻿namespace NfsCore.Support.Underground2.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        // Default constructor
        public FNGroup() { }

        // Default constructor: disassemble frontend group
        public FNGroup(byte[] data, Database.Underground2Db db)
        {
            this.Database = db;
            this.Disassemble(data);
        }

        ~FNGroup() { }
    }
}