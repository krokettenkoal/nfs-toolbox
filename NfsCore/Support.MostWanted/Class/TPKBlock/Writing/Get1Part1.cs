using NfsCore.Global;
using NfsCore.Reflection.ID;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 1 part1 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 1 part1.</returns>
        protected override unsafe byte[] Get1Part1()
        {
            var result = new byte[0x84];
            FileName = Process.Watermark;
            FilenameHash = Bin.Hash(FileName);
            Map.BinKeys.Remove(FilenameHash);
            fixed (byte* bytePtrT = &result[0])
            {
                *(uint*) bytePtrT = TPK.INFO_PART1_BLOCKID; // write ID
                *(uint*) (bytePtrT + 4) = 0x7C; // write size
                *(int*) (bytePtrT + 8) = Version;

                // Write CollectionName
                var collectionName = _useCurrentCname ? CollName : CollName.Substring(2, CollName.Length - 2);
                for (var a1 = 0; a1 < collectionName.Length; ++a1)
                    *(bytePtrT + 0xC + a1) = (byte) collectionName[a1];

                // Write Filename
                for (var a1 = 0; a1 < FileName.Length; ++a1)
                    *(bytePtrT + 0x28 + a1) = (byte) FileName[a1];

                // Write all other settings
                *(uint*) (bytePtrT + 0x68) = FilenameHash;
                *(uint*) (bytePtrT + 0x6C) = PermBlockByteOffset;
                *(uint*) (bytePtrT + 0x70) = PermBlockByteSize;
                *(int*) (bytePtrT + 0x74) = EndianSwapped;
                *(int*) (bytePtrT + 0x78) = TexturePack;
                *(int*) (bytePtrT + 0x7C) = TextureIndexEntryTable;
                *(int*) (bytePtrT + 0x80) = TextureStreamEntryTable;
            }

            return result;
        }
    }
}