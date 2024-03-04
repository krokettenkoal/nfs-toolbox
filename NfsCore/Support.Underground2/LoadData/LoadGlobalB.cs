using System;
using System.IO;
using NfsCore.Reflection.ID;
using NfsCore.Support.Underground2.Class;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads GlobalB file and disassembles its blocks
        /// </summary>
        /// <param name="globalBDir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadGlobalB(string globalBDir, Database.Underground2 db)
        {
            globalBDir += @"\GLOBAL\GlobalB.lzc";

            // Get everything from GlobalB.lzc
            try
            {
                db._GlobalBLZC = File.ReadAllBytes(globalBDir);
                Log.Write("Reading data from GlobalB.lzc...");
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                //Console.WriteLine(e.Message);
                return false;
            }

            // Decompress if compressed
            db._GlobalBLZC = JDLZ.Decompress(db._GlobalBLZC);

            // Use pointers to speed up process
            fixed (byte* bytePtrT = &db._GlobalBLZC[0])
            {
                uint offset = 0; // to calculate current offset
                uint prOff = 0; // offset of the preset rides block
                uint prSize = 0; // size of the preset rides block
                uint trOff = 0; // offset of the tracks block
                uint trSize = 0; // size of the tracks block
                uint csOff = 0; // offset of the carskins block
                uint csSize = 0; // size of the carskins block
                var gcOff = 0xFFFFFFFF; // offset of the gcareerinfo block

                while (offset < db._GlobalBLZC.Length)
                {
                    var id = *(uint*)(bytePtrT + offset); // to get the ID of the block being read
                    var size = *(uint*)(bytePtrT + offset + 4); // to get the size of the block being read
                    if (offset + size > db._GlobalBLZC.Length)
                    {
                        //Console.WriteLine("GlobalB: unable to read beyond the stream.");
                        return false;
                    }

                    switch (id)
                    {
                        case GlobalId.Materials:
                            E_Material(bytePtrT + offset, db);
                            break;

                        case GlobalId.TPKBlocks:
                            var count = db.TPKBlocks.Length;
                            db.TPKBlocks.Collections.Add(new TPKBlock(bytePtrT + offset, count, db));
                            break;

                        case GlobalId.CarTypeInfo:
                            E_CarTypeInfo(bytePtrT + offset + 8, size, db);
                            break;

                        case GlobalId.PresetRides:
                            prOff = offset + 8;
                            prSize = size;
                            break;

                        case GlobalId.CarParts:
                            E_CarParts(bytePtrT + offset + 8, size, db);
                            break;

                        case GlobalId.SunInfos:
                            E_SunInfo(bytePtrT + offset + 8, size, db);
                            break;

                        case GlobalId.Tracks:
                            trOff = offset + 8;
                            trSize = size;
                            break;

                        case GlobalId.CarSkins:
                            csOff = offset + 8;
                            csSize = size;
                            break;

                        case GlobalId.SlotTypes:
                            E_SlotType(bytePtrT + offset, size + 8, db);
                            break;
                        

                        case GlobalId.CareerInfo:
                            if (gcOff == 0xFFFFFFFF)
                                gcOff = offset;
                            break;

                        case GlobalId.AcidEffects:
                            E_AcidEffects(bytePtrT + offset + 8, size, db);
                            break;

                        case GlobalId.FEngFiles:
                        case GlobalId.FNGCompress:
                            E_FNGroup(bytePtrT + offset, size + 8, db);
                            break;
                    }
                    offset += 8 + size; // advance in offset
                }

                // Track, Presets and CarSkins are last one to disperse
                E_Tracks(bytePtrT + trOff, trSize, db);
                E_PresetRides(bytePtrT + prOff, prSize, db);
                E_CarSkins(bytePtrT + csOff, csSize, db);
                CareerManager.Disassemble(bytePtrT + gcOff, db);
            }

            // Disperse spoilers across cartypeinfo
            E_SpoilMirrs(db);
            return true;
        }
    }
}
