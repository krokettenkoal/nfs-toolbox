using System;
using System.Collections.Generic;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Parts.CarParts
{
    public class CarSpoilerType
    {
        public string CarTypeInfo { get; set; }
        public eSpoiler Spoiler { get; set; }
    }

    public class Spoilers
    {
        private byte[] _data;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT => (int) Global.GameINT.MostWanted;

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR => Global.GameSTR.MostWanted;

        // Default constructor: initialize slottype data
        public Spoilers(byte[] data)
        {
            this._data = data;
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
                    if (Enum.IsDefined(typeof(eSpoiler), spoilerKey))
                        carSlot.Spoiler = (eSpoiler) spoilerKey;
                    else
                        carSlot.Spoiler = eSpoiler.SPOILER_NONE;
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
        public unsafe byte[] SetSpoilers(List<CarSpoilerType> list)
        {
            var newSize = list.Count * 0x10 + _data.Length;
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
                    *(uint*) (bytePtrT + offset + 4) = 0x2C;
                    *(uint*) (bytePtrT + offset + 8) = key;
                    *(uint*) (bytePtrT + offset + 0xC) = (uint) carSlot.Spoiler;
                    offset += 0x10;
                }

                *(uint*) bytePtrT = GlobalId.SlotTypes;
                *(int*) (bytePtrT + 4) = newSize - 8;
            }

            return result;
        }
    }
}