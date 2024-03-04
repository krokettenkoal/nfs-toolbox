using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class AcidEffect : Shared.Class.AcidEffect
    {
        // Default constructor
        public AcidEffect() { }

        // Default constructor: create new acid effect
        public AcidEffect(string CName, Database.Underground2Db db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble acid effect
        public unsafe AcidEffect(IntPtr byteptr_t, string CName, Database.Underground2Db db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        ~AcidEffect() { }
    }
}