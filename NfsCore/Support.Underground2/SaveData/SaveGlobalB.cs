using System;
using System.IO;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Framework;

namespace NfsCore.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Saves database data into GlobalB file.
        /// </summary>
        /// <param name="GlobalB_dir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalB(string GlobalB_dir, Database.Underground2 db)
        {
            GlobalB_dir += @"\GLOBAL\GlobalB.lzc";

            using (var br = new BinaryReader(new MemoryStream(db._GlobalBLZC)))
            using (var bw = new BinaryWriter(File.Open(GlobalB_dir, FileMode.Create)))
            {
                bool careerdone = false;
                int tpkindex = 0;
                I_Materials(db, bw);

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

                        case GlobalId.ELabGlobal:
                            I_GlobalLibBlock(bw);
                            goto default;

                        case GlobalId.CarTypeInfo:
                            I_CarTypeInfo(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.CarSkins:
                            I_CarSkins(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.SlotTypes:
                            I_SlotType(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.CarParts:
                            I_CarParts(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.Tracks:
                            I_Tracks(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.SunInfos:
                            I_SunInfos(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.XenonTrig:
                            I_GlobalLibBlock(bw);
                            goto default;

                        case GlobalId.AcidEffects:
                            I_AcidEffects(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.CareerInfo:
                            if (careerdone) goto default;
                            I_GlobalLibBlock(bw);
                            CareerManager.Assemble(bw, db);
                            br.BaseStream.Position += WriterSlotSize;
                            careerdone = true;
                            break;

                        case GlobalId.PresetRides:
                            I_PresetRides(db, bw);
                            br.BaseStream.Position += WriterSlotSize;
                            break;

                        case GlobalId.FloatChunk:
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