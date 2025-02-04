﻿using NfsCore.Support.MostWanted.Parts.CarParts;

namespace NfsCore.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Extracts slottype block into memory.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the ID of spoilerss block in Global data.</param>
        /// <param name="length">Length of the block to be read (including ID and size).</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_SlotType(byte* bytePtrT, uint length, Database.MostWantedDb db)
        {
            var data = new byte[length];
            fixed (byte* dataPtrT = &data[0])
            {
                for (var a1 = 0; a1 < length; ++a1)
                    *(dataPtrT + a1) = *(bytePtrT + a1);
            }

            db.SlotTypes.Spoilers = new Spoilers(data);
        }
    }
}