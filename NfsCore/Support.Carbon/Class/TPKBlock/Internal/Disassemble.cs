namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Disassembles tpk block array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the tpk block array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            var partOffsets = FindOffsets(bytePtrT);
            var textureCount = GetTextureCount(bytePtrT, partOffsets[1]);
            if (textureCount == 0) return; // if no textures allocated

            GetHeaderInfo(bytePtrT, partOffsets[0]);
            GetKeyList(bytePtrT, partOffsets[1]);
            GetOffsetSlots(bytePtrT, partOffsets[2]);
            GetCompressionList(bytePtrT, partOffsets[4]);
            var textureList = GetTextureHeaders(bytePtrT, partOffsets[3]);

            if (partOffsets[2] != -1)
            {
                // Check if number of keys is equal to number of texture offslots, pick the least one
                if (textureCount != _offSlots.Count)
                    textureCount = (textureCount > _offSlots.Count) ? _offSlots.Count : textureCount;

                for (var i = 0; i < textureCount; ++i)
                    ParseCompTexture(bytePtrT, _offSlots[i]);
            }
            else
            {
                // Check if number of keys is equal to number of texture headers, pick the least one
                if (textureCount != textureList.Length / 2)
                    textureCount = (textureCount > textureList.Length) ? textureList.Length : textureCount;

                // Add textures to the list
                for (var i = 0; i < textureCount; ++i)
                {
                    var read = new Texture(bytePtrT, textureList[i, 0], textureList[i, 1], CollName, Database);
                    Textures.Add(read);
                }

                // Finally, build all .dds files
                for (var i = 0; i < textureCount; ++i)
                    Textures[i].ReadData(bytePtrT, partOffsets[6] + 0x80, false);
            }
        }
    }
}