using GlobalLib.Reflection.ID;
using GlobalLib.Support.Carbon.Class;
using GlobalLib.Utils;
using System;
using System.IO;

namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        private static bool _libColBlockExists;

        /// <summary>
        /// Loads GlobalB file and disassembles its blocks
        /// </summary>
        /// <param name="globalBDir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadGlobalB(string globalBDir, Database.Carbon db)
        {
            _libColBlockExists = false;
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
                uint psOff = 0; // offset of the preset skins block
                uint psSize = 0; // size of the preset skins block
                uint cpOff = 0; // offset of the carparts block
                uint cpSize = 0; // size of the carparts block
                uint coOff = 0; // offset of the collision block
                uint coSize = 0; // size of the collision block

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
                        case 0:
                            if (*(uint*)(bytePtrT + offset + 8) == Global.GlobalLib)
                                E_GlobalLibBlock(bytePtrT + offset, size + 8);
                            break;

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

                        case Global.PresetSkins:
                            psOff = offset + 8;
                            psSize = size;
                            break;

                        case Global.CarParts:
                            cpOff = offset + 8;
                            cpSize = size;
                            break;

                        case Global.SlotTypes:
                            E_SlotType(bytePtrT + offset, size + 8, db);
                            break;

                        case Global.Collisions:
                            coOff = offset + 8;
                            coSize = size;
                            break;

                        case Global.FEngFiles:
                        case Global.FNGCompress:
                            E_FNGroup(bytePtrT + offset, size + 8, db);
                            break;
                    }
                    offset += 8 + size; // advance in offset
                }

                // CarParts and Collisions blocks are the last ones to disassemble
                E_CarParts(bytePtrT + cpOff, cpSize, db);
                E_Collisions(bytePtrT + coOff, coSize, db);
                E_PresetRides(bytePtrT + prOff, prSize, db);
                E_PresetSkins(bytePtrT + psOff, psSize, db);
            }

            // Disperse spoilers across cartypeinfo
            E_Spoilers(db);
            return true;
        }
    }
}
