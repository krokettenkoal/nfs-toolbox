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
        /// <param name="globalBDir">Game directory.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool SaveGlobalB(string globalBDir, Database.Underground2Db db)
        {
            globalBDir += @"\GLOBAL\GlobalB.lzc";

            using var br = new BinaryReader(new MemoryStream(db._GlobalBLZC));
            using var bw = new BinaryWriter(File.Open(globalBDir, FileMode.Create));
            var careerDone = false;
            var tpkIndex = 0;
            I_Materials(db, bw);

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

                        goto default;

                    case GlobalId.Materials:
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.TPKBlocks:
                        while (db.TPKBlocks[tpkIndex].InGlobalA)
                            ++tpkIndex;
                        I_TPKBlock(db, bw, ref tpkIndex);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.ELabGlobal:
                        I_GlobalLibBlock(bw);
                        goto default;

                    case GlobalId.CarTypeInfo:
                        I_CarTypeInfo(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.CarSkins:
                        I_CarSkins(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.SlotTypes:
                        I_SlotType(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.CarParts:
                        I_CarParts(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.Tracks:
                        I_Tracks(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.SunInfos:
                        I_SunInfos(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.XenonTrig:
                        I_GlobalLibBlock(bw);
                        goto default;

                    case GlobalId.AcidEffects:
                        I_AcidEffects(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.CareerInfo:
                        if (careerDone) goto default;
                        I_GlobalLibBlock(bw);
                        CareerManager.Assemble(bw, db);
                        br.BaseStream.Position += writerSlotSize;
                        careerDone = true;
                        break;

                    case GlobalId.PresetRides:
                        I_PresetRides(db, bw);
                        br.BaseStream.Position += writerSlotSize;
                        break;

                    case GlobalId.FloatChunk:
                        I_GlobalLibBlock(bw);
                        goto default;

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