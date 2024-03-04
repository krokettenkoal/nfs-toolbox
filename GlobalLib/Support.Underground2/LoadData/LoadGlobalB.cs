using GlobalLib.Reflection.ID;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Support.Underground2.Framework;
using GlobalLib.Utils;
using System;
using System.IO;

namespace GlobalLib.Support.Underground2
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
                        case Global.Materials:
                            E_Material(bytePtrT + offset, db);
                            break;

                        case Global.TPKBlocks:
                            var count = db.TPKBlocks.Length;
                            db.TPKBlocks.Collections.Add(new TPKBlock(bytePtrT + offset, count, db));
                            break;

                        case Global.CarTypeInfo:
                            E_CarTypeInfo(bytePtrT + offset + 8, size, db);
                            break;

                        case Global.PresetRides:
                            prOff = offset + 8;
                            prSize = size;
                            break;

                        case Global.CarParts:
                            E_CarParts(bytePtrT + offset + 8, size, db);
                            break;

                        case Global.SunInfos:
                            E_SunInfo(bytePtrT + offset + 8, size, db);
                            break;

                        case Global.Tracks:
                            trOff = offset + 8;
                            trSize = size;
                            break;

                        case Global.CarSkins:
                            csOff = offset + 8;
                            csSize = size;
                            break;

                        case Global.SlotTypes:
                            E_SlotType(bytePtrT + offset, size + 8, db);
                            break;
                        

                        case Global.CareerInfo:
                            if (gcOff == 0xFFFFFFFF)
                                gcOff = offset;
                            break;

                        case Global.AcidEffects:
                            E_AcidEffects(bytePtrT + offset + 8, size, db);
                            break;

                        case Global.FEngFiles:
                        case Global.FNGCompress:
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
