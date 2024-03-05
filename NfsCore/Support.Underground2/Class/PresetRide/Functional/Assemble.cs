using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Shared.Parts.PresetParts;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        public override unsafe byte[] Assemble()
        {
            var result = new byte[_data.Length];
            Buffer.BlockCopy(_data, 0, result, 0, _data.Length);
            fixed (byte* bytePtrT = &result[0])
            {
                var parts = new Concatenator();
                var addOn = new Add_On();

                // BASE PARTS
                parts._BASE = MODEL + parts._BASE;

                // _FRONT_BUMPER
                if (_autosculptFrontBumper == -1)
                    parts._FRONT_BUMPER = string.Empty;
                else
                    parts._FRONT_BUMPER =
                        MODEL + addOn._K10 + _autosculptFrontBumper.ToString("00") + parts._FRONT_BUMPER;

                // _REAR_BUMPER
                if (_autoSculptRearBumper == -1)
                    parts._REAR_BUMPER = string.Empty;
                else
                    parts._REAR_BUMPER = MODEL + addOn._K10 + _autoSculptRearBumper.ToString("00") + parts._REAR_BUMPER;

                // _BODY
                parts._BASE_KIT = MODEL + addOn._KIT + addOn._0 + parts._BASE_KIT;

                // _KITW_BODY
                if (_aftermarketBodyKit == -1)
                    parts._KITW_BODY = string.Empty;
                else
                    parts._KITW_BODY = MODEL + addOn._KITW + _aftermarketBodyKit + parts._KITW_BODY;

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

                // _TRUNK
                parts._TRUNK = MODEL + addOn._KIT + addOn._0 + parts._TRUNK;

                // _SKIRT
                if (_autoSculptSkirt == -1)
                    parts._SKIRT = string.Empty;
                else
                    parts._SKIRT = MODEL + addOn._K10 + _autoSculptSkirt.ToString("00") + parts._SKIRT;

                // _SPOILER
                if (_spoilerType == eSTypes.NULL)
                    parts._SPOILER = string.Empty;
                else if (_spoilerStyle == 0 || _spoilerType == eSTypes.STOCK)
                    parts._SPOILER = MODEL + addOn._KIT + addOn._0 + parts._SPOILER;
                else
                {
                    parts._SPOILER = addOn.SPOILER + addOn._STYLE + _spoilerStyle.ToString("00");
                    if (_spoilerType != eSTypes.BASE)
                        parts._SPOILER += _spoilerType.ToString();
                    if (_isCarbonFibreSpoiler == eBoolean.True)
                        parts._SPOILER += addOn._CF;
                }

                // _ENGINE
                if (_engineStyle == 0)
                    parts._ENGINE = MODEL + addOn._KIT + addOn._0 + parts._ENGINE;
                else
                    parts._ENGINE = MODEL + addOn._STYLE + _exhaustStyle.ToString("00") + parts._ENGINE;

                // _HEADLIGHT
                if (_headlightStyle == 0)
                    parts._HEADLIGHT = MODEL + addOn._KIT + addOn._0 + parts._HEADLIGHT;
                else
                    parts._HEADLIGHT = MODEL + addOn._STYLE + _headlightStyle.ToString("00") + parts._HEADLIGHT;

                // _BRAKELIGHT
                if (_brakeLightStyle == 0)
                    parts._BRAKELIGHT = MODEL + addOn._KIT + addOn._0 + parts._BRAKELIGHT;
                else
                    parts._BRAKELIGHT = MODEL + addOn._STYLE + _brakeLightStyle.ToString("00") + parts._BRAKELIGHT;

                // _EXHAUST
                if (_exhaustStyle == 0)
                    parts._KIT00_EXHAUST = MODEL + parts._KIT00_EXHAUST;
                else
                    parts._KIT00_EXHAUST = addOn.EXHAUST + addOn._STYLE + _exhaustStyle.ToString("00") + addOn._LEVEL1;

                // _DOOR / _PANEL / _SILL
                if (_aftermarketBodyKit == -1 || _aftermarketBodyKit == 0)
                {
                    var kit = MODEL + addOn._KIT + addOn._0;
                    parts._DOOR_LEFT = kit + parts._DOOR_LEFT;
                    parts._DOOR_RIGHT = kit + parts._DOOR_RIGHT;
                    parts._DOOR_PANEL_LEFT = kit + parts._DOOR_PANEL_LEFT;
                    parts._DOOR_PANEL_RIGHT = kit + parts._DOOR_PANEL_RIGHT;
                    parts._DOOR_SILL_LEFT = kit + parts._DOOR_SILL_LEFT;
                    parts._DOOR_SILL_RIGHT = kit + parts._DOOR_SILL_RIGHT;
                }
                else
                {
                    var kitW = MODEL + addOn._KITW + _aftermarketBodyKit;
                    parts._DOOR_LEFT = kitW + parts._DOOR_LEFT;
                    parts._DOOR_RIGHT = kitW + parts._DOOR_RIGHT;
                    parts._DOOR_PANEL_LEFT = kitW + parts._DOOR_PANEL_LEFT;
                    parts._DOOR_PANEL_RIGHT = kitW + parts._DOOR_PANEL_RIGHT;
                    parts._DOOR_SILL_LEFT = kitW + parts._DOOR_SILL_LEFT;
                    parts._DOOR_SILL_RIGHT = kitW + parts._DOOR_SILL_RIGHT;
                }

                // _HOOD_UNDER
                parts._HOOD_UNDER = MODEL + addOn._K10 + _underHoodStyle.ToString("00") + parts._HOOD_UNDER;

                // _TRUNK_UNDER
                parts._TRUNK_UNDER = MODEL + addOn._KIT + addOn._0 + parts._TRUNK_UNDER;

                // _REAR_BRAKE
                if (_rearBrakeStyle == 0)
                    parts._REAR_BRAKE = MODEL + addOn._KIT + addOn._0 + parts._FRONT_BRAKE;
                else
                    parts._REAR_BRAKE = addOn.BRAKE + addOn._STYLE + _rearBrakeStyle.ToString("00");

                // _FRONT_BRAKE
                if (_frontBrakeStyle == 0)
                    parts._FRONT_BRAKE = MODEL + addOn._KIT + addOn._0 + parts._FRONT_BRAKE;
                else
                    parts._FRONT_BRAKE = addOn.BRAKE + addOn._STYLE + _frontBrakeStyle.ToString("00");

                // _WHEEL
                parts._WHEEL = GetValidRimString();

                // _MIRROR
                if (_wingMirrorStyle == BaseArguments.NULL || _wingMirrorStyle == BaseArguments.STOCK)
                    parts._WING_MIRROR = MODEL + addOn._KIT + addOn._0 + parts._WING_MIRROR;
                else
                    parts._WING_MIRROR = _wingMirrorStyle;

                // _TRUNK_AUDIO
                parts._TRUNK_AUDIO = MODEL + addOn._KIT + _trunkAudioStyle + parts._TRUNK_AUDIO;

                // _DECAL_RECT
                parts._DECAL_HOOD_RECT_ = MODEL + parts._DECAL_HOOD_RECT_ + _decalTypeHood;
                parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM;
                parts._DECAL_REAR_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_REAR_WINDOW_WIDE_MEDIUM;
                parts._DECAL_LEFT_DOOR_RECT_ = MODEL + parts._DECAL_LEFT_DOOR_RECT_;
                parts._DECAL_RIGHT_DOOR_RECT_ = MODEL + parts._DECAL_RIGHT_DOOR_RECT_;
                parts._DECAL_LEFT_QUARTER_RECT_ = MODEL + parts._DECAL_LEFT_QUARTER_RECT_ + _decalTypeLeftQuarter;
                parts._DECAL_RIGHT_QUARTER_RECT_ = MODEL + parts._DECAL_RIGHT_QUARTER_RECT_ + _decalTypeRightQuarter;
                parts._DECAL_LEFT_DOOR_RECT_MEDIUM =
                    MODEL + "_" + _decalWideLeftDoor + parts._DECAL_LEFT_DOOR_RECT_MEDIUM;
                parts._DECAL_RIGHT_DOOR_RECT_MEDIUM =
                    MODEL + "_" + _decalWideRightDoor + parts._DECAL_RIGHT_DOOR_RECT_MEDIUM;
                parts._DECAL_LEFT_QUARTER_RECT_MEDIUM =
                    MODEL + "_" + _decalWideLeftQuarter + parts._DECAL_LEFT_QUARTER_RECT_MEDIUM;
                parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM =
                    MODEL + "_" + _decalWideRightQuarter + parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM;

                // KIT_CARBON
                parts.KIT_CARBON = _carbonBody == eBoolean.True ? parts.CARBON_FIBRE : parts.CARBON_FIBRE_NONE;

                // HOOD_CARBON
                parts.HOOD_CARBON = _carbonHood == eBoolean.True ? parts.CARBON_FIBRE : parts.CARBON_FIBRE_NONE;

                // DOOR_CARBON
                parts.DOOR_CARBON = _carbonDoors == eBoolean.True ? parts.CARBON_FIBRE : parts.CARBON_FIBRE_NONE;

                // TRUNK_CARBON
                parts.TRUNK_CARBON = _carbonTrunk == eBoolean.True ? parts.CARBON_FIBRE : parts.CARBON_FIBRE_NONE;

                // WINDOW_TINT
                if (_windowTintType != BaseArguments.STOCK)
                    parts.WINDOW_TINT_STOCK = _windowTintType;

                // CABIN_NEON
                parts.CABIN_NEON_STYLE0 += SPECIALTIES.NeonCabinStyle.ToString();

                // _CV
                if (_cvMiscStyle == 0)
                    parts._CV = MODEL + parts._CV;
                else
                    parts._CV = MODEL + addOn._KITW + _cvMiscStyle + parts._CV;

                // Hash all strings to keys
                var keys = StringToKey(parts);

                // In UG2 support it does not matter if a car exists/was modified, we still
                // can write all the strings in it b/c all of them are known
                *(uint*) bytePtrT = _unknown1;
                *(uint*) (bytePtrT + 4) = _unknown2;

                // Write MODEL
                for (var a1 = 8; a1 < 0x28; ++a1)
                    *(bytePtrT + a1) = 0;
                for (var a1 = 0; a1 < MODEL.Length; ++a1)
                    *(bytePtrT + 8 + a1) = (byte) MODEL[a1];

                // Write CollectionName
                for (var a1 = 0x28; a1 < 0x48; ++a1)
                    *(bytePtrT + a1) = 0;
                for (var a1 = 0; a1 < CollName.Length; ++a1)
                    *(bytePtrT + 0x28 + a1) = (byte) CollName[a1];

                // Performance Level
                *(int*) (bytePtrT + 0x48) = _performanceLevel;

                // Begin Writing Keys
                *(uint*) (bytePtrT + 0x4C) = keys[0];
                *(uint*) (bytePtrT + 0x50) = keys[1];
                *(uint*) (bytePtrT + 0x54) = keys[2];
                *(uint*) (bytePtrT + 0x60) = keys[3];
                *(uint*) (bytePtrT + 0x64) = keys[4];
                *(uint*) (bytePtrT + 0x68) = keys[5];

                for (var a1 = 0; a1 < 14; ++a1)
                    *(uint*) (bytePtrT + 0x70 + a1 * 4) = keys[6 + a1];

                for (var a1 = 0; a1 < 5; ++a1)
                    *(uint*) (bytePtrT + 0xB0 + a1 * 4) = keys[20 + a1];

                *(uint*) (bytePtrT + 0xC4) = keys[24];

                for (var a1 = 0; a1 < 15; ++a1)
                    *(uint*) (bytePtrT + 0xCC + a1 * 4) = keys[25 + a1];

                for (var a1 = 0; a1 < 45; ++a1)
                    *(uint*) (bytePtrT + 0x11C + a1 * 4) = keys[40 + a1];

                // Write Decals
                DECALS_HOOD.Write(bytePtrT + 0x1D0);
                DECALS_FRONT_WINDOW.Write(bytePtrT + 0x1F0);
                DECALS_REAR_WINDOW.Write(bytePtrT + 0x210);
                DECALS_LEFT_DOOR.Write(bytePtrT + 0x230);
                DECALS_RIGHT_DOOR.Write(bytePtrT + 0x250);
                DECALS_LEFT_QUARTER.Write(bytePtrT + 0x270);
                DECALS_RIGHT_QUARTER.Write(bytePtrT + 0x290);

                // Finish Writing Keys
                for (var a1 = 0; a1 < 14; ++a1)
                    *(uint*) (bytePtrT + 0x2B0 + a1 * 4) = keys[85 + a1];

                *(uint*) (bytePtrT + 0x2F0) = keys[99];
            }

            return result;
        }
    }
}