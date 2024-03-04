﻿using System;
using NfsCore.Global;
using NfsCore.Support.MostWanted.Parts.PresetParts;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide
    {
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName, Database.MostWantedDb db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.data = new byte[0x290];
            this.MODEL = "SUPRA";
            this.Frontend = "supra";
            this.Pvehicle = "supra";
            this.DECALS_FRONT_WINDOW = new DecalArray();
            this.DECALS_REAR_WINDOW = new DecalArray();
            this.DECALS_LEFT_DOOR = new DecalArray();
            this.DECALS_RIGHT_DOOR = new DecalArray();
            this.DECALS_LEFT_QUARTER = new DecalArray();
            this.DECALS_RIGHT_QUARTER = new DecalArray();
            Map.BinKeys[Bin.Hash(CName)] = CName;
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(IntPtr byteptr_t, string CName, Database.MostWantedDb db)
        {
            this.Database = db;
            this.data = new byte[0x290];
            this._collection_name = CName;
            this.Exists = true;
            this.DECALS_FRONT_WINDOW = new DecalArray();
            this.DECALS_REAR_WINDOW = new DecalArray();
            this.DECALS_LEFT_DOOR = new DecalArray();
            this.DECALS_RIGHT_DOOR = new DecalArray();
            this.DECALS_LEFT_QUARTER = new DecalArray();
            this.DECALS_RIGHT_QUARTER = new DecalArray();
            this.Disassemble((byte*)byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}