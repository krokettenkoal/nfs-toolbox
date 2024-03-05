using System;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo
    {
        // Default constructor
        public CarTypeInfo() { }

        // Default constructor: create new cartypeinfo
        public CarTypeInfo(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            ManufacturerName = "GENERIC";
            Deletable = true;
            Modified = true;
            WhatGame = 2;
            WheelOuterRadius = 26;
            WheelInnerRadiusMin = 17;
            WheelInnerRadiusMax = 20;
            DefaultSkinNumber = 1;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
            Initialize();
        }

        // Default constructor: disassemble cartypeinfo
        public unsafe CarTypeInfo(IntPtr bytePtrT, string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            OriginalName = collectionName;
            Initialize();
            Disassemble((byte*)bytePtrT);
            if (Index <= (int)eBoundValues.MIN_INFO_UNDERGROUND2)
                Deletable = false;
            Modified = false;
        }

        ~CarTypeInfo() { }
    }
}