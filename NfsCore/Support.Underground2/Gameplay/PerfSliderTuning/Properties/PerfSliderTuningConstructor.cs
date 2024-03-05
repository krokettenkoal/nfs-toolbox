using NfsCore.Global;
using NfsCore.Support.Underground2.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PerfSliderTuning : NfsUnderground2Collectable
    {
        // Default constructor
        public PerfSliderTuning()
        {
        }

        // Default constructor: create new perfslidertuning
        public PerfSliderTuning(string collectionName, Database.Underground2Db db)
        {
            Database = db;
            CollName = collectionName;
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
        }

        // Default constructor: disassemble perfslidertuning
        public unsafe PerfSliderTuning(byte* bytePtrT, Database.Underground2Db db)
        {
            Database = db;
            Disassemble(bytePtrT);
        }

        ~PerfSliderTuning()
        {
        }
    }
}