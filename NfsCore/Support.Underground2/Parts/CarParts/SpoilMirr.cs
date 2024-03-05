using System;
using System.Collections.Generic;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.ID;
using NfsCore.Utils;


namespace NfsCore.Support.Underground2.Parts.CarParts
{
    public class CarSpoilMirrType
    {
        public bool SpoilerNoMirror { get; set; } = true;
        public string CarTypeInfo { get; set; }
        public eSpoiler Spoiler { get; set; } = eSpoiler.SPOILER;
        public eMirrorTypes Mirrors { get; set; } = eMirrorTypes.MIRRORS;
    }

    public class SpoilMirr
    {
        private byte[] _data;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT => (int) Global.GameINT.Underground2;

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR => Global.GameSTR.Underground2;

        // Default constructor: initialize slottype data
        public SpoilMirr(byte[] data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets all spoilers from the slottype block.
        /// </summary>
        /// <returns>List of all spoilers in the slottype block.</returns>
        public unsafe List<CarSpoilMirrType> GetSpoilMirrs(List<string> collectionName)
        {
            if (collectionName == null || collectionName.Count == 0) return null;
            var result = new List<CarSpoilMirrType>();
            var newData = new byte[_data.Length];
            fixed (byte* bytePtrT = &_data[0], dataPtrT = &newData[0])
            {
                var newOff = 8;
                var offset = 8;
                var reached = false; // to remove padding

                *(uint*) dataPtrT = *(uint*) bytePtrT;

                while (offset < _data.Length)
                {
                    var key = *(uint*) (bytePtrT + offset);
                    var collName = Map.Lookup(key, false) ?? string.Empty;

                    // Write to new array if not a spoiler or if not a padding
                    if (!reached && !collectionName.Contains(collName))
                    {
                        *(uint*) (dataPtrT + newOff) = key;
                        offset += 4;
                        newOff += 4;
                        continue;
                    }

                    // Else find collection name and extract
                    reached = true;
                    var carSlot = new CarSpoilMirrType
                    {
                        CarTypeInfo = collName
                    };

                    var definer = *(uint*) (bytePtrT + offset + 0x4);
                    var hash = *(uint*) (bytePtrT + offset + 0xC);

                    switch (definer)
                    {
                        case 0xC:
                        {
                            if (Enum.IsDefined(typeof(eSpoiler), hash))
                                carSlot.Spoiler = (eSpoiler) hash;
                            else
                                carSlot.Spoiler = eSpoiler.SPOILER_NONE;
                            carSlot.SpoilerNoMirror = true;
                            break;
                        }
                        case 0x20:
                        {
                            if (Enum.IsDefined(typeof(eMirrorTypes), hash))
                                carSlot.Mirrors = (eMirrorTypes) hash;
                            else
                                carSlot.Mirrors = eMirrorTypes.MIRRORS_NONE;
                            carSlot.SpoilerNoMirror = false;
                            break;
                        }
                    }

                    result.Add(carSlot);
                    offset += 0x10;
                }

                *(int*) (dataPtrT + 4) = newOff - 8;
                Array.Resize(ref newData, newOff);
            }

            // Set new array
            _data = newData;
            return result;
        }

        /// <summary>
        /// Sets all spoilers from the passed list and returns slottype block.
        /// </summary>
        /// <param name="list">List of spoilers to be set.</param>
        /// <returns>Slottype block as a byte array.</returns>
        public unsafe byte[] SetSpoilMirrs(List<CarSpoilMirrType> list)
        {
            var newSize = list.Count * 0x10 + _data.Length;
            var padding = 0x10 - ((newSize + 8) % 0x10);
            if (padding != 0x10)
                newSize += padding;
            var offset = _data.Length;

            var result = new byte[newSize];
            Buffer.BlockCopy(_data, 0, result, 0, _data.Length);

            fixed (byte* bytePtrT = &result[0])
            {
                foreach (var carSlot in list)
                {
                    if (carSlot.SpoilerNoMirror)
                    {
                        var key = Bin.Hash(carSlot.CarTypeInfo);
                        *(uint*) (bytePtrT + offset) = key;
                        *(uint*) (bytePtrT + offset + 4) = 0x0C;
                        *(uint*) (bytePtrT + offset + 8) = key;
                        *(uint*) (bytePtrT + offset + 0xC) = (uint) carSlot.Spoiler;
                        offset += 0x10;
                    }
                    else
                    {
                        var key = Bin.Hash(carSlot.CarTypeInfo);
                        *(uint*) (bytePtrT + offset) = key;
                        *(uint*) (bytePtrT + offset + 4) = 0x20;
                        *(uint*) (bytePtrT + offset + 8) = key;
                        *(uint*) (bytePtrT + offset + 0xC) = (uint) carSlot.Mirrors;
                        offset += 0x10;
                    }
                }

                *(uint*) bytePtrT = GlobalId.SlotTypes;
                *(int*) (bytePtrT + 4) = newSize - 8;
            }

            return result;
        }
    }
}