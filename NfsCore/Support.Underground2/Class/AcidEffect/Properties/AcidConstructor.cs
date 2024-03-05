using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class AcidEffect : Shared.Class.AcidEffect
    {
        // Default constructor
        public AcidEffect()
        {
        }

        // Default constructor: create new acid effect
        public AcidEffect(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble acid effect
        public unsafe AcidEffect(IntPtr bytePtrT, string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Disassemble((byte*) bytePtrT);
        }

        ~AcidEffect()
        {
        }
    }
}