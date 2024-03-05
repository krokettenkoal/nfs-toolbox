using System;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Parts.CarParts
{
    public class Collision
    {
        private readonly byte[] _data;

        public bool Unknown { get; } = false;

        public string BelongsTo { get; private set; }

        public uint BinKey => Bin.Hash(BelongsTo);

        public uint VltKey => Vlt.Hash(BelongsTo);

        /// <summary>
        /// Gets collision array with the specified external key.
        /// </summary>
        /// <param name="externalKey">External key to be set in the collision.</param>
        /// <returns>Collision data as a byte array.</returns>
        public unsafe byte[] GetData(uint externalKey)
        {
            var result = new byte[_data.Length];
            Buffer.BlockCopy(_data, 0, result, 0, _data.Length);
            fixed (byte* dataPtrT = &result[0])
            {
                if (Unknown)
                    *(uint*) (dataPtrT + 16) = *(uint*) (dataPtrT + 8);
                else
                    *(uint*) (dataPtrT + 16) = externalKey;
            }

            return result;
        }

        // Default constructor: initialize collision with data and collection name.
        public Collision(byte[] data, string collectionName)
        {
            _data = data;
            if (collectionName == null)
                Unknown = true;
            else
                BelongsTo = collectionName;
        }
    }
}