using System;
using NfsCore.Global;
using NfsCore.Support.Carbon.Class;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Get the material name, initialize its class and inject into Vector.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the beginning of material block in Global data.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_Material(byte* bytePtrT, Database.CarbonDb db)
        {
            // Get collection name of the material, starts at 0x14
            var collectionName = ScriptX.NullTerminatedString(bytePtrT + 0x1C, 0x1C);
            collectionName = Resolve.GetPathFromCollection(collectionName);
            Resolve.GetWindowTintString(collectionName);
            Map.BinKeys[Bin.Hash(collectionName)] = collectionName;
            var material = new Material((IntPtr) bytePtrT, collectionName, db);
            db.Materials.Collections.Add(material);
        }
    }
}