using GlobalLib.Reflection.ID;
using System.IO;

namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalB file.
        /// </summary>
        /// <param name="globalBDir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalB(string globalBDir, Database.MostWanted db)
        {
            globalBDir += @"\GLOBAL\GlobalB.lzc";

            using var br = new BinaryReader(new MemoryStream(db._GlobalBLZC));
            using var bw = new BinaryWriter(File.Open(globalBDir, FileMode.Create));
            var tpkIndex = 0;
            I_Materials(db, bw);
            I_CollisionLibBlock(db, bw);

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                // Set Offset, ID and Size values, read starting in the beginning of the file
                var writerSlotOffset = (uint)br.BaseStream.Position;
                var writerSlotId = br.ReadUInt32();
                var writerSlotSize = br.ReadInt32();

                // If one of the necessary slots is reached, replace it
                switch (writerSlotId)
                {
                    case 0:
                        var key = br.ReadUInt32();
                        br.BaseStream.Position -= 4;
                        if (key == Global.GlobalLib)
                        {
                            br.BaseStream.Position += writerSlotSize;
                            break;
                        }
                            
                        goto default;

                    case Global.Materials:
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case Global.TPKBlocks:
                        while (db.TPKBlocks[tpkIndex].InGlobalA)
                            ++tpkIndex;
                        I_TPKBlock(db, bw, ref tpkIndex);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case Global.CarTypeInfo:
                        I_CarTypeInfo(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case Global.PresetRides:
                        I_PresetRides(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case Global.CarParts:
                        I_CarParts(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case Global.Collisions:
                        I_Collisions(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case Global.SlotTypes:
                        I_SlotType(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    default:
                        bw.Write(writerSlotId);
                        bw.Write(writerSlotSize);
                        bw.Write(br.ReadBytes(writerSlotSize));
                        break;
                }
            }

            return true;
        }
    }
}