using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalA file.
        /// </summary>
        /// <param name="globalADir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalA(string globalADir, Database.MostWantedDb db)
        {
            globalADir += @"\GLOBAL\GlobalA.bun";

            using var br = new BinaryReader(new MemoryStream(db._GlobalABUN));
            using var bw = new BinaryWriter(File.Open(globalADir, FileMode.Create));
            var tpkIndex = 0;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                // Set Offset, ID and Size values, read starting in the beginning of the file
                var writerSlotOffset = (uint) br.BaseStream.Position;
                var writerSlotId = br.ReadUInt32();
                var writerSlotSize = br.ReadInt32();

                // If one of the necessary slots is reached, replace it
                switch (writerSlotId)
                {
                    case 0:
                        var key = br.ReadUInt32();
                        br.BaseStream.Position -= 4;
                        if (key == GlobalId.GlobalLib)
                        {
                            br.BaseStream.Position += writerSlotSize;
                            break;
                        }
                        else
                            goto default;

                    case GlobalId.TPKBlocks:
                        while (!db.TPKBlocks[tpkIndex].InGlobalA)
                            ++tpkIndex;
                        I_TPKBlock(db, bw, ref tpkIndex);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.FEngFiles:
                    case GlobalId.FNGCompress:
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    default:
                        bw.Write(writerSlotId);
                        bw.Write(writerSlotSize);
                        bw.Write(br.ReadBytes(writerSlotSize));
                        break;
                }
            }

            // Write all FEng files
            I_FNGroup(db, bw);
            return true;
        }
    }
}