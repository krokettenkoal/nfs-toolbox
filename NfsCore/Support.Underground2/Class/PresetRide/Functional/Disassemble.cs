using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Shared.Parts.PresetParts;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            // Copy array into the memory
            for (var x = 0; x < 0x338; ++x)
                _data[x] = *(bytePtrT + x);

            var model = string.Empty; // MODEL of the car
            string v1; // main for class strings
            string v2; // main for system strings
            string v3; // extra for strings
            var v4 = string.Empty; // extra for strings
            uint a1; // only if one hash at a time
            uint a2; // read hash from file only
            uint a3; // extra for hashes, loops
            uint a4; // extra for hashes, loops

            var parts = new Concatenator(); // assign actual concatenator
            var addOn = new Add_On(); // assign actual add_on

            // Get unknown values
            _unknown1 = *(uint*) bytePtrT;
            _unknown2 = *(uint*) (bytePtrT + 4);

            // Get the model name
            for (var x = 8; *(bytePtrT + x) != 0; ++x)
                model += ((char) *(bytePtrT + x)).ToString();

            // Assign MODEL string
            MODEL = model;
            OriginalModel = model;

            // Begin reading
            _performanceLevel = *(int*) (bytePtrT + 0x48);
            a1 = Bin.Hash(model + parts._BASE); // for RaiderKeys

            // try to match _FRONT_BUMPER
            a2 = *(uint*) (bytePtrT + 0x50);
            if (a2 == 0)
            {
                _autosculptFrontBumper = -1;
                goto LABEL_REAR_BUMPER;
            }

            for (a3 = 0; a3 < 31; ++a3)
            {
                a1 = Bin.Hash($"{model}{addOn._K10}{a3:00}{parts._FRONT_BUMPER}");
                if (a1 == a2)
                {
                    _autosculptFrontBumper = (sbyte) a3;
                    goto LABEL_REAR_BUMPER;
                }
            }

            LABEL_REAR_BUMPER:
            // Try to match _REAR_BUMPER
            a2 = *(uint*) (bytePtrT + 0x54);
            if (a2 == 0)
            {
                _autoSculptRearBumper = -1;
                goto LABEL_BODY;
            }

            for (a3 = 0; a3 < 31; ++a3) // 10 rear bumper styles
            {
                a1 = Bin.Hash($"{model}{addOn._K10}{a3:00}{parts._REAR_BUMPER}");
                if (a1 != a2) continue;
                _autoSculptRearBumper = (sbyte) a3;
                goto LABEL_BODY;
            }

            LABEL_BODY:
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._BASE_KIT); // for RaiderKeys

            // Try match _KITW_BODY
            a2 = *(uint*) (bytePtrT + 0x64);
            if (a2 == 0)
            {
                _aftermarketBodyKit = -1;
                goto LABEL_ROOF;
            }

            for (a3 = 0; a3 < 5; ++a3) // 4 aftermarket bodykits
            {
                a1 = Bin.Hash(model + addOn._KITW + a3 + parts._BASE_KIT);
                if (a1 != a2) continue;
                _aftermarketBodyKit = (sbyte) a3;
                goto LABEL_ROOF;
            }

            LABEL_ROOF:
            // Try to match ROOF_STYLE
            a2 = *(uint*) (bytePtrT + 0x68);
            a1 = Bin.Hash(parts.ROOF_STYLE + addOn._0 + addOn._0);
            if (a2 == 0 || a1 == a2)
            {
                _roofScoopStyle = 0;
                goto LABEL_HOOD; // skip the rest of the statements
            }

            for (byte x1 = 1; x1 < 18; ++x1) // all 17 roof scoop styles
            {
                var x1Pad = x1.ToString("00");
                v1 = parts.ROOF_STYLE + x1Pad;
                v3 = parts.ROOF_STYLE + x1Pad + addOn._OFFSET;
                v4 = parts.ROOF_STYLE + x1Pad + addOn._DUAL;
                a1 = Bin.Hash(v1);
                a3 = Bin.Hash(v3);
                a4 = Bin.Hash(v4);
                if (a1 == a2)
                {
                    _roofScoopStyle = x1;
                    goto LABEL_HOOD;
                }

                if (a3 == a2)
                {
                    _roofScoopStyle = x1;
                    _isOffsetRoofScoop = eBoolean.True;
                    goto LABEL_HOOD;
                }

                if (a4 == a2)
                {
                    _roofScoopStyle = x1;
                    _isDualRoofScoop = eBoolean.True;
                    goto LABEL_HOOD;
                }

                a1 = Bin.Hash(v1 + addOn._CF);
                a3 = Bin.Hash(v3 + addOn._CF);
                a4 = Bin.Hash(v4 + addOn._CF);
                if (a1 == a2)
                {
                    _roofScoopStyle = x1;
                    _isCarbonFibreRoofScoop = eBoolean.True;
                    goto LABEL_HOOD;
                }

                if (a3 == a2)
                {
                    _roofScoopStyle = x1;
                    _isDualRoofScoop = eBoolean.True;
                    _isCarbonFibreRoofScoop = eBoolean.True;
                    goto LABEL_HOOD;
                }

                if (a4 != a2) continue;
                _roofScoopStyle = x1;
                _isDualRoofScoop = eBoolean.True;
                _isCarbonFibreRoofScoop = eBoolean.True;
                goto LABEL_HOOD;
            }

            LABEL_HOOD:
            a1 = Bin.Hash(model + parts._TOP); // for RaiderKeys

            // Try match _HOOD
            a2 = *(uint*) (bytePtrT + 0x70);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._HOOD);
            if (a2 == 0 || a1 == a2)
            {
                _hoodStyle = 0;
                goto LABEL_SKIRT;
            }

            for (byte x1 = 1; x1 < 29; ++x1) // 28 hood styles
            {
                v1 = $"{model}{addOn._STYLE}{x1:00}{parts._HOOD}";
                a1 = Bin.Hash(v1);
                if (a1 == a2)
                {
                    _hoodStyle = x1;
                    goto LABEL_SKIRT;
                }

                // try carbonfibre
                a1 = Bin.Hash(v1 + addOn._CF);
                if (a1 != a2) continue;
                _hoodStyle = x1;
                _isCarbonFibreHood = eBoolean.True;
                goto LABEL_SKIRT;
            }

            LABEL_SKIRT:
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._TRUNK);
            // Try to match _SKIRT
            a2 = *(uint*) (bytePtrT + 0x78);
            if (a2 == 0)
            {
                _autoSculptSkirt = -1;
                goto LABEL_SPOILER;
            }

            for (a3 = 0; a3 < 31; ++a3) // 10 rear bumper styles
            {
                a1 = Bin.Hash($"{model}{addOn._K10}{a3:00}{parts._SKIRT}");
                if (a1 != a2) continue;
                _autoSculptSkirt = (sbyte) a3;
                goto LABEL_SPOILER;
            }

            LABEL_SPOILER:
            // Try to match spoiler
            a2 = *(uint*) (bytePtrT + 0x7C);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._SPOILER);
            if (a2 == 0)
            {
                _spoilerStyle = 0;
                _spoilerType = eSTypes.NULL; // means spoiler is nulled
                goto LABEL_ENGINE;
            }

            if (a1 == a2)
            {
                _spoilerStyle = 0;
                _spoilerType = eSTypes.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 3; ++x1) // all 3 spoiler types
                {
                    for (byte x2 = 1; x2 < 41; ++x2) // all 40 spoiler styles
                    {
                        v3 = $"{addOn.SPOILER}{addOn._STYLE}{x2:00}{addOn._USTYPE[x1]}";
                        a3 = Bin.Hash(v3);
                        if (a3 == a2)
                        {
                            _spoilerStyle = x2;
                            v4 = addOn._USTYPE[x1];
                            goto LABEL_ENGINE; // break the whole loop
                        }

                        // try carbonfibre
                        a3 = Bin.Hash(v3 + addOn._CF);
                        if (a3 != a2) continue;
                        _spoilerStyle = x2;
                        v4 = addOn._USTYPE[x1];
                        _isCarbonFibreSpoiler = eBoolean.True;
                        goto LABEL_ENGINE; // break the whole loop
                    }
                }
            }

            LABEL_ENGINE:
            // fix spoiler settings first
            if (string.IsNullOrEmpty(v4))
                _spoilerType = eSTypes.BASE; // use BASE to make it clearer
            else
                System.Enum.TryParse(v4, out _spoilerType);

            a2 = *(uint*) (bytePtrT + 0x80);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._ENGINE);
            if (a2 == 0 || a1 == a2)
            {
                _engineStyle = 0;
                goto LABEL_HEADLIGHT;
            }

            for (a3 = 0; a3 < 4; ++a3)
            {
                a1 = Bin.Hash(model + addOn._STYLE + addOn._0 + a3 + parts._ENGINE);
                if (a1 != a2) continue;
                _engineStyle = (byte) a3;
                goto LABEL_HEADLIGHT;
            }

            LABEL_HEADLIGHT:
            a2 = *(uint*) (bytePtrT + 0x84);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._HEADLIGHT);
            if (a2 == 0 || a1 == a2)
            {
                _headlightStyle = 0;
                goto LABEL_BRAKELIGHT;
            }

            for (a3 = 0; a3 < 15; ++a3)
            {
                a1 = Bin.Hash($"{model}{addOn._STYLE}{a3:00}{parts._HEADLIGHT}");
                if (a1 != a2) continue;
                _headlightStyle = (byte) a3;
                goto LABEL_BRAKELIGHT;
            }

            LABEL_BRAKELIGHT:
            a2 = *(uint*) (bytePtrT + 0x88);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._BRAKELIGHT);
            if (a2 == 0 || a1 == a2)
            {
                _brakeLightStyle = 0;
                goto LABEL_EXHAUST;
            }

            for (a3 = 0; a3 < 15; ++a3)
            {
                a1 = Bin.Hash($"{model}{addOn._STYLE}{a3:00}{parts._BRAKELIGHT}");
                if (a1 != a2) continue;
                _brakeLightStyle = (byte) a3;
                goto LABEL_EXHAUST;
            }

            LABEL_EXHAUST:
            a2 = *(uint*) (bytePtrT + 0x8C);
            a1 = Bin.Hash(model + parts._KIT00_EXHAUST);
            if (a2 == 0 || a1 == a2)
            {
                _exhaustStyle = 0;
                goto LABEL_HOOD_UNDER;
            }

            for (a3 = 0; a3 < 11; ++a3)
            {
                a1 = Bin.Hash($"{addOn.EXHAUST}{addOn._STYLE}{a3:00}{addOn._LEVEL1}");
                if (a1 != a2) continue;
                _exhaustStyle = (byte) a3;
                goto LABEL_HOOD_UNDER;
            }

            LABEL_HOOD_UNDER:
            a2 = *(uint*) (bytePtrT + 0xB0);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._HOOD_UNDER);
            if (a2 == 0 || a1 == a2)
                _underHoodStyle = 0;
            else
            {
                for (a3 = 21; a3 < 26; ++a3) // only 21-25 are valid
                {
                    a1 = Bin.Hash(model + addOn._K10 + a3 + parts._HOOD_UNDER);
                    if (a1 != a2) continue;
                    _underHoodStyle = (byte) a3;
                    break;
                }
            }

            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._TRUNK_UNDER); // for RaiderKeys

            // FRONT_BRAKE
            a2 = *(uint*) (bytePtrT + 0xB8);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._FRONT_BRAKE);
            if (a2 == 0 || a1 == a2)
                _frontBrakeStyle = 0;
            else
            {
                for (a3 = 1; a3 < 4; ++a3)
                {
                    a1 = Bin.Hash(addOn.BRAKE + addOn._STYLE + addOn._0 + a3);
                    if (a1 != a2) continue;
                    _frontBrakeStyle = (byte) a3;
                    break;
                }
            }

            // REAR_BRAKE
            a2 = *(uint*) (bytePtrT + 0xBC);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._FRONT_BRAKE);
            if (a2 == 0 || a1 == a2)
                _rearBrakeStyle = 0;
            else
            {
                for (a3 = 1; a3 < 4; ++a3)
                {
                    a1 = Bin.Hash(addOn.BRAKE + addOn._STYLE + addOn._0 + a3);
                    if (a1 != a2) continue;
                    _rearBrakeStyle = (byte) a3;
                    break;
                }
            }

            // WHEELS
            a2 = *(uint*) (bytePtrT + 0xC0);
            if (Map.BinKeys.TryGetValue(a2, out v2))
                DisperseRimSettings(v2);
            else
                _rimBrand = BaseArguments.STOCK;

            // WING_MIRROR
            a2 = *(uint*) (bytePtrT + 0xCC);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._WING_MIRROR);
            if (a2 == 0 || a1 == a2)
                _wingMirrorStyle = BaseArguments.STOCK;
            else
                _wingMirrorStyle = $"0x{a2:X8}";


            // TRUNK_AUDIO
            a2 = *(uint*) (bytePtrT + 0xD4);
            for (a3 = 0; a3 < 4; ++a3)
            {
                a1 = Bin.Hash(model + addOn._KIT + a3 + parts._TRUNK_AUDIO);
                if (a1 != a2) continue;
                _trunkAudioStyle = (byte) a3;
                break;
            }

            // ALL TRUNK AUDIOS AND BUFFERS
            AUDIO_COMP.Read(bytePtrT + 0xD8);

            // Skip all Damage, goto decal types
            a2 = *(uint*) (bytePtrT + 0x11C);
            a3 = Bin.Hash(model + parts._DECAL_HOOD_RECT_MEDIUM);
            a4 = Bin.Hash(model + parts._DECAL_HOOD_RECT_SMALL);
            if (a3 == a2) _decalTypeHood = eDecalType.MEDIUM;
            else if (a4 == a2) _decalTypeHood = eDecalType.SMALL;
            else _decalTypeHood = eDecalType.NONE;

            Bin.Hash(model + parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM);
            Bin.Hash(model + parts._DECAL_REAR_WINDOW_WIDE_MEDIUM);
            Bin.Hash(model + parts._DECAL_LEFT_DOOR_RECT_MEDIUM);
            Bin.Hash(model + parts._DECAL_RIGHT_DOOR_RECT_MEDIUM);

            a2 = *(uint*) (bytePtrT + 0x130);
            a3 = Bin.Hash(model + parts._DECAL_LEFT_QUARTER_RECT_MEDIUM);
            a4 = Bin.Hash(model + parts._DECAL_LEFT_QUARTER_RECT_SMALL);
            if (a3 == a2) _decalTypeLeftQuarter = eDecalType.MEDIUM;
            else if (a4 == a2) _decalTypeLeftQuarter = eDecalType.SMALL;
            else _decalTypeLeftQuarter = eDecalType.NONE;

            a2 = *(uint*) (bytePtrT + 0x134);
            a3 = Bin.Hash(model + parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM);
            a4 = Bin.Hash(model + parts._DECAL_RIGHT_QUARTER_RECT_SMALL);
            if (a3 == a2) _decalTypeRightQuarter = eDecalType.MEDIUM;
            else if (a4 == a2) _decalTypeRightQuarter = eDecalType.SMALL;
            else _decalTypeRightQuarter = eDecalType.NONE;

            var wideStrings = System.Enum.GetNames(typeof(eWideDecalType));
            a2 = *(uint*) (bytePtrT + 0x138);
            foreach (var wide in wideStrings)
            {
                a1 = Bin.Hash($"{model}_{wide}{parts._DECAL_LEFT_DOOR_RECT_MEDIUM}");
                if (a1 != a2) continue;
                System.Enum.TryParse(wide, out _decalWideLeftDoor);
                break;
            }

            a2 = *(uint*) (bytePtrT + 0x13C);
            foreach (var wide in wideStrings)
            {
                a1 = Bin.Hash($"{model}_{wide}{parts._DECAL_RIGHT_DOOR_RECT_MEDIUM}");
                if (a1 != a2) continue;
                System.Enum.TryParse(wide, out _decalWideRightDoor);
                break;
            }

            a2 = *(uint*) (bytePtrT + 0x140);
            foreach (var wide in wideStrings)
            {
                a1 = Bin.Hash($"{model}_{wide}{parts._DECAL_LEFT_QUARTER_RECT_MEDIUM}");
                if (a1 != a2) continue;
                System.Enum.TryParse(wide, out _decalWideLeftQuarter);
                break;
            }

            a2 = *(uint*) (bytePtrT + 0x144);
            foreach (var wide in wideStrings)
            {
                a1 = Bin.Hash($"{model}_{wide}{parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM}");
                if (a1 != a2) continue;
                System.Enum.TryParse(wide, out _decalWideRightQuarter);
                break;
            }

            // Paint Types
            a2 = *(uint*) (bytePtrT + 0x148);
            PAINT_TYPES.BasePaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x15C);
            PAINT_TYPES.EnginePaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x160);
            PAINT_TYPES.SpoilerPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x164);
            PAINT_TYPES.BrakesPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x168);
            PAINT_TYPES.ExhaustPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x16C);
            PAINT_TYPES.AudioPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x170);
            PAINT_TYPES.RimsPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x174);
            PAINT_TYPES.SpinnersPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x178);
            PAINT_TYPES.RoofPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x17C);
            PAINT_TYPES.MirrorsPaintType = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            // Vinyls and Colors
            a2 = *(uint*) (bytePtrT + 0x14C);
            VINYL_SETS.VinylLayer0 = Map.Lookup(a2, true) ?? $"0x{a2:X8}";
            a2 = *(uint*) (bytePtrT + 0x150);
            VINYL_SETS.VinylLayer1 = Map.Lookup(a2, true) ?? $"0x{a2:X8}";
            a2 = *(uint*) (bytePtrT + 0x154);
            VINYL_SETS.VinylLayer2 = Map.Lookup(a2, true) ?? $"0x{a2:X8}";
            a2 = *(uint*) (bytePtrT + 0x158);
            VINYL_SETS.VinylLayer3 = Map.Lookup(a2, true) ?? $"0x{a2:X8}";

            a2 = *(uint*) (bytePtrT + 0x180);
            VINYL_SETS.Vinyl0_Color0 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x184);
            VINYL_SETS.Vinyl0_Color1 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x188);
            VINYL_SETS.Vinyl0_Color2 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x18C);
            VINYL_SETS.Vinyl0_Color3 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x190);
            VINYL_SETS.Vinyl1_Color0 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x194);
            VINYL_SETS.Vinyl1_Color1 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x198);
            VINYL_SETS.Vinyl1_Color2 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x19C);
            VINYL_SETS.Vinyl1_Color3 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1A0);
            VINYL_SETS.Vinyl2_Color0 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1A4);
            VINYL_SETS.Vinyl2_Color1 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1A8);
            VINYL_SETS.Vinyl2_Color2 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1AC);
            VINYL_SETS.Vinyl2_Color3 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1B0);
            VINYL_SETS.Vinyl3_Color0 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1B4);
            VINYL_SETS.Vinyl3_Color1 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1B8);
            VINYL_SETS.Vinyl3_Color2 = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x1BC);
            VINYL_SETS.Vinyl3_Color3 = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            // Carbonfibre Settings
            a2 = *(uint*) (bytePtrT + 0x1C0);
            HasCarbonfibreBody = Map.Lookup(a2, true) == parts.CARBON_FIBRE ? eBoolean.True : eBoolean.False;
            a2 = *(uint*) (bytePtrT + 0x1C4);
            HasCarbonfibreHood = Map.Lookup(a2, true) == parts.CARBON_FIBRE ? eBoolean.True : eBoolean.False;
            a2 = *(uint*) (bytePtrT + 0x1C8);
            HasCarbonfibreDoors = Map.Lookup(a2, true) == parts.CARBON_FIBRE ? eBoolean.True : eBoolean.False;
            a2 = *(uint*) (bytePtrT + 0x1CC);
            HasCarbonfibreTrunk = Map.Lookup(a2, true) == parts.CARBON_FIBRE ? eBoolean.True : eBoolean.False;

            // Decal Arrays
            DECALS_HOOD.Read(bytePtrT + 0x1D0);
            DECALS_FRONT_WINDOW.Read(bytePtrT + 0x1F0);
            DECALS_REAR_WINDOW.Read(bytePtrT + 0x210);
            DECALS_LEFT_DOOR.Read(bytePtrT + 0x230);
            DECALS_RIGHT_DOOR.Read(bytePtrT + 0x250);
            DECALS_LEFT_QUARTER.Read(bytePtrT + 0x270);
            DECALS_RIGHT_QUARTER.Read(bytePtrT + 0x290);

            // WINDOW_TINT
            a2 = *(uint*) (bytePtrT + 0x2B0);
            if (a2 == 0 || a2 == Bin.Hash(parts.WINDOW_TINT_STOCK))
                _windowTintType = BaseArguments.STOCK;
            else
                _windowTintType = Map.Lookup(a2, false) ?? BaseArguments.STOCK;

            // Specialties
            a1 = Bin.Hash(parts.NEON_NONE);
            a2 = *(uint*) (bytePtrT + 0x2B4);
            if (a1 == a2) SPECIALTIES.NeonBody = parts.NEON_NONE;
            else SPECIALTIES.NeonBody = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x2B8);
            if (a1 == a2) SPECIALTIES.NeonEngine = parts.NEON_NONE;
            else SPECIALTIES.NeonEngine = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x2BC);
            if (a1 == a2) SPECIALTIES.NeonCabin = parts.NEON_NONE;
            else SPECIALTIES.NeonCabin = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x2C0);
            if (a1 == a2) SPECIALTIES.NeonTrunk = parts.NEON_NONE;
            else SPECIALTIES.NeonTrunk = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            a2 = *(uint*) (bytePtrT + 0x2C4);
            if (a2 != 0)
            {
                for (a3 = 0; a3 < 4; ++a3)
                {
                    a1 = Bin.Hash(parts.CABIN_NEON_STYLE0 + a3);
                    if (a1 != a2) continue;
                    SPECIALTIES.NeonCabinStyle = (byte) a3;
                    break;
                }
            }

            a1 = Bin.Hash(BaseArguments.STOCK);
            a2 = *(uint*) (bytePtrT + 0x2C8);
            if (a2 == 0 || a1 == a2) SPECIALTIES.HeadlightBulbStyle = BaseArguments.STOCK;
            else SPECIALTIES.HeadlightBulbStyle = Map.Lookup(a2, false) ?? BaseArguments.STOCK;
            a2 = *(uint*) (bytePtrT + 0x2CC);
            if (a2 == 0 || a1 == a2) SPECIALTIES.DoorOpeningStyle = BaseArguments.STOCK;
            else SPECIALTIES.DoorOpeningStyle = Map.Lookup(a2, false) ?? BaseArguments.STOCK;
            a1 = Bin.Hash(parts.NO_HYDRAULICS);
            a2 = *(uint*) (bytePtrT + 0x2D0);
            if (a1 == a2) SPECIALTIES.HydraulicsStyle = parts.NO_HYDRAULICS;
            else SPECIALTIES.HydraulicsStyle = Map.Lookup(a2, true) ?? BaseArguments.NULL;
            a2 = *(uint*) (bytePtrT + 0x2D4);
            SPECIALTIES.NOSPurgeStyle = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            // HUD Options
            a2 = *(uint*) (bytePtrT + 0x2D8);
            if (a2 == 0) _customHudStyle = BaseArguments.STOCK;
            else _customHudStyle = Map.Lookup(a2, false) ?? BaseArguments.STOCK;
            a2 = *(uint*) (bytePtrT + 0x2DC);
            if (a2 == 0) _hudBackingColor = BaseArguments.WHITE;
            else _hudBackingColor = Map.Lookup(a2, false) ?? BaseArguments.WHITE;
            a2 = *(uint*) (bytePtrT + 0x2E0);
            if (a2 == 0) _hudNeedleColor = BaseArguments.WHITE;
            else _hudNeedleColor = Map.Lookup(a2, false) ?? BaseArguments.WHITE;
            a2 = *(uint*) (bytePtrT + 0x2E4);
            if (a2 == 0) _hudCharacterColor = BaseArguments.WHITE;
            else _hudCharacterColor = Map.Lookup(a2, false) ?? BaseArguments.WHITE;

            // _CV
            a2 = *(uint*) (bytePtrT + 0x2F0);
            a1 = Bin.Hash(model + parts._CV);
            if (a2 == 0 || a1 == a2)
                _cvMiscStyle = 0;
            else
            {
                for (a3 = 1; a3 < 5; ++a3)
                {
                    a1 = Bin.Hash(model + addOn._KITW + a3 + parts._CV);
                    if (a1 != a2) continue;
                    _cvMiscStyle = (byte) a3;
                    break;
                }
            }
        }
    }
}