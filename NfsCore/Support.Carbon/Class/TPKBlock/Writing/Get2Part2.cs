using System;
using NfsCore.Reflection.ID;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Assembles partial 2 part2 of the tpk block.
        /// </summary>
        /// <returns>Byte array of the partial 2 part2.</returns>
        protected override unsafe byte[] Get2Part2()
        {
            var size = Textures[^1].Offset;
            size += Textures[^1].Size;
            var difference = 0x80 - (size % 0x80);
            if (difference != 0x80) // last padding
                size += difference;

            var result = new byte[size + 0x80];

            // Copy all data to the array
            for (var a1 = 0; a1 < _keys.Count; ++a1)
            {
                if (Textures[a1].Compression == Comp.GetString(EAComp.P8_08))
                    Buffer.BlockCopy(Textures[a1].Data, 0, result, Textures[a1].PaletteOffset + 0x80,
                        Textures[a1].PaletteSize + Textures[a1].Size);
                else
                    Buffer.BlockCopy(Textures[a1].Data, 0, result, Textures[a1].Offset + 0x80, Textures[a1].Size);
            }

            fixed (byte* bytePtrT = &result[8])
            {
                *(uint*) (bytePtrT - 8) = TPK.DATA_PART2_BLOCKID; // write ID
                *(int*) (bytePtrT - 4) = size + 0x78; // write size
                for (var a1 = 0; a1 < 30; ++a1)
                    *(uint*) (bytePtrT + a1 * 4) = 0x11111111;
            }

            return result;
        }
    }
}