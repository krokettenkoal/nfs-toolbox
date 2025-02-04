﻿using System;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material
    {
        // Default constructor
        public Material()
        {
        }

        // Default constructor: create new material
        public Material(string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollectionName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble material
        public unsafe Material(IntPtr bytePtrT, string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollectionName = collectionName;
            Disassemble((byte*) bytePtrT);
        }

        ~Material()
        {
        }
    }
}