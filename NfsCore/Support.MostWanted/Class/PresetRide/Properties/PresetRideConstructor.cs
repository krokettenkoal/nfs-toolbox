using System;
using NfsCore.Global;
using NfsCore.Support.MostWanted.Parts.PresetParts;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide
    {
        // Default constructor
        public PresetRide()
        {
        }

        // Default constructor: create new preset
        public PresetRide(string collectionName, Database.MostWantedDb db)
        {
            Database = db;
            CollectionName = collectionName;
            _data = new byte[0x290];
            MODEL = "SUPRA";
            FrontendInternal = "supra";
            PVehicleInternal = "supra";
            DECALS_FRONT_WINDOW = new DecalArray();
            DECALS_REAR_WINDOW = new DecalArray();
            DECALS_LEFT_DOOR = new DecalArray();
            DECALS_RIGHT_DOOR = new DecalArray();
            DECALS_LEFT_QUARTER = new DecalArray();
            DECALS_RIGHT_QUARTER = new DecalArray();
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
            Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(IntPtr bytePtrT, string collectionName, Database.MostWantedDb db)
        {
            Database = db;
            _data = new byte[0x290];
            CollName = collectionName;
            Exists = true;
            DECALS_FRONT_WINDOW = new DecalArray();
            DECALS_REAR_WINDOW = new DecalArray();
            DECALS_LEFT_DOOR = new DecalArray();
            DECALS_RIGHT_DOOR = new DecalArray();
            DECALS_LEFT_QUARTER = new DecalArray();
            DECALS_RIGHT_QUARTER = new DecalArray();
            Disassemble((byte*) bytePtrT);
            Modified = false;
        }

        // Default destructor
        ~PresetRide()
        {
        }
    }
}