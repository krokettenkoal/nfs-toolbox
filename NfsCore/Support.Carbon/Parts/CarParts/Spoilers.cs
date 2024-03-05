using System;
using System.Collections.Generic;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Parts.CarParts
{
    public class CarSpoilerType
    {
        public string CarTypeInfo { get; set; }
        public eSpoiler Spoiler { get; set; }
        public eSpoilerAS2 SpoilerAS { get; set; }
    }

    public class Spoilers
    {
        private byte[] _data;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT => (int) Global.GameINT.Carbon;

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR => Global.GameSTR.Carbon;

        // Default constructor: initialize slottype data
        public Spoilers(byte[] data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets all spoilers from the slottype block.
        /// </summary>
        /// <returns>List of all spoilers in the slottype block.</returns>
        public unsafe List<CarSpoilerType> GetSpoilers(List<string> collectionNames)
        {
            if (collectionNames == null || collectionNames.Count == 0) return null;
            var result = new List<CarSpoilerType>();
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
                    var collectionName = Map.Lookup(key, false) ?? string.Empty;

                    // Write to new array if not a spoiler or if not a padding
                    if (!reached && !collectionNames.Contains(collectionName))
                    {
                        *(uint*) (dataPtrT + newOff) = key;
                        offset += 4;
                        newOff += 4;
                        continue;
                    }

                    // Else find collection name and extract
                    reached = true;
                    var carSlot = new CarSpoilerType
                    {
                        CarTypeInfo = collectionName
                    };

                    var spoilerKey = *(uint*) (bytePtrT + offset + 0xC);
                    var spoilerAsKey = *(uint*) (bytePtrT + offset + 0x10);
                    if (Enum.IsDefined(typeof(eSpoiler), spoilerKey))
                        carSlot.Spoiler = (eSpoiler) spoilerKey;
                    else
                        carSlot.Spoiler = eSpoiler.SPOILER_NONE;
                    if (Enum.IsDefined(typeof(eSpoilerAS2), spoilerAsKey))
                        carSlot.SpoilerAS = (eSpoilerAS2) spoilerAsKey;
                    else
                        carSlot.SpoilerAS = eSpoilerAS2.SPOILER_NONE_AS2;
                    result.Add(carSlot);
                    offset += 0x24;
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
        public unsafe byte[] SetSpoilers(List<CarSpoilerType> list)
        {
            var newSize = list.Count * 0x24 + _data.Length;
            var padding = 0x10 - newSize % 0x10;
            if (padding != 0x10)
                newSize += padding;
            var offset = _data.Length;

            var result = new byte[newSize];
            Buffer.BlockCopy(_data, 0, result, 0, _data.Length);

            fixed (byte* bytePtrT = &result[0])
            {
                foreach (var carSlot in list)
                {
                    var key = Bin.Hash(carSlot.CarTypeInfo);
                    *(uint*) (bytePtrT + offset) = key;
                    *(uint*) (bytePtrT + offset + 4) = 0x30;
                    *(uint*) (bytePtrT + offset + 8) = key;
                    *(uint*) (bytePtrT + offset + 0xC) = (uint) carSlot.Spoiler;
                    *(uint*) (bytePtrT + offset + 0x10) = (uint) carSlot.SpoilerAS;
                    *(uint*) (bytePtrT + offset + 0x14) = 0xC2F6EBB0;
                    offset += 0x24;
                }

                *(uint*) bytePtrT = GlobalId.SlotTypes;
                *(int*) (bytePtrT + 4) = newSize - 8;
            }

            return result;
        }
    }
}