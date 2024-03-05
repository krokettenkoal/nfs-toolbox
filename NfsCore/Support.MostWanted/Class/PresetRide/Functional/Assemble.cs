using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Shared.Parts.PresetParts;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Assembles preset ride into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset ride.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[_data.Length];
            Buffer.BlockCopy(_data, 0, result, 0, _data.Length);
            fixed (byte* bytePtrT = &result[0])
            {
                var parts = new Concatenator();
                var addOn = new Add_On();

                // Frontend and Pvehicle
                _frontendHash = Vlt.SmartHash(Frontend);
                _pvehicleHash = Vlt.SmartHash(Pvehicle);

                // _BASE
                parts._BASE = MODEL + parts._BASE;

                // _DAMAGE_0
                parts._DAMAGE_0_FRONT_WINDOW = MODEL + parts._DAMAGE_0_FRONT_WINDOW;
                parts._DAMAGE_0_BODY = MODEL + parts._DAMAGE_0_BODY;
                parts._DAMAGE_0_COP_LIGHTS = MODEL + parts._DAMAGE_0_COP_LIGHTS;
                parts._DAMAGE_0_SPOILER = MODEL + parts._DAMAGE_0_SPOILER;
                parts._DAMAGE_0_FRONT_WHEEL = MODEL + parts._DAMAGE_0_FRONT_WHEEL;
                parts._DAMAGE_0_LEFT_BRAKELIGHT = MODEL + parts._DAMAGE_0_LEFT_BRAKELIGHT;
                parts._DAMAGE_0_RIGHT_BREAKLIGHT = MODEL + parts._DAMAGE_0_RIGHT_BREAKLIGHT;
                parts._DAMAGE_0_LEFT_HEADLIGHT = MODEL + parts._DAMAGE_0_LEFT_HEADLIGHT;
                parts._DAMAGE_0_RIGHT_HEADLIGHT = MODEL + parts._DAMAGE_0_RIGHT_HEADLIGHT;
                parts._DAMAGE_0_HOOD = MODEL + parts._DAMAGE_0_HOOD;
                parts._DAMAGE_0_BUSHGUARD = MODEL + parts._DAMAGE_0_BUSHGUARD;
                parts._DAMAGE_0_FRONT_BUMPER = MODEL + parts._DAMAGE_0_FRONT_BUMPER;
                parts._DAMAGE_0_RIGHT_DOOR = MODEL + parts._DAMAGE_0_RIGHT_DOOR;
                parts._DAMAGE_0_RIGHT_REAR_DOOR = MODEL + parts._DAMAGE_0_RIGHT_REAR_DOOR;
                parts._DAMAGE_0_TRUNK = MODEL + parts._DAMAGE_0_TRUNK;
                parts._DAMAGE_0_REAR_BUMPER = MODEL + parts._DAMAGE_0_REAR_BUMPER;
                parts._DAMAGE_0_REAR_LEFT_WINDOW = MODEL + parts._DAMAGE_0_REAR_LEFT_WINDOW;
                parts._DAMAGE_0_FRONT_LEFT_WINDOW = MODEL + parts._DAMAGE_0_FRONT_LEFT_WINDOW;
                parts._DAMAGE_0_FRONT_RIGHT_WINDOW = MODEL + parts._DAMAGE_0_FRONT_RIGHT_WINDOW;
                parts._DAMAGE_0_REAR_RIGHT_WINDOW = MODEL + parts._DAMAGE_0_REAR_RIGHT_WINDOW;
                parts._DAMAGE_0_LEFT_DOOR = MODEL + parts._DAMAGE_0_LEFT_DOOR;
                parts._DAMAGE_0_REAR_DOOR = MODEL + parts._DAMAGE_0_REAR_DOOR;

                // _BASE_KIT
                if (_aftermarketBodyKit == -1)
                    parts._BASE_KIT = MODEL + parts._BASE_KIT;
                else
                    parts._BASE_KIT = MODEL + parts._BASE_KIT + addOn._KIT + _aftermarketBodyKit;

                // Bunch of stuff
                parts._FRONT_BRAKE = MODEL + parts._FRONT_BRAKE;
                parts._FRONT_LEFT_WINDOW = MODEL + parts._FRONT_LEFT_WINDOW;
                parts._FRONT_RIGHT_WINDOW = MODEL + parts._FRONT_RIGHT_WINDOW;
                parts._FRONT_WINDOW = MODEL + parts._FRONT_WINDOW;
                parts._INTERIOR = MODEL + parts._INTERIOR;
                parts._LEFT_BRAKELIGHT = MODEL + parts._LEFT_BRAKELIGHT;
                parts._LEFT_BRAKELIGHT_GLASS = MODEL + parts._LEFT_BRAKELIGHT_GLASS;
                parts._LEFT_HEADLIGHT = MODEL + parts._LEFT_HEADLIGHT;
                parts._LEFT_HEADLIGHT_GLASS = MODEL + parts._LEFT_HEADLIGHT_GLASS;
                parts._LEFT_SIDE_MIRROR = MODEL + parts._LEFT_SIDE_MIRROR;
                parts._REAR_BRAKE = MODEL + parts._REAR_BRAKE;
                parts._REAR_LEFT_WINDOW = MODEL + parts._REAR_LEFT_WINDOW;
                parts._REAR_RIGHT_WINDOW = MODEL + parts._REAR_RIGHT_WINDOW;
                parts._REAR_WINDOW = MODEL + parts._REAR_WINDOW;
                parts._RIGHT_BRAKELIGHT = MODEL + parts._RIGHT_BRAKELIGHT;
                parts._RIGHT_BRAKELIGHT_GLASS = MODEL + parts._RIGHT_BRAKELIGHT_GLASS;
                parts._RIGHT_HEADLIGHT = MODEL + parts._RIGHT_HEADLIGHT;
                parts._RIGHT_HEADLIGHT_GLASS = MODEL + parts._RIGHT_HEADLIGHT_GLASS;
                parts._RIGHT_SIDE_MIRROR = MODEL + parts._RIGHT_SIDE_MIRROR;
                parts._DRIVER = MODEL + parts._DRIVER;

                // _SPOILER
                if (_spoilerType == eSTypes.NULL)
                    parts._SPOILER = "";
                else if (_spoilerType == eSTypes.STOCK || _spoilerStyle == 0)
                    parts._SPOILER = MODEL + parts._SPOILER;
                else
                {
                    parts._SPOILER = addOn.SPOILER + addOn._STYLE + _spoilerStyle.ToString("00");
                    if (SpoilerType != eSTypes.BASE)
                        parts._SPOILER += _spoilerType.ToString();
                    if (_isCarbonFibreSpoiler == eBoolean.True)
                        parts._SPOILER += addOn._CF;
                }

                // _UNIVERSAL_SPOILER_BASE
                parts._UNIVERSAL_SPOILER_BASE = MODEL + parts._UNIVERSAL_SPOILER_BASE;

                // _DAMAGE0_FRONT and _DAMAGE0_REAR
                parts._DAMAGE0_FRONT = MODEL + addOn._KIT + _aftermarketBodyKit + parts._DAMAGE0_FRONT;
                parts._DAMAGE0_FRONTLEFT = MODEL + addOn._KIT + _aftermarketBodyKit + parts._DAMAGE0_FRONTLEFT;
                parts._DAMAGE0_FRONTRIGHT = MODEL + addOn._KIT + _aftermarketBodyKit + parts._DAMAGE0_FRONTRIGHT;
                parts._DAMAGE0_REAR = MODEL + addOn._KIT + _aftermarketBodyKit + parts._DAMAGE0_REAR;
                parts._DAMAGE0_REARLEFT = MODEL + addOn._KIT + _aftermarketBodyKit + parts._DAMAGE0_REARLEFT;
                parts._DAMAGE0_REARRIGHT = MODEL + addOn._KIT + _aftermarketBodyKit + parts._DAMAGE0_REARRIGHT;

                // _ATTACHMENT
                parts._ATTACHMENT = MODEL + parts._ATTACHMENT;

                // ROOF_STYLE
                if (_roofScoopStyle == 0)
                    parts.ROOF_STYLE += addOn._0 + addOn._0;
                else
                {
                    parts.ROOF_STYLE += _roofScoopStyle.ToString("00");
                    if (_isDualRoofScoop == eBoolean.True)
                        parts.ROOF_STYLE += addOn._DUAL;
                    if (_isOffsetRoofScoop == eBoolean.True && _isDualRoofScoop == eBoolean.False)
                        parts.ROOF_STYLE += addOn._OFFSET;
                    if (_isCarbonFibreRoofScoop == eBoolean.True)
                        parts.ROOF_STYLE += addOn._CF;
                }

                // _HOOD
                if (_hoodStyle == 0)
                    parts._HOOD = MODEL + addOn._KIT + addOn._0 + parts._HOOD;
                else
                {
                    parts._HOOD = MODEL + addOn._STYLE + _hoodStyle.ToString("00") + parts._HOOD;
                    if (_isCarbonFibreHood == eBoolean.True)
                        parts._HOOD += addOn._CF;
                }

                // _WHEEL
                switch (_rimBrand)
                {
                    case BaseArguments.NULL:
                    case BaseArguments.STOCK:
                        parts._WHEEL = MODEL + parts._WHEEL; // null, empty, NULL or STOCK
                        break;
                    default:
                        parts._WHEEL = $"{_rimBrand}{addOn._STYLE}{_rimStyle:00}_{_rimSize}{addOn._25}";
                        break;
                }

                // _DECAL
                parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM;
                parts._DECAL_REAR_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_REAR_WINDOW_WIDE_MEDIUM;
                parts._DECAL_LEFT_DOOR_RECT_MEDIUM =
                    MODEL + addOn._KIT + _aftermarketBodyKit + parts._DECAL_LEFT_DOOR_RECT_MEDIUM;
                parts._DECAL_RIGHT_DOOR_RECT_MEDIUM =
                    MODEL + addOn._KIT + _aftermarketBodyKit + parts._DECAL_RIGHT_DOOR_RECT_MEDIUM;
                parts._DECAL_LEFT_QUARTER_RECT_MEDIUM =
                    MODEL + addOn._KIT + _aftermarketBodyKit + parts._DECAL_LEFT_QUARTER_RECT_MEDIUM;
                parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM =
                    MODEL + addOn._KIT + _aftermarketBodyKit + parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM;

                // PAINT
                parts.PAINT = _bodyPaint;

                // RIMPAINT
                if (RimPaint != BaseArguments.NULL)
                    parts.RIM_PAINT = _rimPaint;

                // WINDOW_TINT
                if (WindowTintType != BaseArguments.STOCK)
                    parts.WINDOW_TINT_STOCK = _windowTintType;

                // VINYL_LAYER
                if (VinylName != BaseArguments.NULL)
                    parts.VINYL_LAYER = VinylName;

                // SWATCH
                parts.SWATCH[0] = Resolve.GetVinylString(_vinylColor1);
                parts.SWATCH[1] = Resolve.GetVinylString(_vinylColor2);
                parts.SWATCH[2] = Resolve.GetVinylString(_vinylColor3);
                parts.SWATCH[3] = Resolve.GetVinylString(_vinylColor4);

                // Hash all strings to keys
                var keys = StringToKey(parts);

                // Write CollectionName
                for (var a1 = 0; a1 < 0x20; ++a1)
                    *(bytePtrT + 0x28 + a1) = 0;
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + 0x28 + a1) = (byte) CollectionName[a1];

                // Write Fronend and Pvehicle
                *(uint*) (bytePtrT + 0x48) = _frontendHash;
                *(uint*) (bytePtrT + 0x50) = _pvehicleHash;

                // If the preset already existed, it is better to internally modify its main values
                // rather than overwriting it, to avoid changing some other values; also, if the model
                // was not changed, it skips bunch of other conversions and hashing stages
                if (Exists && (MODEL == OriginalModel))
                {
                    if (!Modified) // if exists and not modified, return original array
                        return _data;

                    // Write settings that could have been changed
                    fixed (uint* uIntPtrT = &keys[0])
                    {
                        *(uint*) (bytePtrT + 0xBC) = *(uIntPtrT + 23); // _BASE_KIT
                        *(uint*) (bytePtrT + 0x110) = *(uIntPtrT + 44); // _SPOILER
                        *(uint*) (bytePtrT + 0x114) = *(uIntPtrT + 45); // _UNIVERSAL_SPOILER_BASE
                        *(uint*) (bytePtrT + 0x118) = *(uIntPtrT + 46); // _DAMAGE0_FRONT
                        *(uint*) (bytePtrT + 0x11C) = *(uIntPtrT + 47); // _DAMAGE0_FRONTLEFT
                        *(uint*) (bytePtrT + 0x120) = *(uIntPtrT + 48); // _DAMAGE0_FRONTRIGHT
                        *(uint*) (bytePtrT + 0x124) = *(uIntPtrT + 49); // _DAMAGE0_REAR
                        *(uint*) (bytePtrT + 0x128) = *(uIntPtrT + 50); // _DAMAGE0_REARLEFT
                        *(uint*) (bytePtrT + 0x12C) = *(uIntPtrT + 51); // _DAMAGE0_REARRIGHT
                        *(uint*) (bytePtrT + 0x158) = *(uIntPtrT + 62); // ROOF_STYLE
                        *(uint*) (bytePtrT + 0x15C) = *(uIntPtrT + 63); // _HOOD
                        *(uint*) (bytePtrT + 0x168) = *(uIntPtrT + 64); // _WHEEL
                        *(uint*) (bytePtrT + 0x190) = *(uIntPtrT + 72); // PAINT
                        *(uint*) (bytePtrT + 0x194) = *(uIntPtrT + 73); // VINYL_LAYER
                        *(uint*) (bytePtrT + 0x198) = *(uIntPtrT + 74); // RIM_PAINT
                        *(uint*) (bytePtrT + 0x19C) = *(uIntPtrT + 75); // SWATCH[0]
                        *(uint*) (bytePtrT + 0x1A0) = *(uIntPtrT + 76); // SWATCH[1]
                        *(uint*) (bytePtrT + 0x1A4) = *(uIntPtrT + 77); // SWATCH[2]
                        *(uint*) (bytePtrT + 0x1A8) = *(uIntPtrT + 78); // SWATCH[3]
                        *(uint*) (bytePtrT + 0x26C) = *(uIntPtrT + 79); // WINDOW_TINT
                    }
                }

                // If the model was changed or if the preset car is new, either overwrite existing file completely
                // or create a new one for the new car
                else
                {
                    // Write ModelName
                    for (var a1 = 0; a1 < 0x20; ++a1)
                        *(bytePtrT + 8 + a1) = 0;
                    for (var a1 = 0; a1 < MODEL.Length; ++a1)
                        *(bytePtrT + 8 + a1) = (byte) MODEL[a1];

                    // Write all keys
                    fixed (uint* uIntPtrT = &keys[0])
                    {
                        for (var a1 = 0; a1 < 64; ++a1)
                            *(uint*) (bytePtrT + 0x60 + a1 * 4) = *(uIntPtrT + a1);

                        *(uint*) (bytePtrT + 0x168) = *(uIntPtrT + 64);

                        for (var a1 = 0; a1 < 14; ++a1)
                            *(uint*) (bytePtrT + 0x174 + a1 * 4) = *(uIntPtrT + 65 + a1);

                        *(uint*) (bytePtrT + 0x26C) = *(uIntPtrT + 79);
                        if (!Exists)
                        {
                            *(uint*) (bytePtrT + 0x270) = Bin.Hash(parts.HUD);
                            *(uint*) (bytePtrT + 0x274) = Bin.Hash(parts.HUD_BACKING);
                            *(uint*) (bytePtrT + 0x278) = Bin.Hash(parts.HUD_NEEDLE);
                            *(uint*) (bytePtrT + 0x27C) = Bin.Hash(parts.HUD_CHARS);
                        }
                    }
                }

                // Read Decals
                DECALS_FRONT_WINDOW.Write(bytePtrT + 0x1AC);
                DECALS_REAR_WINDOW.Write(bytePtrT + 0x1CC);
                DECALS_LEFT_DOOR.Write(bytePtrT + 0x1EC);
                DECALS_RIGHT_DOOR.Write(bytePtrT + 0x20C);
                DECALS_LEFT_QUARTER.Write(bytePtrT + 0x22C);
                DECALS_RIGHT_QUARTER.Write(bytePtrT + 0x24C);
            }

            return result;
        }
    }
}