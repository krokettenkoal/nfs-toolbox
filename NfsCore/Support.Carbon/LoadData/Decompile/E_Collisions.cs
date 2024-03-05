using System.Collections.Generic;
using System.Linq;
using NfsCore.Global;
using NfsCore.Reflection.ID;
using NfsCore.Support.Carbon.Parts.CarParts;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        private static unsafe void E_Collisions(byte* bytePtrT, uint length, Database.CarbonDb db)
        {
            db.SlotTypes.Collisions = new Dictionary<uint, Collision>();

            // Make a map of vlt hash cartypeinfo and indexes
            var collectionNameToIndex = new Dictionary<uint, string>();
            foreach (var pair in db.CarTypeInfos.Collections)
                collectionNameToIndex[pair.VltKey] = pair.CollectionName;

            uint offset = 0;
            while (offset < length)
            {
                var id = *(uint*) (bytePtrT + offset);
                var size = *(int*) (bytePtrT + offset + 4);
                if (id == CarParts.Collision)
                {
                    var intKey = *(uint*) (bytePtrT + offset + 8);
                    var extKey = *(uint*) (bytePtrT + offset + 16);

                    // If internal key exists and map shows a string for it
                    if (intKey != 0x11111111 && intKey != 0 &&
                        Map.CollisionMap.TryGetValue(intKey, out var collectionName))
                    {
                        // If collision is not in the map, plug it in
                        if (!db.SlotTypes.Collisions.ContainsKey(intKey))
                        {
                            // Copy whole data, get it into collision map
                            var data = new byte[size + 8];
                            fixed (byte* dataPtrT = &data[0])
                            {
                                for (var a1 = 0; a1 < size + 8; ++a1)
                                    *(dataPtrT + a1) = *(bytePtrT + offset + a1);
                                *(uint*) (dataPtrT + 16) = 0xFFFFFFFF;
                            }

                            var collision = new Collision(data, collectionName);
                            db.SlotTypes.Collisions[intKey] = collision;
                        }

                        // Check if cartypeinfo with a set external key exists
                        if (collectionNameToIndex.TryGetValue(extKey, out var name))
                        {
                            var car = db.CarTypeInfos.FindCollection(name);
                            car.CollisionExternalName = car.CollectionName;
                            car.CollisionInternalName = collectionName;
                        }
                    }
                    else
                    {
                        // Copy entire collision block
                        var data = new byte[size + 8];
                        fixed (byte* dataPtrT = &data[0])
                        {
                            for (var a1 = 0; a1 < size + 8; ++a1)
                                *(dataPtrT + a1) = *(bytePtrT + offset + a1);
                            *(uint*) (dataPtrT + 8) = extKey;
                            *(uint*) (dataPtrT + 16) = 0xFFFFFFFF;
                        }

                        // If collision map has value for external key
                        if (Map.CollisionMap.TryGetValue(extKey, out var exName))
                        {
                            var collision = new Collision(data, exName);
                            db.SlotTypes.Collisions[extKey] = collision;

                            // Check if cartypeinfo with a set external key exists
                            if (collectionNameToIndex.TryGetValue(extKey, out var name))
                            {
                                var car = db.CarTypeInfos.FindCollection(name);
                                car.CollisionExternalName = car.CollectionName;
                                car.CollisionInternalName = car.CollectionName;
                            }
                        }
                        else
                        {
                            var collision = new Collision(data, null);
                            db.SlotTypes.Collisions[extKey] = collision;
                        }
                    }
                }

                offset += (uint) size + 8;
            }

            // New collision map based on real collisions
            Map.CollisionMap.Clear();
            foreach (var collision in db.SlotTypes.Collisions.Where(collision => !collision.Value.Unknown))
            {
                Map.CollisionMap[collision.Key] = collision.Value.BelongsTo;
            }
        }
    }
}