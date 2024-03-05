using NfsCore.Support.Shared.Parts.PresetParts;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Converts all preset parts into binary memory keys.
        /// </summary>
        /// <param name="parts">PresetParts concatenator class of all preset ride's parts.</param>
        /// <returns>Sorted array of all preset parts hashes.</returns>
        protected override unsafe uint[] StringToKey(Concatenator parts)
        {
            var offset = 0;
            var partHash = new uint[52];
            // Convert everything to bin hashes, put everything in one uint vector _Part_Hash
            /* 0x060 = 00 */
            partHash[offset++] = Bin.Hash(parts._BASE);
            /* 0x0BC = 01 */
            partHash[offset++] = Bin.Hash(parts._BASE_KIT);
            /* 0x0C0 = 02 */
            partHash[offset++] = Bin.Hash(parts._FRONT_BRAKE);
            /* 0x0C4 = 03 */
            partHash[offset++] = Bin.Hash(parts._FRONT_ROTOR);
            /* 0x0C8 = 04 */
            partHash[offset++] = Bin.Hash(parts._FRONT_LEFT_WINDOW);
            /* 0x0CC = 05 */
            partHash[offset++] = Bin.Hash(parts._FRONT_RIGHT_WINDOW);
            /* 0x0D0 = 06 */
            partHash[offset++] = Bin.Hash(parts._FRONT_WINDOW);
            /* 0x0D4 = 07 */
            partHash[offset++] = Bin.Hash(parts._INTERIOR);
            /* 0x0D8 = 08 */
            partHash[offset++] = Bin.Hash(parts._LEFT_BRAKELIGHT);
            /* 0x0DC = 09 */
            partHash[offset++] = Bin.Hash(parts._LEFT_BRAKELIGHT_GLASS);
            /* 0x0E0 = 10 */
            partHash[offset++] = Bin.Hash(parts._LEFT_HEADLIGHT);
            /* 0x0E4 = 11 */
            partHash[offset++] = Bin.Hash(parts._LEFT_HEADLIGHT_GLASS);
            /* 0x0E8 = 12 */
            partHash[offset++] = Bin.Hash(parts._LEFT_SIDE_MIRROR);
            /* 0x0EC = 13 */
            partHash[offset++] = Bin.Hash(parts._REAR_BRAKE);
            /* 0x0F0 = 14 */
            partHash[offset++] = Bin.Hash(parts._REAR_ROTOR);
            /* 0x0F4 = 15 */
            partHash[offset++] = Bin.Hash(parts._REAR_LEFT_WINDOW);
            /* 0x0F8 = 16 */
            partHash[offset++] = Bin.Hash(parts._REAR_RIGHT_WINDOW);
            /* 0x0FC = 17 */
            partHash[offset++] = Bin.Hash(parts._REAR_WINDOW);
            /* 0x100 = 18 */
            partHash[offset++] = Bin.Hash(parts._RIGHT_BRAKELIGHT);
            /* 0x104 = 19 */
            partHash[offset++] = Bin.Hash(parts._RIGHT_BRAKELIGHT_GLASS);
            /* 0x108 = 20 */
            partHash[offset++] = Bin.Hash(parts._RIGHT_HEADLIGHT);
            /* 0x10C = 21 */
            partHash[offset++] = Bin.Hash(parts._RIGHT_HEADLIGHT_GLASS);
            /* 0x110 = 22 */
            partHash[offset++] = Bin.Hash(parts._RIGHT_SIDE_MIRROR);
            /* 0x114 = 23 */
            partHash[offset++] = Bin.Hash(parts._DRIVER);
            /* 0x118 = 24 */
            partHash[offset++] = Bin.Hash(parts._STEERINGWHEEL);
            /* 0x11C = 25 */
            partHash[offset++] = Bin.Hash(parts._KIT00_EXHAUST);
            /* 0x120 = 26 */
            partHash[offset++] = Bin.Hash(parts._SPOILER);
            /* 0x124 = 27 */
            partHash[offset++] = Bin.Hash(parts._UNIVERSAL_SPOILER_BASE);
            /* 0x128 = 28 */
            partHash[offset++] = Bin.Hash(parts._DAMAGE0_FRONT);
            /* 0x12C = 29 */
            partHash[offset++] = Bin.Hash(parts._DAMAGE0_FRONTLEFT);
            /* 0x130 = 30 */
            partHash[offset++] = Bin.Hash(parts._DAMAGE0_FRONTRIGHT);
            /* 0x134 = 31 */
            partHash[offset++] = Bin.Hash(parts._DAMAGE0_REAR);
            /* 0x138 = 32 */
            partHash[offset++] = Bin.Hash(parts._DAMAGE0_REARLEFT);
            /* 0x13C = 33 */
            partHash[offset++] = Bin.Hash(parts._DAMAGE0_REARRIGHT);
            /* 0x180 = 34 */
            partHash[offset++] = Bin.Hash(parts._FRONT_BUMPER);
            /* 0x184 = 35 */
            partHash[offset++] = Bin.Hash(parts._FRONT_BUMPER_BADGING_SET);
            /* 0x188 = 36 */
            partHash[offset++] = Bin.Hash(parts._REAR_BUMPER);
            /* 0x18C = 37 */
            partHash[offset++] = Bin.Hash(parts._REAR_BUMPER_BADGING_SET);
            /* 0x190 = 38 */
            partHash[offset++] = Bin.Hash(parts._ROOF);
            /* 0x194 = 39 */
            partHash[offset++] = Bin.Hash(parts.ROOF_STYLE);
            /* 0x198 = 40 */
            partHash[offset++] = Bin.Hash(parts._HOOD);
            /* 0x19C = 41 */
            partHash[offset++] = Bin.Hash(parts._SKIRT);
            /* 0x1A8 = 42 */
            partHash[offset++] = Bin.Hash(parts._DOOR_LEFT);
            /* 0x1AC = 43 */
            partHash[offset++] = Bin.Hash(parts._DOOR_RIGHT);
            /* 0x1B0 = 44 */
            partHash[offset++] = Bin.Hash(parts._WHEEL);
            /* 0x1B8 = 45 */
            partHash[offset++] = Bin.Hash(parts.LICENSE_PLATE_STYLE01);
            /* 0x1BC = 46 */
            partHash[offset++] = Bin.Hash(parts._KIT00_DOORLINE);
            /* 0x1D4 = 47 */
            partHash[offset++] = Bin.SmartHash(_specificVinyl);
            /* 0x1D8 = 48 */
            partHash[offset++] = Bin.SmartHash(_genericVinyl);
            /* 0x1F8 = 49 */
            partHash[offset++] = Bin.Hash(parts.WINDOW_TINT_STOCK);
            /* 0x20C = 50 */
            partHash[offset++] = Bin.Hash(parts.PAINT);
            /* 0x210 = 51 */
            partHash[offset] = Bin.Hash(parts.SWATCH_COLOR);
            return partHash;
        }
    }
}