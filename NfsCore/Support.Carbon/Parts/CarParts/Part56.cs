using System;
using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.Interface;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Parts.CarParts
{
    public class Part56 : ICastable<Part56>
    {
        private uint _key;
        private string _collectionName;
        public bool IsCar { get; set; }
        public byte[] Data { get; private set; }
        public byte Index { get; private set; } = 0xFF;
        public eUsageType Usage { get; private set; } = eUsageType.Racer;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT => (int) Global.GameINT.Carbon;

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR => Global.GameSTR.Carbon;

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
        public unsafe void SetIndex(byte index)
        {
            Index = index;
            fixed (byte* bytePtrT = &Data[0])
            {
                for (var a1 = 1; a1 < Data.Length; a1 += 4)
                    *(bytePtrT + a1) = index;
            }
        }

        /// <summary>
        /// Sets new usage in the part56.
        /// </summary>
        /// <param name="usage">New usage to be set.</param>
        public unsafe void SetUsage(eUsageType usage)
        {
            if (Usage == usage) return;
            Usage = usage;
            Data = null;
            switch (usage)
            {
                case eUsageType.Cop:
                    Data = new byte[204];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (var a1 = 0; a1 < 51; ++a1)
                        {
                            *(bytePtrT + a1 * 4) = 0;
                            *(bytePtrT + a1 * 4 + 1) = Index;
                            *(ushort*) (bytePtrT + a1 * 4 + 2) = UsageType.Cop[a1];
                        }
                    }

                    break;

                case eUsageType.Traffic:
                    Data = new byte[128];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (var a1 = 0; a1 < 32; ++a1)
                        {
                            *(bytePtrT + a1 * 4) = 0;
                            *(bytePtrT + a1 * 4 + 1) = Index;
                            *(ushort*) (bytePtrT + a1 * 4 + 2) = UsageType.Trafs[a1];
                        }
                    }

                    break;

                default:
                    Data = new byte[1108];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (var a1 = 0; a1 < 277; ++a1)
                        {
                            *(bytePtrT + a1 * 4) = 0;
                            *(bytePtrT + a1 * 4 + 1) = Index;
                            *(ushort*) (bytePtrT + a1 * 4 + 2) = UsageType.Racer[a1];
                        }
                    }

                    break;
            }
        }

        public Part56()
        {
        }

        // Default constructor: initialize new part56
        public unsafe Part56(string collectionName, byte index, eUsageType usage)
        {
            _key = Bin.Hash(collectionName);
            _collectionName = collectionName;
            Index = index;
            Usage = usage;
            IsCar = true;
            switch (usage)
            {
                case eUsageType.Cop:
                    Data = new byte[204];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 51; ++a1, a2 += 4)
                        {
                            *(bytePtrT + a2) = 0;
                            *(bytePtrT + a2 + 1) = index;
                            *(ushort*) (bytePtrT + a2 + 2) = UsageType.Cop[a1];
                        }
                    }

                    break;

                case eUsageType.Traffic:
                    Data = new byte[128];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 32; ++a1, a2 += 4)
                        {
                            *(bytePtrT + a2) = 0;
                            *(bytePtrT + a2 + 1) = index;
                            *(ushort*) (bytePtrT + a2 + 2) = UsageType.Trafs[a1];
                        }
                    }

                    break;

                case eUsageType.Racer:
                case eUsageType.Wheels:
                case eUsageType.Universal:
                default:
                    Data = new byte[1108];
                    fixed (byte* bytePtrT = &Data[0])
                    {
                        for (int a1 = 0, a2 = 0; a1 < 277; ++a1, a2 += 4)
                        {
                            *(bytePtrT + a2) = 0;
                            *(bytePtrT + a2 + 1) = index;
                            *(ushort*) (bytePtrT + a2 + 2) = UsageType.Racer[a1];
                        }
                    }

                    break;
            }
        }

        // Default constructor: initialize from Global data.
        public unsafe Part56(uint key, byte* part6PtrT, int length, bool isCar)
        {
            Data = new byte[length];
            _key = key; // get part 5 key
            Index = *(part6PtrT + 1); // get index of the part
            this.IsCar = isCar;
            if (isCar)
                _collectionName = Map.Lookup(key, false);

            // Copy part6 data into memory
            fixed (byte* dataPtrT = &Data[0])
            {
                for (var a1 = 0; a1 < length; ++a1)
                    *(dataPtrT + a1) = *(part6PtrT + a1);
            }

            // Get UsageType
            Usage = Data.Length switch
            {
                204 => eUsageType.Cop,
                128 => eUsageType.Traffic,
                1108 => eUsageType.Racer,
                _ => eUsageType.Universal
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
        /// <param name="collectionName">Collection Name of the classes, null by default.</param>
        /// <returns>Copy of this class.</returns>
        public Part56 MemoryCast(string collectionName = null)
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
            result.Usage = Usage;
            return result;
        }
    }
}