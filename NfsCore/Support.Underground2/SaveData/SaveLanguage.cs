using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into English file.
        /// </summary>
        /// <param name="languageDir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveLanguage(string languageDir, Database.Underground2Db db)
        {
            languageDir += @"\LANGUAGES\";

            using (var br = new BinaryReader(new MemoryStream(db._LngGlobal)))
            using (var bw = new BinaryWriter(File.Open(languageDir + "English.bin", FileMode.Create)))
            {
                var finished = false;
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    // Set Offset, ID and Size values, read starting in the beginning of the file
                    var writerSlotOffset = (uint) br.BaseStream.Position;
                    var writerSlotId = br.ReadUInt32();
                    var writerSlotSize = br.ReadInt32();

                    // If one of the necessary slots is reached, replace it
                    switch (writerSlotId)
                    {
                        case GlobalId.STRBlocks:
                            if (!finished)
                            {
                                bw.Write(db.STRBlocks[0].Assemble());
                                br.BaseStream.Position += writerSlotSize;
                                finished = true;
                                break;
                            }

                            goto default;

                        default:
                            bw.Write(writerSlotId);
                            bw.Write(writerSlotSize);
                            bw.Write(br.ReadBytes(writerSlotSize));
                            break;
                    }
                }
            }

            using (var br = new BinaryReader(new MemoryStream(db._LngLabels)))
            using (var bw = new BinaryWriter(File.Open(languageDir + "Labels.bin", FileMode.Create)))
            {
                var finished = false;
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    // Set Offset, ID and Size values, read starting in the beginning of the file
                    var writerSlotOffset = (uint) br.BaseStream.Position;
                    var writerSlotId = br.ReadUInt32();
                    var writerSlotSize = br.ReadInt32();

                    // If one of the necessary slots is reached, replace it
                    switch (writerSlotId)
                    {
                        case GlobalId.STRBlocks:
                            if (!finished)
                            {
                                bw.Write(db.STRBlocks[0].ParseLabels());
                                br.BaseStream.Position += writerSlotSize;
                                finished = true;
                                break;
                            }

                            goto default;

                        default:
                            bw.Write(writerSlotId);
                            bw.Write(writerSlotSize);
                            bw.Write(br.ReadBytes(writerSlotSize));
                            break;
                    }
                }
            }

            return true;
        }
    }
}