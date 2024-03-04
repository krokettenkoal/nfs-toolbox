using System;
using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalB file.
        /// </summary>
        /// <param name="GlobalB_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalB(string GlobalB_dir, Database.Carbon db)
        {
            GlobalB_dir += @"\GLOBAL\GlobalB.lzc";

            using (var br = new BinaryReader(new MemoryStream(db._GlobalBLZC)))
            using (var bw = new BinaryWriter(File.Open(GlobalB_dir, FileMode.Create)))
            {
                int tpkindex = 0;
                I_Materials(db, bw);
                I_CollisionLibBlock(db, bw);

                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    // Set Offset, ID and Size values, read starting in the beginning of the file
                    uint WriterSlotOffset = (uint)br.BaseStream.Position;
                    uint WriterSlotID = br.ReadUInt32();
                    int WriterSlotSize = br.ReadInt32();

                    // If one of the necessary slots is reached, replace it
                    switch (WriterSlotID)
                    {
                        case 0:
                            uint key = br.ReadUInt32();
                            br.BaseStream.Position -= 4;
                            if (key == GlobalId.GlobalLib)
                            {
                                br.BaseStream.Position += WriterSlotSize;
                                break;
                            }
                            else
                                goto default;

                        case GlobalId.Materials:
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.TPKBlocks:
                            while (db.TPKBlocks[tpkindex].InGlobalA)
                                ++tpkindex;
                            I_TPKBlock(db, bw, ref tpkindex);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.CarTypeInfo:
                            I_CarTypeInfo(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.PresetRides:
                            I_PresetRides(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.PresetSkins:
                            I_PresetSkins(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.CarParts:
                            I_CarParts(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.Collisions:
                            I_Collisions(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.SlotTypes:
                            I_SlotType(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.PaddingReq:
                            I_GlobalLibBlock(bw);
                            goto default;

                        default:
                            bw.Write(WriterSlotID);
                            bw.Write(WriterSlotSize);
                            bw.Write(br.ReadBytes(WriterSlotSize));
                            break;
                    }
                }
            }
            return true;
        }
    }
}