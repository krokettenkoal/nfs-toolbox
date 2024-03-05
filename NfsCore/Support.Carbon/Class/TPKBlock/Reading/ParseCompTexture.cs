using NfsCore.Reflection.ID;
using NfsCore.Support.Shared.Parts.TPKParts;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Parses compressed texture and returns it on the output.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        /// <param name="offSlot">Offslot of the texture to be parsed</param>
        /// <returns>Decompressed texture valid to the current support.</returns>
        protected override unsafe void ParseCompTexture(byte* bytePtrT, OffSlot offSlot)
        {
            bytePtrT += offSlot.AbsoluteOffset;
            if (*(uint*) bytePtrT != TPK.COMPRESSED_TEXTURE)
                return; // if not a compressed texture

            // Decompress all data excluding 0x18 byte header
            var data = new byte[offSlot.CompressedSize - 0x18];
            for (var a1 = 0; a1 < data.Length; ++a1)
                data[a1] = *(bytePtrT + 0x18 + a1);
            data = JDLZ.Decompress(data);

            // In compressed textures, their header lies right in the end (0x7C + 0x18 bytes)
            fixed (byte* dataPtrT = &data[0])
            {
                var offset = data.Length - 0x7C - 0x18;
                var read = new Texture(dataPtrT, offset, 0x7C, CollName, Database);
                read.ReadData(dataPtrT, 0, true);
                var compression = *(uint*) (dataPtrT + offset + 0x7C + 0xC);
                _compressions.Add(compression);
                Textures.Add(read);
            }
        }
    }
}