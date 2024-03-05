using System;
using NfsCore.Global;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.Interface;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Parts.CarParts
{
    public class Part56 : ICastable<Part56>
    {
        private uint _key = 0;
        private string _collectionName;
        public bool IsCar { get; set; } = false;
        public byte[] Data { get; private set; }
        public byte Index { get; private set; } = 0xFF;

        /// <summary>
        /// Game index to which the class belongs to.
        /// </summary>
        public int GameINT => (int) Global.GameINT.MostWanted;

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR => Global.GameSTR.MostWanted;

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
                for (var a1 = 7; a1 < Data.Length; a1 += 0xE)
                    *(bytePtrT + a1) = index;
            }
        }

        public Part56()
        {
        }

        // Default constructor: initialize new part56
        public unsafe Part56(string collectionName, byte index)
        {
            _key = Bin.Hash(collectionName);
            _collectionName = collectionName;
            Index = index;
            IsCar = true;
            Data = new byte[0xA72];
            fixed (byte* bytePtrT = &Data[0])
            {
                for (int a1 = 0, a2 = 0; a1 < 0xBF; ++a1, a2 += 14)
                {
                    *(uint*) (bytePtrT + a2) = Bin.Hash(collectionName + UsageType.PartName[a1]);
                    *(bytePtrT + a2 + 4) = UsageType.CarSlotID[a1];
                    *(ushort*) (bytePtrT + a2 + 5) = UsageType.Unknown1[a1];
                    *(bytePtrT + a2 + 7) = index;
                    *(ushort*) (bytePtrT + a2 + 8) = UsageType.CarPart1Offset[a1];
                    *(ushort*) (bytePtrT + a2 + 10) = UsageType.Unknown2[a1];
                    *(ushort*) (bytePtrT + a2 + 12) = UsageType.FeCustRecID[a1];
                }
            }
        }

        // Default constructor: initialize from Global data.
        public unsafe Part56(uint key, byte* part6PtrT, int length, bool isCar)
        {
            Data = new byte[length];
            _key = key; // get part 5 key
            Index = *(part6PtrT + 7); // get index of the part
            this.IsCar = isCar;
            if (isCar)
                _collectionName = Map.Lookup(key, false);

            // Copy part6 into memory
            fixed (byte* dataPtrT = &Data[0])
            {
                for (var a1 = 0; a1 < length; ++a1)
                    *(dataPtrT + a1) = *(part6PtrT + a1);
            }
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
            return result;
        }
    }
}