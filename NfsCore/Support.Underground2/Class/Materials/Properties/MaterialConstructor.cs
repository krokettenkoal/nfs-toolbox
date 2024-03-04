﻿using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material
    {
        // Default constructor
        public Material() { }

        // Default constructor: create new material
        public Material(string CName, Database.Underground2Db db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Map.BinKeys[Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble material
        public unsafe Material(IntPtr byteptr_t, string CName, Database.Underground2Db db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        ~Material() { }
    }
}