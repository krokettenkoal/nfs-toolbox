using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Carbon.Parts.PresetParts;
using NfsCore.Support.Shared.Parts.PresetParts;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
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
                _pVehicleHash = Vlt.SmartHash(Pvehicle);

                // _BASE
                parts._BASE = MODEL + parts._BASE;

                // _BASE_KIT
                if (_aftermarketBodyKit == -1)
                    parts._BASE_KIT = MODEL + parts._BASE_KIT;
                else if (_aftermarketBodyKit == 0)
                    parts._BASE_KIT = MODEL + parts._BASE_KIT + addOn._KIT + addOn._0;
                else
                    parts._BASE_KIT = MODEL + parts._BASE_KIT + addOn._KITW + _aftermarketBodyKit;

                // Bunch of stuff
                parts._FRONT_BRAKE = MODEL + parts._FRONT_BRAKE;
                parts._FRONT_ROTOR = MODEL + parts._FRONT_ROTOR;
                parts._FRONT_LEFT_WINDOW = MODEL + parts._FRONT_LEFT_WINDOW;
                parts._FRONT_RIGHT_WINDOW = MODEL + parts._FRONT_RIGHT_WINDOW;
                parts._FRONT_WINDOW = MODEL + parts._FRONT_WINDOW;
                parts._INTERIOR = MODEL + parts._INTERIOR;
                parts._LEFT_BRAKELIGHT = MODEL + parts._LEFT_BRAKELIGHT;
                parts._LEFT_BRAKELIGHT_GLASS = MODEL + parts._LEFT_BRAKELIGHT_GLASS;

                // _LEFT_HEADLIGHT
                if (_popupHeadlightsExist == eBoolean.False)
                    parts._LEFT_HEADLIGHT = MODEL + parts._LEFT_HEADLIGHT;
                else
                {
                    parts._LEFT_HEADLIGHT = _popupHeadlightsOn == eBoolean.True
                        ? MODEL + parts._LEFT_HEADLIGHT + addOn._ON
                        : MODEL + parts._LEFT_HEADLIGHT + addOn._OFF;
                }

                // _LEFT_HEADLIGHT_GLASS
                parts._LEFT_HEADLIGHT_GLASS = MODEL + parts._LEFT_HEADLIGHT_GLASS;

                // Bunch of stuff
                parts._LEFT_SIDE_MIRROR = MODEL + parts._LEFT_SIDE_MIRROR;
                parts._REAR_BRAKE = MODEL + parts._REAR_BRAKE;
                parts._REAR_ROTOR = MODEL + parts._REAR_ROTOR;
                parts._REAR_LEFT_WINDOW = MODEL + parts._REAR_LEFT_WINDOW;
                parts._REAR_RIGHT_WINDOW = MODEL + parts._REAR_RIGHT_WINDOW;
                parts._REAR_WINDOW = MODEL + parts._REAR_WINDOW;
                parts._RIGHT_BRAKELIGHT = MODEL + parts._RIGHT_BRAKELIGHT;
                parts._RIGHT_BRAKELIGHT_GLASS = MODEL + parts._RIGHT_BRAKELIGHT_GLASS;

                // _RIGHT_HEADLIGHT
                if (_popupHeadlightsExist == eBoolean.False)
                    parts._RIGHT_HEADLIGHT = MODEL + parts._RIGHT_HEADLIGHT;
                else
                {
                    parts._RIGHT_HEADLIGHT = _popupHeadlightsOn == eBoolean.True
                        ? MODEL + parts._RIGHT_HEADLIGHT + addOn._ON
                        : MODEL + parts._RIGHT_HEADLIGHT + addOn._OFF;
                }

                // _RIGHT_HEADLIGHT_GLASS
                parts._RIGHT_HEADLIGHT_GLASS = MODEL + parts._RIGHT_HEADLIGHT_GLASS;

                // Bunch of stuff
                parts._RIGHT_SIDE_MIRROR = MODEL + parts._RIGHT_SIDE_MIRROR;
                parts._DRIVER = MODEL + parts._DRIVER;
                parts._STEERINGWHEEL = MODEL + parts._STEERINGWHEEL;

                // _KIT00_EXHAUST
                if (_exhaustStyle == -1)
                    parts._KIT00_EXHAUST = string.Empty;
                else if (_exhaustStyle == 0 || _aftermarketBodyKit >= 1)
                    parts._KIT00_EXHAUST = MODEL + parts._KIT00_EXHAUST;
                else
                {
                    parts._KIT00_EXHAUST = addOn.EXHAUST + addOn._STYLE + _exhaustStyle.ToString("00");
                    if (_isCenterExhaust == eBoolean.True)
                        parts._KIT00_EXHAUST += addOn._CENTER;
                    parts._KIT00_EXHAUST += addOn._LEVEL1;
                }

                // _SPOILER
                if (_spoilerType == eSTypes.NULL)
                    parts._SPOILER = "";
                else if (_spoilerType == eSTypes.STOCK || _spoilerStyle == 0)
                    parts._SPOILER = MODEL + parts._SPOILER;
                else
                {
                    parts._SPOILER = _isAutoSculptSpoiler == eBoolean.True
                        ? addOn.AS_SPOILER
                        : addOn.SPOILER;
                    parts._SPOILER += addOn._STYLE + _spoilerStyle.ToString("00");
                    if (_spoilerType != eSTypes.BASE)
                        parts._SPOILER += _spoilerType.ToString();
                    if (_isCarbonFibreSpoiler == eBoolean.True)
                        parts._SPOILER += addOn._CF;
                }

                // _UNIVERSAL_SPOILER_BASE
                parts._UNIVERSAL_SPOILER_BASE = MODEL + parts._UNIVERSAL_SPOILER_BASE;

                // _DAMAGE0_FRONT and _DAMAGE0_REAR
                if (_aftermarketBodyKit <= 0)
                    goto LABEL_AUTOSCULPT_DAMAGE;

                goto LABEL_AFTERMARKET_DAMAGE;

                LABEL_AUTOSCULPT_DAMAGE:
                // _FRONT_DAMAGE0 + FRONT_BUMPER
                if (_autoSculptFrontBumper == -1)
                {
                    parts._DAMAGE0_FRONT = string.Empty;
                    parts._DAMAGE0_FRONTLEFT = string.Empty;
                    parts._DAMAGE0_FRONTRIGHT = string.Empty;
                    parts._FRONT_BUMPER = string.Empty;
                    parts._FRONT_BUMPER_BADGING_SET = string.Empty;
                }
                else
                {
                    var autoFPad = _autoSculptFrontBumper.ToString("00");
                    parts._DAMAGE0_FRONT = MODEL + addOn._K10 + autoFPad + parts._DAMAGE0_FRONT;
                    parts._DAMAGE0_FRONTLEFT = MODEL + addOn._K10 + autoFPad + parts._DAMAGE0_FRONTLEFT;
                    parts._DAMAGE0_FRONTRIGHT = MODEL + addOn._K10 + autoFPad + parts._DAMAGE0_FRONTRIGHT;
                    parts._FRONT_BUMPER = MODEL + addOn._K10 + autoFPad + parts._FRONT_BUMPER;
                    parts._FRONT_BUMPER_BADGING_SET = MODEL + addOn._KIT + (_autoSculptFrontBumper % 9) +
                                                      parts._FRONT_BUMPER_BADGING_SET;
                }

                // REAR_DAMAGE0 + REAR_BUMPER
                if (_autoSculptRearBumper == -1)
                {
                    parts._DAMAGE0_REAR = string.Empty;
                    parts._DAMAGE0_REARLEFT = string.Empty;
                    parts._DAMAGE0_REARRIGHT = string.Empty;
                    parts._REAR_BUMPER = string.Empty;
                    parts._REAR_BUMPER_BADGING_SET = string.Empty;
                }
                else
                {
                    var autoRPad = _autoSculptRearBumper.ToString("00");
                    parts._DAMAGE0_REAR = MODEL + addOn._K10 + autoRPad + parts._DAMAGE0_REAR;
                    parts._DAMAGE0_REARLEFT = MODEL + addOn._K10 + autoRPad + parts._DAMAGE0_REARLEFT;
                    parts._DAMAGE0_REARRIGHT = MODEL + addOn._K10 + autoRPad + parts._DAMAGE0_REARRIGHT;
                    parts._REAR_BUMPER = MODEL + addOn._K10 + autoRPad + parts._REAR_BUMPER;
                    parts._REAR_BUMPER_BADGING_SET = MODEL + addOn._KIT + (_autoSculptRearBumper % 9) +
                                                     parts._REAR_BUMPER_BADGING_SET;
                }

                goto LABEL_NEXT;

                LABEL_AFTERMARKET_DAMAGE:
                // FRONT_DAMAGE0 + REAR_DAMAGE0
                parts._DAMAGE0_FRONT = MODEL + addOn._KITW + _aftermarketBodyKit + parts._DAMAGE0_FRONT;
                parts._DAMAGE0_FRONTLEFT =
                    MODEL + addOn._KITW + _aftermarketBodyKit + parts._DAMAGE0_FRONTLEFT;
                parts._DAMAGE0_FRONTRIGHT =
                    MODEL + addOn._KITW + _aftermarketBodyKit + parts._DAMAGE0_FRONTRIGHT;
                parts._DAMAGE0_REAR = MODEL + addOn._KITW + _aftermarketBodyKit + parts._DAMAGE0_REAR;
                parts._DAMAGE0_REARLEFT =
                    MODEL + addOn._KITW + _aftermarketBodyKit + parts._DAMAGE0_REARLEFT;
                parts._DAMAGE0_REARRIGHT =
                    MODEL + addOn._KITW + _aftermarketBodyKit + parts._DAMAGE0_REARRIGHT;
                parts._FRONT_BUMPER = "";
                parts._FRONT_BUMPER_BADGING_SET = "";
                parts._REAR_BUMPER = "";
                parts._REAR_BUMPER_BADGING_SET = "";

                LABEL_NEXT:
                // _ROOF (_CHOP_TOP)
                parts._ROOF = _chopTopIsOn == eBoolean.True
                    ? MODEL + parts._ROOF + "_CHOP_TOP"
                    : MODEL + parts._ROOF;

                // ROOF_STYLE
                if (_roofScoopStyle == 0)
                    parts.ROOF_STYLE += addOn._0 + addOn._0;
                else
                {
                    parts.ROOF_STYLE += _roofScoopStyle.ToString("00");
                    if (_isDualRoofScoop == eBoolean.True)
                        parts.ROOF_STYLE += addOn._DUAL;
                    if (_isAutoSculptRoofScoop == eBoolean.True && _isDualRoofScoop == eBoolean.False)
                        parts.ROOF_STYLE += addOn._AUTOSCULPT;
                    if (_isCarbonFibreRoofScoop == eBoolean.True)
                        parts.ROOF_STYLE += addOn._CF;
                }

                // _HOOD
                if (_hoodStyle == 0)
                    parts._HOOD = MODEL + addOn._KIT + addOn._0 + parts._HOOD;
                else
                {
                    parts._HOOD = MODEL + addOn._STYLE + addOn._0 + _hoodStyle + parts._HOOD;
                    if (_isAutoSculptHood == eBoolean.True)
                        parts._HOOD += addOn._AS;
                    if (_isCarbonFibreHood == eBoolean.True)
                        parts._HOOD += addOn._CF;
                }

                // _SKIRT
                if (_autoSculptSkirt == -1)
                    parts._SKIRT = "";
                else if (_autoSculptSkirt == -2)
                    parts._SKIRT = MODEL + addOn._KIT + addOn._0 + parts._SKIRT + "_CAPPED";
                else
                    parts._SKIRT = MODEL + addOn._K10 + _autoSculptSkirt.ToString("00");

                // _DOOR_LEFT and _DOOR_RIGHT
                if (_aftermarketBodyKit == 0)
                {
                    parts._DOOR_LEFT = MODEL + parts._DOOR_LEFT;
                    parts._DOOR_RIGHT = MODEL + parts._DOOR_RIGHT;
                }
                else
                {
                    parts._DOOR_LEFT = MODEL + addOn._KITW + _aftermarketBodyKit + parts._DOOR_LEFT;
                    parts._DOOR_RIGHT = MODEL + addOn._KITW + _aftermarketBodyKit + parts._DOOR_RIGHT;
                }

                // _WHEEL
                switch (_rimBrand)
                {
                    case BaseArguments.NULL:
                    case BaseArguments.STOCK:
                        parts._WHEEL = MODEL + parts._WHEEL; // null, empty, NULL or STOCK
                        break;
                    case "AUTOSCLPT":
                        parts._WHEEL = $"{_rimBrand}{addOn._STYLE}{_rimStyle:00}_17{addOn._25}";
                        break;
                    default:
                        parts._WHEEL = $"{_rimBrand}{addOn._STYLE}{_rimStyle:00}_{_rimSize}{addOn._25}";
                        break;
                }

                // _KIT00_DOORLINE
                parts._KIT00_DOORLINE = _aftermarketBodyKit <= 0
                    ? MODEL + parts._KIT00_DOORLINE
                    : string.Empty;

                // WINDOW_TINT
                if (_windowTintType != BaseArguments.STOCK)
                    parts.WINDOW_TINT_STOCK = _windowTintType;

                // Carpaint
                parts.PAINT = _paintType.ToString();
                parts.SWATCH_COLOR = Resolve.GetSwatchString(_paintSwatch);

                // Hash all strings to keys
                var keys = StringToKey(parts);

                // If the preset already existed, it is better to internally modify its main values
                // rather than overwriting it, to avoid changing some other values; also, if the model
                // was not changed, it skips bunch of other conversions and hashing stages
                if (Exists && MODEL == OriginalModel)
                {
                    if (!Modified) // if exists and not modified, return original array
                        goto LABEL_FINAL;

                    // Write settings that could have been changed
                    fixed (uint* uIntPtrT = &keys[0])
                    {
                        *(uint*) (bytePtrT + 0x60) = *(uIntPtrT + 0); // _BASE
                        *(uint*) (bytePtrT + 0xBC) = *(uIntPtrT + 1); // _BASE_KIT
                        *(uint*) (bytePtrT + 0xE0) = *(uIntPtrT + 10); // _LEFT_HEADLIGHT
                        *(uint*) (bytePtrT + 0xE4) = *(uIntPtrT + 11); // _LEFT_HEADLIGHT_GLASS
                        *(uint*) (bytePtrT + 0x108) = *(uIntPtrT + 20); // _RIGHT_HEADLIGHT
                        *(uint*) (bytePtrT + 0x10C) = *(uIntPtrT + 21); // _RIGHT_HEADLIGHT_GLASS
                        *(uint*) (bytePtrT + 0x11C) = *(uIntPtrT + 25); // _EXHAUST
                        *(uint*) (bytePtrT + 0x120) = *(uIntPtrT + 26); // _SPOILER
                        *(uint*) (bytePtrT + 0x128) = *(uIntPtrT + 28); // _DAMAGE0_FRONT
                        *(uint*) (bytePtrT + 0x12C) = *(uIntPtrT + 29); // _DAMAGE0_FRONTLEFT
                        *(uint*) (bytePtrT + 0x130) = *(uIntPtrT + 30); // _DAMAGE0_FRONTRIGHT
                        *(uint*) (bytePtrT + 0x134) = *(uIntPtrT + 31); // _DAMAGE0_REAR
                        *(uint*) (bytePtrT + 0x138) = *(uIntPtrT + 32); // _DAMAGE0_REARLEFT
                        *(uint*) (bytePtrT + 0x13C) = *(uIntPtrT + 33); // _DAMAGE0_REARRIGHT
                        *(uint*) (bytePtrT + 0x180) = *(uIntPtrT + 34); // _FRONT_BUMPER
                        *(uint*) (bytePtrT + 0x184) = *(uIntPtrT + 35); // _FRONT_BUMPER_BADGING_SET
                        *(uint*) (bytePtrT + 0x188) = *(uIntPtrT + 36); // _REAR_BUMPER
                        *(uint*) (bytePtrT + 0x18C) = *(uIntPtrT + 37); // _REAR_BUMPER_BADGING_SET
                        *(uint*) (bytePtrT + 0x190) = *(uIntPtrT + 38); // _ROOF
                        *(uint*) (bytePtrT + 0x194) = *(uIntPtrT + 39); // _ROOF_STYLE
                        *(uint*) (bytePtrT + 0x198) = *(uIntPtrT + 40); // _HOOD
                        *(uint*) (bytePtrT + 0x19C) = *(uIntPtrT + 41); // _SKIRT
                        *(uint*) (bytePtrT + 0x1A8) = *(uIntPtrT + 42); // _DOOR_LEFT
                        *(uint*) (bytePtrT + 0x1AC) = *(uIntPtrT + 43); // _DOOR_RIGHT
                        *(uint*) (bytePtrT + 0x1B0) = *(uIntPtrT + 44); // _WHEEL
                        *(uint*) (bytePtrT + 0x1BC) = *(uIntPtrT + 46); // _KIT00_DOORLINE
                        *(uint*) (bytePtrT + 0x1D4) = *(uIntPtrT + 47); // SPECIFIC
                        *(uint*) (bytePtrT + 0x1D8) = *(uIntPtrT + 48); // GENERIC
                        *(uint*) (bytePtrT + 0x1F8) = *(uIntPtrT + 49); // WINDOW_TINT
                        *(uint*) (bytePtrT + 0x20C) = *(uIntPtrT + 50); // PAINT_TYPE
                        *(uint*) (bytePtrT + 0x210) = *(uIntPtrT + 51); // SWATCH_COLOR
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
                        *(uint*) (bytePtrT + 0x60) = *uIntPtrT;

                        for (var a1 = 0; a1 < 33; ++a1)
                            *(uint*) (bytePtrT + 0xBC + a1 * 4) = *(uIntPtrT + 1 + a1);

                        for (var a1 = 0; a1 < 8; ++a1)
                            *(uint*) (bytePtrT + 0x180 + a1 * 4) = *(uIntPtrT + 34 + a1);

                        *(uint*) (bytePtrT + 0x1A8) = *(uIntPtrT + 42);
                        *(uint*) (bytePtrT + 0x1AC) = *(uIntPtrT + 43);
                        *(uint*) (bytePtrT + 0x1B0) = *(uIntPtrT + 44);
                        *(uint*) (bytePtrT + 0x1B8) = *(uIntPtrT + 45);
                        *(uint*) (bytePtrT + 0x1BC) = *(uIntPtrT + 46);
                        *(uint*) (bytePtrT + 0x1D4) = *(uIntPtrT + 47);
                        *(uint*) (bytePtrT + 0x1D8) = *(uIntPtrT + 48);
                        *(uint*) (bytePtrT + 0x1F8) = *(uIntPtrT + 49);
                        *(uint*) (bytePtrT + 0x20C) = *(uIntPtrT + 50);
                        *(uint*) (bytePtrT + 0x210) = *(uIntPtrT + 51);
                    }
                }

                LABEL_FINAL:
                // Write CollectionName
                for (var a1 = 0; a1 < 0x20; ++a1)
                    *(bytePtrT + 0x28 + a1) = 0;
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + 0x28 + a1) = (byte) CollectionName[a1];

                // Write Fronend and Pvehicle
                *(uint*) (bytePtrT + 0x48) = _frontendHash;
                *(uint*) (bytePtrT + 0x50) = _pVehicleHash;

                // Write Colors
                *(int*) (bytePtrT + 0x208) = 1;
                *(float*) (bytePtrT + 0x214) = _saturation;
                *(float*) (bytePtrT + 0x218) = _brightness;

                *(bytePtrT + 0x22C) = FRONTBUMPER.AutosculptZone1;
                *(bytePtrT + 0x22D) = FRONTBUMPER.AutosculptZone2;
                *(bytePtrT + 0x22E) = FRONTBUMPER.AutosculptZone3;
                *(bytePtrT + 0x22F) = FRONTBUMPER.AutosculptZone4;
                *(bytePtrT + 0x230) = FRONTBUMPER.AutosculptZone5;
                *(bytePtrT + 0x231) = FRONTBUMPER.AutosculptZone6;
                *(bytePtrT + 0x232) = FRONTBUMPER.AutosculptZone7;
                *(bytePtrT + 0x233) = FRONTBUMPER.AutosculptZone8;
                *(bytePtrT + 0x234) = FRONTBUMPER.AutosculptZone9;

                *(bytePtrT + 0x237) = REARBUMPER.AutosculptZone1;
                *(bytePtrT + 0x238) = REARBUMPER.AutosculptZone2;
                *(bytePtrT + 0x239) = REARBUMPER.AutosculptZone3;
                *(bytePtrT + 0x23A) = REARBUMPER.AutosculptZone4;
                *(bytePtrT + 0x23B) = REARBUMPER.AutosculptZone5;
                *(bytePtrT + 0x23C) = REARBUMPER.AutosculptZone6;
                *(bytePtrT + 0x23D) = REARBUMPER.AutosculptZone7;
                *(bytePtrT + 0x23E) = REARBUMPER.AutosculptZone8;
                *(bytePtrT + 0x23F) = REARBUMPER.AutosculptZone9;
                if (_autoSculptRearBumper >= 1 && _autoSculptRearBumper <= 10)
                    *(bytePtrT + 0x237 + Zones.ExhPos[_autoSculptRearBumper]) = _exhaustSize;

                *(bytePtrT + 0x242) = SKIRT.AutosculptZone1;
                *(bytePtrT + 0x243) = SKIRT.AutosculptZone2;
                *(bytePtrT + 0x244) = SKIRT.AutosculptZone3;
                *(bytePtrT + 0x245) = SKIRT.AutosculptZone4;
                *(bytePtrT + 0x246) = SKIRT.AutosculptZone5;
                *(bytePtrT + 0x247) = SKIRT.AutosculptZone6;
                *(bytePtrT + 0x248) = SKIRT.AutosculptZone7;
                *(bytePtrT + 0x249) = SKIRT.AutosculptZone8;
                *(bytePtrT + 0x24A) = SKIRT.AutosculptZone9;

                *(bytePtrT + 0x24D) = WHEELS.AutosculptZone1;
                *(bytePtrT + 0x24E) = WHEELS.AutosculptZone2;
                *(bytePtrT + 0x24F) = WHEELS.AutosculptZone3;
                *(bytePtrT + 0x250) = WHEELS.AutosculptZone4;
                *(bytePtrT + 0x251) = WHEELS.AutosculptZone5;
                *(bytePtrT + 0x252) = WHEELS.AutosculptZone6;
                *(bytePtrT + 0x253) = WHEELS.AutosculptZone7;
                *(bytePtrT + 0x254) = WHEELS.AutosculptZone8;
                *(bytePtrT + 0x255) = WHEELS.AutosculptZone9;

                *(bytePtrT + 0x258) = HOOD.AutosculptZone1;
                *(bytePtrT + 0x259) = HOOD.AutosculptZone2;
                *(bytePtrT + 0x25A) = HOOD.AutosculptZone3;
                *(bytePtrT + 0x25B) = HOOD.AutosculptZone4;
                *(bytePtrT + 0x25C) = HOOD.AutosculptZone5;
                *(bytePtrT + 0x25D) = HOOD.AutosculptZone6;
                *(bytePtrT + 0x25E) = HOOD.AutosculptZone7;
                *(bytePtrT + 0x25F) = HOOD.AutosculptZone8;
                *(bytePtrT + 0x260) = HOOD.AutosculptZone9;

                *(bytePtrT + 0x263) = SPOILER.AutosculptZone1;
                *(bytePtrT + 0x264) = SPOILER.AutosculptZone2;
                *(bytePtrT + 0x265) = SPOILER.AutosculptZone3;
                *(bytePtrT + 0x266) = SPOILER.AutosculptZone4;
                *(bytePtrT + 0x267) = SPOILER.AutosculptZone5;
                *(bytePtrT + 0x268) = SPOILER.AutosculptZone6;
                *(bytePtrT + 0x269) = SPOILER.AutosculptZone7;
                *(bytePtrT + 0x26A) = SPOILER.AutosculptZone8;
                *(bytePtrT + 0x26B) = SPOILER.AutosculptZone9;

                *(bytePtrT + 0x26E) = ROOFSCOOP.AutosculptZone1;
                *(bytePtrT + 0x26F) = ROOFSCOOP.AutosculptZone2;
                *(bytePtrT + 0x270) = ROOFSCOOP.AutosculptZone3;
                *(bytePtrT + 0x271) = ROOFSCOOP.AutosculptZone4;
                *(bytePtrT + 0x272) = ROOFSCOOP.AutosculptZone5;
                *(bytePtrT + 0x273) = ROOFSCOOP.AutosculptZone6;
                *(bytePtrT + 0x274) = ROOFSCOOP.AutosculptZone7;
                *(bytePtrT + 0x275) = ROOFSCOOP.AutosculptZone8;
                *(bytePtrT + 0x276) = ROOFSCOOP.AutosculptZone9;

                *(bytePtrT + 0x279) = _chopTopSize;
                *(bytePtrT + 0x284) = _exhaustSize;

                VINYL01.Write(bytePtrT + 0x290 + 0x2C * 0);
                VINYL02.Write(bytePtrT + 0x290 + 0x2C * 1);
                VINYL03.Write(bytePtrT + 0x290 + 0x2C * 2);
                VINYL04.Write(bytePtrT + 0x290 + 0x2C * 3);
                VINYL05.Write(bytePtrT + 0x290 + 0x2C * 4);
                VINYL06.Write(bytePtrT + 0x290 + 0x2C * 5);
                VINYL07.Write(bytePtrT + 0x290 + 0x2C * 6);
                VINYL08.Write(bytePtrT + 0x290 + 0x2C * 7);
                VINYL09.Write(bytePtrT + 0x290 + 0x2C * 8);
                VINYL10.Write(bytePtrT + 0x290 + 0x2C * 9);
                VINYL11.Write(bytePtrT + 0x290 + 0x2C * 10);
                VINYL12.Write(bytePtrT + 0x290 + 0x2C * 11);
                VINYL13.Write(bytePtrT + 0x290 + 0x2C * 12);
                VINYL14.Write(bytePtrT + 0x290 + 0x2C * 13);
                VINYL15.Write(bytePtrT + 0x290 + 0x2C * 14);
                VINYL16.Write(bytePtrT + 0x290 + 0x2C * 15);
                VINYL17.Write(bytePtrT + 0x290 + 0x2C * 16);
                VINYL18.Write(bytePtrT + 0x290 + 0x2C * 17);
                VINYL19.Write(bytePtrT + 0x290 + 0x2C * 18);
                VINYL20.Write(bytePtrT + 0x290 + 0x2C * 19);
            }

            return result;
        }
    }
}