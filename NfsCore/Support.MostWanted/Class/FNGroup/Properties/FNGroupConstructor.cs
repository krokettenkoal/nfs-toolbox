﻿namespace NfsCore.Support.MostWanted.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        // Default constructor
        public FNGroup()
        {
        }

        // Default constructor: disassemble frontend group
        public FNGroup(byte[] data, Database.MostWantedDb db)
        {
            Database = db;
            Disassemble(data);
        }

        ~FNGroup()
        {
        }
    }
}