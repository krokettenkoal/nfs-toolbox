using System.Collections.Generic;
using NfsCore.Global;
using NfsCore.Reflection.ID;
using NfsCore.Support.MostWanted.Parts.CarParts;


namespace NfsCore.Support.MostWanted
{
    public static partial class LoadData
    {
        private static unsafe void E_Collisions(byte* byteptr_t, uint length, Database.MostWantedDb db)
        {
            db.SlotTypes.Collisions = new Dictionary<uint, Collision>();

            // Make a map of vlt hash cartypeinfo and indexes
            var CNameToIndex = new Dictionary<uint, string>();
            foreach (var car in db.CarTypeInfos.Collections)
                CNameToIndex[car.VltKey] = car.CollectionName;

            uint offset = 0;
            while (offset < length)
            {
                var ID = *(uint*)(byteptr_t + offset);
                var size = *(int*)(byteptr_t + offset + 4);
                if (ID == CarParts.Collision)
                {
                    var intkey = *(uint*)(byteptr_t + offset + 8);
                    var extkey = *(uint*)(byteptr_t + offset + 16);

                    // If internal key exists and map shows a string for it
                    if (intkey != 0x11111111 && intkey != 0 && Map.CollisionMap.TryGetValue(intkey, out var CName))
                    {
                        // If collision is not in the map, plug it in
                        if (!db.SlotTypes.Collisions.ContainsKey(intkey))
                        {
                            // Copy whole data, get it into collision map
                            var data = new byte[size + 8];
                            fixed (byte* dataptr_t = &data[0])
                            {
                                for (var a1 = 0; a1 < size + 8; ++a1)
                                    *(dataptr_t + a1) = *(byteptr_t + offset + a1);
                                *(uint*)(dataptr_t + 16) = 0xFFFFFFFF;
                            }
                            var Class = new Collision(data, CName);
                            db.SlotTypes.Collisions[intkey] = Class;
                        }

                        // Check if cartypeinfo with a set external key exists
                        if (CNameToIndex.TryGetValue(extkey, out var name))
                        {
                            var car = db.CarTypeInfos.FindCollection(name);
                            car.CollisionExternalName = car.CollectionName;
                            car.CollisionInternalName = CName;
                        }
                    }
                    else
                    {
                        // Copy entire collision block
                        var data = new byte[size + 8];
                        fixed (byte* dataptr_t = &data[0])
                        {
                            for (var a1 = 0; a1 < size + 8; ++a1)
                                *(dataptr_t + a1) = *(byteptr_t + offset + a1);
                            *(uint*)(dataptr_t + 8) = extkey;
                            *(uint*)(dataptr_t + 16) = 0xFFFFFFFF;
                        }

                        // If collision map has value for external key
                        if (Map.CollisionMap.TryGetValue(extkey, out var ExName))
                        {
                            var Class = new Collision(data, ExName);
                            db.SlotTypes.Collisions[extkey] = Class;

                            // Check if cartypeinfo with a set external key exists
                            if (CNameToIndex.TryGetValue(extkey, out var name))
                            {
                                var car = db.CarTypeInfos.FindCollection(name);
                                car.CollisionExternalName = car.CollectionName;
                                car.CollisionInternalName = car.CollectionName;
                            }
                        }
                        else
                        {
                            var Class = new Collision(data, null);
                            db.SlotTypes.Collisions[extkey] = Class;
                        }
                    }
                }
                offset += (uint)size + 8;
            }

            // New collision map based on real collisions
            Map.CollisionMap.Clear();
            foreach (var collision in db.SlotTypes.Collisions)
            {
                if (!collision.Value.Unknown)
                    Map.CollisionMap[collision.Key] = collision.Value.BelongsTo;
            }
        }
    }
}