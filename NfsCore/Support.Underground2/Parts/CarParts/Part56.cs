using System;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Parts.CarParts
{
    public class Part56
    {
        private uint _key;
        private string _collectionName;
        public bool IsCar { get; set; }
        public byte[] Data { get; private set; }
        public byte Index { get; private set; } = 0xFF;
        public eUsageType Usage { get; set; } = eUsageType.Racer;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT => (int) Global.GameINT.Underground2;

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR => Global.GameSTR.Underground2;

        /// <summary>
        /// Key of the cartypeinfo of the carpart.
        /// </summary>
        public uint Key
        {
            get => _key;
            set
            {
                if (!Map.BinKeys.ContainsKey(_key))
                    throw new MappingFailException();
                _key = value;
                _collectionName = Map.BinKeys[value];
            }
        }

        /// <summary>
        /// CarTypeInfo to which the carpart belongs to.
        /// </summary>
        public string BelongsTo
        {
            get => _collectionName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                _collectionName = value;
                var temp = Bin.Hash(value);
                _key = temp;
            }
        }

        /// <summary>
        /// Sets new index in the part56.
        /// </summary>
        /// <param name="index">New index to be set.</param>
        public void SetIndex(byte index)
        {
            Index = index;
            for (var a1 = 7; a1 < Data.Length; a1 += 0xE)
                Data[a1] = index;
        }

        public Part56()
        {
        }

        // Default constructor: initialize new part56
        public unsafe Part56(string collectionName, eUsageType type, int entries, int racers, int trafficCars)
        {
            _key = Bin.Hash(collectionName);
            _collectionName = collectionName;
            IsCar = true;
            Usage = type;

            switch (type)
            {
                case eUsageType.Racer:
                {
                    Data = new byte[0xEC4];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 0x10E; ++a1, a2 += 0xE)
                        {
                            *(uint*) (bytePtrT + a2) = Bin.Hash(collectionName + UsageType.PartName[a1]);
                            *(bytePtrT + a2 + 4) = UsageType.CarSlotID[a1];
                            *(ushort*) (bytePtrT + a2 + 5) = UsageType.Unknown1[a1];
                            *(bytePtrT + a2 + 7) = Index;
                            *(ushort*) (bytePtrT + a2 + 8) = UsageType.CarPart1Offset[a1];
                            *(ushort*) (bytePtrT + a2 + 10) = a1 is 63 or >= 65 and <= 68 or >= 94 and <= 98
                                or >= 122 and <= 126 or >= 160 and <= 193
                                ? (ushort) (UsageType.Unknown2[a1] + 0x8F * (racers + 1) + 1)
                                : UsageType.Unknown2[a1];
                            *(ushort*) (bytePtrT + a2 + 12) = a1 is 232 or > 264
                                ? (ushort) (entries + UsageType.FeCustRecID[a1] + trafficCars * 2 + racers * 6)
                                : UsageType.FeCustRecID[a1];
                        }
                    }

                    break;
                }
                case eUsageType.Traffic:
                {
                    Data = new byte[0x2A];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 3; ++a1, a2 += 0xE)
                        {
                            *(uint*) (bytePtrT + a2) = Bin.Hash(collectionName + UsageType.TrafficPartName[a1]);
                            *(bytePtrT + a2 + 4) = UsageType.CarSlotID[a1];
                            *(ushort*) (bytePtrT + a2 + 5) = UsageType.TrafficUnknown1[a1];
                            *(bytePtrT + a2 + 7) = Index;
                            *(ushort*) (bytePtrT + a2 + 8) = UsageType.TrafficCarPart1Offset[a1];
                            *(ushort*) (bytePtrT + a2 + 10) = UsageType.TrafficUnknown2[a2];
                            *(ushort*) (bytePtrT + a2 + 12) = a1 == 0
                                ? UsageType.TrafficFeCustRecID[a1]
                                : (ushort) (entries + trafficCars * 2 + racers * 6 + UsageType.TrafficFeCustRecID[a1]);
                        }
                    }

                    break;
                }
                case eUsageType.Cop:
                    break;
                case eUsageType.Wheels:
                    break;
                case eUsageType.Universal:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        // Default constructor: initialize from Global data.
        public unsafe Part56(uint key, byte* part6PtrT, int length, bool isCar)
        {
            Data = new byte[length];
            _key = key; // get part 5 key
            Index = *(part6PtrT + 7); // get index of the part
            IsCar = isCar;
            if (isCar)
                _collectionName = Map.Lookup(key, false);

            // Copy part6 into memory
            for (var a1 = 0; a1 < length; ++a1)
                Data[a1] = *(part6PtrT + a1);

            Usage = length switch
            {
                0x2A when isCar => eUsageType.Traffic,
                0xEC4 when isCar => eUsageType.Racer,
                _ => Usage
            };
        }

        public override string ToString()
        {
            var str = _collectionName ?? string.Empty;
            return $"BelongsTo: {str} | Index: {Index}";
        }

        /// <summary>
        /// Returns new class with casted memory of this class.
        /// </summary>
        /// <returns>Copy of this class.</returns>
        public Part56 MemoryCast()
        {
            var result = new Part56
            {
                Data = new byte[Data.Length]
            };
            Buffer.BlockCopy(Data, 0, result.Data, 0, Data.Length);
            result._collectionName = _collectionName;
            result._key = _key;
            result.IsCar = IsCar;
            result.Index = Index;
            return result;
        }

        /// <summary>
        /// Casts all record and parts IDs of one carpart to another, while changing part hashes
        /// to have new collection name prefix and changing index of the part.
        /// </summary>
        /// <param name="collectionName">Collection Name of the new carpart.</param>
        /// <param name="entries">The number of entries to cast</param>
        /// <param name="racers">The number of racers in this part</param>
        /// <param name="trafficCars">The number of traffic cars in this part</param>
        /// <returns>A new part instance</returns>
        public unsafe Part56 SmartMemoryCast(string collectionName, int entries, int racers, int trafficCars)
        {
            var result = MemoryCast();
            result.BelongsTo = collectionName;

            fixed (byte* bytePtrT = &result.Data[0])
            {
                if (Usage == eUsageType.Racer)
                {
                    for (int a1 = 0, a2 = 0; a1 < 0x10E; ++a1, a2 += 0xE)
                    {
                        *(uint*) (bytePtrT + a2) = Bin.Hash(collectionName + UsageType.PartName[a1]);
                        *(ushort*) (bytePtrT + a2 + 10) = a1 is 63 or >= 65 and <= 68 or >= 94 and <= 98
                            or >= 122 and <= 126 or >= 160 and <= 193
                            ? (ushort) (UsageType.Unknown2[a1] + 0x8F * (racers + 1) + 1)
                            : UsageType.Unknown2[a1];
                        *(ushort*) (bytePtrT + a2 + 12) = a1 is 232 or > 264
                            ? (ushort) (entries + UsageType.FeCustRecID[a1] + trafficCars * 2 + racers * 6)
                            : UsageType.FeCustRecID[a1];
                    }
                }
                else if (Usage == eUsageType.Traffic)
                {
                    for (int a1 = 0, a2 = 0; a1 < 3; ++a1, a2 += 0xE)
                    {
                        *(uint*) (bytePtrT + a2) = Bin.Hash(collectionName + UsageType.TrafficPartName[a1]);
                        *(ushort*) (bytePtrT + a2 + 12) = a1 == 0
                            ? UsageType.TrafficFeCustRecID[a1]
                            : (ushort) (entries + trafficCars * 2 + racers * 6 + UsageType.TrafficFeCustRecID[a1]);
                    }
                }
            }

            return result;
        }
    }
}