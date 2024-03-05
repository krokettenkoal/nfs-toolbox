using System;
using System.IO;
using NfsCore.Reflection.ID;
using NfsCore.Support.MostWanted.Class;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads GlobalA file and disassembles its blocks
        /// </summary>
        /// <param name="globalADir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadGlobalA(string globalADir, Database.MostWantedDb db)
        {
            globalADir += @"\GLOBAL\GlobalA.bun";

            // Get everything from GlobalA.bun
            try
            {
                db._GlobalABUN = File.ReadAllBytes(globalADir);
                Log.Write("Reading data from GlobalA.bun...");
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                //Console.WriteLine(e.Message);
                return false;
            }

            // Decompress if compressed
            db._GlobalABUN = JDLZ.Decompress(db._GlobalABUN);

            // Use pointers to speed up process
            fixed (byte* bytePtrT = &db._GlobalABUN[0])
            {
                uint offset = 0; // to calculate current offset
                while (offset < db._GlobalABUN.Length)
                {
                    var id = *(uint*) (bytePtrT + offset); // to get the ID of the block being read
                    var size = *(uint*) (bytePtrT + offset + 4); // to get the size of the block being read
                    if (offset + size > db._GlobalABUN.Length)
                    {
                        //Console.WriteLine("GlobalA: unable to read beyond the stream.");
                        return false;
                    }

                    switch (id)
                    {
                        case GlobalId.TPKBlocks:
                            var count = db.TPKBlocks.Length;
                            db.TPKBlocks.Collections.Add(new TPKBlock(bytePtrT + offset, count, db));
                            db.TPKBlocks[count].InGlobalA = true;
                            break;

                        case GlobalId.FEngFiles:
                        case GlobalId.FNGCompress:
                            E_FNGroup(bytePtrT + offset, size + 8, db);
                            break;
                    }

                    offset += 8 + size; // advance in offset
                }
            }

            return true;
        }
    }
}