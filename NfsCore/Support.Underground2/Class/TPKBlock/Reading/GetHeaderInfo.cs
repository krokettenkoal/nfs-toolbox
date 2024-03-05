using NfsCore.Reflection.ID;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets tpk header information.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offset">Partial 1 part1 offset in the tpk block array.</param>
        protected override unsafe void GetHeaderInfo(byte* bytePtrT, int offset)
        {
            if (*(uint*) (bytePtrT + offset) != TPK.INFO_PART1_BLOCKID)
                return; // check Part1 ID
            if (*(uint*) (bytePtrT + offset + 4) != 0x7C)
                return; // check header size

            // Get CollectionName
            if (_useCurrentCname)
                CollName = ScriptX.NullTerminatedString(bytePtrT + offset + 0xC, 0x1C);
            else
                CollName = Index + "_" + Comp.GetTPKName(Index, GameINT);

            // Get Filename
            FileName = ScriptX.NullTerminatedString(bytePtrT + offset + 0x28, 0x40);

            // Get the rest of the settings
            Version = *(int*) (bytePtrT + offset + 8);
            FilenameHash = *(uint*) (bytePtrT + offset + 0x68);
            PermBlockByteOffset = *(uint*) (bytePtrT + offset + 0x6C);
            PermBlockByteSize = *(uint*) (bytePtrT + offset + 0x70);
            EndianSwapped = *(int*) (bytePtrT + offset + 0x74);
            TexturePack = *(int*) (bytePtrT + offset + 0x78);
            TextureIndexEntryTable = *(int*) (bytePtrT + offset + 0x7C);
            TextureStreamEntryTable = *(int*) (bytePtrT + offset + 0x80);
        }
    }
}