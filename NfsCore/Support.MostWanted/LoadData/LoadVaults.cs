using System;
using System.IO;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads vault data files and processes all strings that are contained in them.
        /// </summary>
        /// <param name="vaultDir">Directory of the game.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadVaults(string vaultDir)
        {
            var attribDir = vaultDir + @"\GLOBAL\attributes.bin";
            var feAttrDir = vaultDir + @"\GLOBAL\fe_attrib.bin";
            byte[] attributes;
            byte[] feAttrib;

            try
            {
                attributes = File.ReadAllBytes(attribDir);
                feAttrib = File.ReadAllBytes(feAttrDir);
                Log.Write("Reading data from attributes.bin...");
                Log.Write("Reading data from fe_attrib.bin...");
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                //Console.WriteLine(e.Message);
                return false;
            }

            fixed (byte* bytePtrT = &attributes[0])
            {
                if (*(uint*) bytePtrT != 0x4B415056)
                {
                    //Console.WriteLine("attributes: invalid header definition.");
                    return false;
                }

                var packs = *(int*) (bytePtrT + 4);
                var cNameOff = *(int*) (bytePtrT + 8);

                for (var currPack = 0; currPack < packs; ++currPack)
                {
                    var vaultNameOffset = *(int*) (bytePtrT + 0x10 + currPack * 0x14);
                    var vaultOffset = *(int*) (bytePtrT + 0x1C + currPack * 0x14);
                    var vaultCName = "";
                    for (var a1 = vaultNameOffset + cNameOff; *(bytePtrT + a1) != 0; ++a1)
                        vaultCName += ((char) *(bytePtrT + a1)).ToString();
                    if (vaultCName != "db") continue;
                    E_VaultKeys(bytePtrT + vaultOffset);
                    break;
                }
            }

            fixed (byte* bytePtrT = &feAttrib[0])
            {
                if (*(uint*) bytePtrT != 0x4B415056)
                {
                    //Console.WriteLine("fe_attrib: invalid header definition.");
                    return false;
                }

                var packs = *(int*) (bytePtrT + 4);
                var cNameOff = *(int*) (bytePtrT + 8);

                for (var currPack = 0; currPack < packs; ++currPack)
                {
                    var vaultNameOffset = *(int*) (bytePtrT + 0x10 + currPack * 0x14);
                    var vaultOffset = *(int*) (bytePtrT + 0x1C + currPack * 0x14);
                    var vaultCName = "";
                    for (var a1 = vaultNameOffset + cNameOff; *(bytePtrT + a1) != 0; ++a1)
                        vaultCName += ((char) *(bytePtrT + a1)).ToString();
                    if (vaultCName != "frontend") continue;
                    E_VaultKeys(bytePtrT + vaultOffset);
                    break;
                }
            }

            attributes = null;
            feAttrib = null;
            return true;
        }
    }
}