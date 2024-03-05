using System.Linq;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets spoilers from slottype block and sets to cartypeinfo.
        /// </summary>
        /// <param name="db">Database of classes.</param>
        private static void E_Spoilers(Database.CarbonDb db)
        {
            if (db.SlotTypes.Spoilers == null) return;
            var collectionNames = db.CarTypeInfos.Collections.Select(car => car.CollectionName).ToList();
            var allSlots = db.SlotTypes.Spoilers.GetSpoilers(collectionNames);
            if (allSlots == null || allSlots.Count == 0) return;
            foreach (var slot in allSlots)
            {
                var car = db.CarTypeInfos.FindCollection(slot.CarTypeInfo);
                if (car == null) continue;
                car.Spoiler = slot.Spoiler;
                car.SpoilerAS = slot.SpoilerAS;
            }
        }
    }
}