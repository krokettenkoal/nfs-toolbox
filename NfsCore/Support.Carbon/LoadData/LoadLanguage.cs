using System;
using System.IO;
using NfsCore.Support.Carbon.Class;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads English_Global and Labels_Global files and disassembles their blocks.
        /// </summary>
        /// <param name="languageDir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadLanguage(string languageDir, Database.Carbon db)
        {
            languageDir += @"\LANGUAGES\";

            // Get everything from language files
            try
            {
                db._LngGlobal = File.ReadAllBytes(languageDir + "English_Global.bin");
                db._LngLabels = File.ReadAllBytes(languageDir + "Labels_Global.bin");
                Log.Write("Reading data from English_Global.bin...");
                Log.Write("Reading data from Labels_Global.bin...");
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                //Console.WriteLine(e.Message);
                return false;
            }

            // Decompress if compressed
            db._LngGlobal = JDLZ.Decompress(db._LngGlobal);
            db._LngLabels = JDLZ.Decompress(db._LngLabels);

            // Use pointers to speed up process
            fixed (byte* strPtr = &db._LngGlobal[0], labPtr = &db._LngLabels[0])
            {
                db.STRBlocks.Collections.Add(new STRBlock(strPtr, labPtr, db._LngGlobal.Length, db._LngLabels.Length, db));
            }
            return true;
        }
    }
}