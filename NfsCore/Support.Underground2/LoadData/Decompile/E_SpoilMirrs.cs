using System.Collections.Generic;
using System.Linq;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets spoilers from slottype block and sets to cartypeinfo.
        /// </summary>
        /// <param name="db">Database of classes.</param>
        private static void E_SpoilMirrs(Database.Underground2Db db)
        {
            if (db.SlotTypes.SpoilMirrs == null) return;
            var collectionNames = new List<string>(db.CarTypeInfos.Length);
            collectionNames.AddRange(db.CarTypeInfos.Collections.Select(car => car.CollectionName));
            var allSlots = db.SlotTypes.SpoilMirrs.GetSpoilMirrs(collectionNames);
            if (allSlots == null || allSlots.Count == 0) return;

            foreach (var slot in allSlots)
            {
                var car = db.CarTypeInfos.FindCollection(slot.CarTypeInfo);
                if (car == null) continue;
                if (slot.SpoilerNoMirror)
                    car.Spoiler = slot.Spoiler;
                else
                    car.Mirrors = slot.Mirrors;
            }
        }
    }
}