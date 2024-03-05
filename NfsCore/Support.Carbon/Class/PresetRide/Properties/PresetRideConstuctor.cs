using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide
    {
        // Default constructor
        public PresetRide()
        {
        }

        // Default constructor: create new preset
        public PresetRide(string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollectionName = collectionName;
            _data = new byte[0x600];
            MODEL = "SUPRA";
            FrontendInternal = "supra";
            PVehicleInternal = "supra";
            Initialize();
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
            Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(System.IntPtr bytePtrT, string collectionName, Database.CarbonDb db)
        {
            Database = db;
            CollName = collectionName;
            _data = new byte[0x600];
            Exists = true;
            Initialize();
            Disassemble((byte*) bytePtrT);
            Modified = false;
        }

        // Default destructor
        ~PresetRide()
        {
        }
    }
}