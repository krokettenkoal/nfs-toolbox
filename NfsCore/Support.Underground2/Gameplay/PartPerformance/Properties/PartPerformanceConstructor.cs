using System.Linq;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Underground2.Class;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartPerformance : NfsUnderground2Collectable
    {
        // Default constructor
        public PartPerformance()
        {
        }

        // Default constructor: create new part performance
        public PartPerformance(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollectionName = collectionName;
            SetToFirstAvailablePerfSlot();
            var index = db.PartPerformances.Collections.Select(cla => cla.PartIndex).Prepend(0).Max();
            _partIndex = index + 1;
            _cnameIsSet = true;
        }

        // Default constructor: disassemble part performance
        public unsafe PartPerformance(byte* bytePtrT, Database.Underground2Db db, params int[] args)
        {
            Database = db;
            _partPerfType = (ePerformanceType) args[0];
            _upgradeLevel = args[1];
            _upgradePartIndex = args[2];
            Disassemble(bytePtrT);
            Map.PerfPartTable[args[0], args[1], args[2]] = Utils.Bin.SmartHash(CollName);
            _cnameIsSet = true;
        }

        ~PartPerformance()
        {
        }
    }
}