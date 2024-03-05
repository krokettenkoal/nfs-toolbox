using System.Collections.Generic;
using System.IO;
using System.Linq;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Support.Underground2.Parts.CarParts;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Copies parts 5 and 6 of the CarParts block into memory.
        /// </summary>
        /// <param name="part5PtrT">The pointer to the part 5 block</param>
        /// <param name="part6PtrT">The pointer to the part 6 block</param>
        /// <param name="db">The database to retrieve data from</param>
        /// <exception cref="FileLoadException">thrown if the GlobalB.lzc file could not be loaded</exception>
        private static unsafe void CPE_Part56(byte* part5PtrT, byte* part6PtrT, Database.Underground2Db db)
        {
            var len5 = *(int*) (part5PtrT + 4); // size of part5
            var len6 = *(int*) (part6PtrT + 4); // size of part6

            if (len5 + 8 < Assert.CpPart5AssertSize)
                throw new FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");
            if (len6 + 8 < Assert.CpPart6AssertSize)
                throw new FileLoadException("Detected corrupted GlobalB.lzc CarParts block. Unable to load database.");

            // Exclude padding
            while (*(int*) (part5PtrT + len5 + 4) == 0)
                len5 -= 4;
            while (*(int*) (part6PtrT + len6 + 4) == 0)
                len6 -= 4;
            len6 = len6 / 0xE * 0xE + 8;

            var off5 = 8; // offset in part5
            var off6 = 8; // offset in part6
            var size = 0; // size of one part in part6

            // Validation check
            var check = *(part6PtrT + len6 - 7) + 1;
            var total = len5 / 4;
            if (check < total) len5 = check * 4 + 8;

            db.SlotTypes.Part56 = new List<Part56>();
            var carCollectionNames = db.CarTypeInfos.Collections.Select(car => car.BinKey).ToList();
            while (off5 < len5 + 8 && db.SlotTypes.Part56.Count < 75)
            {
                var cKey = *(uint*) (part5PtrT + off5);
                if (cKey == 0) break; // padding means end
                var isCar = false;
                var index = *(part6PtrT + off6 + 7);
                while (true)
                {
                    if (off6 + size + 7 >= len6) break;
                    var current = *(part6PtrT + off6 + size + 7);
                    if (current != index) break;
                    size += 0xE;
                }

                if (carCollectionNames.Contains(cKey)) isCar = true;
                var part = new Part56(cKey, part6PtrT + off6, size, isCar);
                db.SlotTypes.Part56.Add(part);
                off5 += 4;
                off6 += size;
                size = 0;
            }
        }
    }
}