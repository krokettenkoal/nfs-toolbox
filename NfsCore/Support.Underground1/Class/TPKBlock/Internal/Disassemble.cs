namespace NfsCore.Support.Underground1.Class
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
            GetCompressionList(bytePtrT, partOffsets[4]);
            var textureList = GetTextureHeaders(bytePtrT, partOffsets[3]);

            // Check if number of keys is equal to number of texture headers, pick the least one
            if (textureCount != textureList.Length)
                textureCount = (textureCount > textureList.Length) ? textureList.Length : textureCount;

            // Add textures to the list
            for (var i = 0; i < textureCount; ++i)
            {
                var read = new Texture(bytePtrT, textureList[i, 0], textureList[i, 1], CollName, Database);
                Textures.Add(read);
            }

            // Finally, build all .dds files
            for (var i = 0; i < textureCount; ++i)
            {
                Textures[i].CompVal1 = _compressions[i].var1;
                Textures[i].CompVal2 = _compressions[i].var2;
                Textures[i].CompVal3 = _compressions[i].var3;
                Textures[i].ReadData(bytePtrT, partOffsets[6] + 0x80, false);
            }
        }
    }
}