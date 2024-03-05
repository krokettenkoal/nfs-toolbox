using System;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo
    {
        // Default constructor
        public CarTypeInfo()
        {
        }

        // Default constructor: create new cartypeinfo
        public CarTypeInfo(string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollName = collectionName;
            ManufacturerName = "GENERIC";
            Deletable = true;
            Modified = true;
            WhatGame = 1;
            WheelOuterRadius = 26;
            WheelInnerRadiusMin = 17;
            WheelInnerRadiusMax = 20;
            DefaultSkinNumber = 1;
            CollisionExternalName = CollName;
            CollInternalName = "CARRERAGT";
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble cartypeinfo
        public unsafe CarTypeInfo(IntPtr bytePtrT, string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollName = collectionName;
            OriginalName = collectionName;
            Disassemble((byte*) bytePtrT);
            if (Index <= (int) eBoundValues.MIN_INFO_CARBON)
                Deletable = false;
            Modified = false;
        }

        ~CarTypeInfo()
        {
        }
    }
}