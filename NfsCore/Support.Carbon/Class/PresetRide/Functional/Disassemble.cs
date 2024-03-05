using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Shared.Parts.PresetParts;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Disassembles preset ride array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the preset ride array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            // Copy array into the memory
            for (var x = 0; x < 0x600; ++x)
                _data[x] = *(bytePtrT + x);

            var model = string.Empty; // MODEL of the car
            const string hex = "0x"; // for hex representations
            string v3; // extra for strings
            string v4; // extra for strings
            uint a3; // extra for hashes, loops
            uint a4; // extra for hashes, loops

            var parts = new Concatenator(); // assign actual concatenator
            var addOn = new Add_On(); // assign actual add_on

            // Get the model name
            for (var x = 8; *(bytePtrT + x) != 0; ++x)
                model += ((char) *(bytePtrT + x)).ToString();

            // Assign MODEL string
            MODEL = model;
            OriginalModel = model;

            // Frontend hash
            var a1 = *(uint*) (bytePtrT + 0x48); // only if one hash at a time
            Frontend = Map.VltKeys.TryGetValue(a1, out var v1) ? v1 : $"{hex}{a1:X8}";

            // Pvehicle hash
            a1 = *(uint*) (bytePtrT + 0x50);
            Pvehicle = Map.VltKeys.TryGetValue(a1, out v1) ? v1 : $"{hex}{a1:X8}";

            a1 = Bin.Hash(model + parts._BASE); // for RaiderKeys

            // try to match _BODY
            var a2 = *(uint*) (bytePtrT + 0xBC); // read hash from file only
            if (a2 == 0)
            {
                _aftermarketBodyKit = -1; // basically no difference between this one and next one
                goto LABEL_LIGHTS;
            }

            a1 = Bin.Hash(model + parts._BASE_KIT);
            if (a1 == a2)
            {
                _aftermarketBodyKit = -1;
                goto LABEL_LIGHTS;
            }

            a1 = Bin.Hash(model + parts._BASE_KIT + addOn._KIT + addOn._0); // (MODEL)_BODY_KIT00
            if (a1 == a2)
            {
                _aftermarketBodyKit = 0;
            }
            else
            {
                for (var x1 = 0; x1 < 6; ++x1) // 5 bodykits max
                {
                    a1 = Bin.Hash(model + parts._BASE_KIT + addOn._KITW + x1);
                    if (a1 != a2) continue;
                    _aftermarketBodyKit = (sbyte) x1;
                    goto LABEL_LIGHTS;
                }
            }

            LABEL_LIGHTS:
            // Try match popup lights
            a2 = *(uint*) (bytePtrT + 0xE0);
            a1 = Bin.Hash(model + parts._LEFT_HEADLIGHT + addOn._ON);
            _popupHeadlightsExist = (a2 == 0) ? eBoolean.False : eBoolean.True; // either this
            _popupHeadlightsExist = (a1 == a2) ? eBoolean.True : eBoolean.False; // or this
            a2 = *(uint*) (bytePtrT + 0xE4);
            if (a2 == 0)
                goto LABEL_EXHAUST; // skip if statements if null
            if (_popupHeadlightsExist == eBoolean.True)
            {
                a1 = Bin.Hash(model + parts._LEFT_HEADLIGHT_GLASS + addOn._OFF);
                _popupHeadlightsOn = (a1 == a2) ? eBoolean.False : eBoolean.True;
            }
            else
                _popupHeadlightsOn = eBoolean.False;

            LABEL_EXHAUST:
            // Try exhaust match
            a2 = *(uint*) (bytePtrT + 0x11C);
            if (a2 == 0)
            {
                _exhaustStyle = -1;
                goto LABEL_SPOILER; // skip the rest of statements
            }

            a1 = Bin.Hash(model + parts._KIT00_EXHAUST); // stock exhaust
            if (a1 == a2)
            {
                _exhaustStyle = 0;
            }
            else
            {
                for (sbyte x1 = 0; x1 < 18; ++x1) // 17 exhaust styles
                {
                    a1 = Bin.Hash(addOn.EXHAUST + addOn._STYLE + x1.ToString("00") + addOn._LEVEL1);
                    if (a1 == a2)
                    {
                        _exhaustStyle = x1;
                        goto LABEL_SPOILER;
                    }

                    a1 = Bin.Hash(addOn.EXHAUST + addOn._STYLE + x1.ToString("00") + addOn._CENTER + addOn._LEVEL1);
                    if (a1 != a2) continue;
                    _exhaustStyle = x1;
                    _isCenterExhaust = eBoolean.True;
                    goto LABEL_SPOILER;
                }
            } // this._exhaust_size (size of exhaust) is the autosculpt value later on

            LABEL_SPOILER:
            // Try match spoiler
            // (MODEL)_SPOILER[SPOILER_STYLE(01 - 29)(TYPE)(_CF)]
            a2 = *(uint*) (bytePtrT + 0x120);
            if (a2 == 0)
            {
                _spoilerStyle = 0;
                _spoilerType = eSTypes.NULL; // means spoiler is nulled
                goto LABEL_FRONT_BUMPER;
            }

            a1 = Bin.Hash(model + parts._SPOILER);
            if (a1 == a2)
            {
                // stock spoiler
                _spoilerStyle = 0;
                _spoilerType = eSTypes.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 4; ++x1) // all 4 spoiler types
                {
                    for (byte x2 = 1; x2 < 30; ++x2) // all 29 spoiler styles
                    {
                        v3 = addOn.SPOILER + addOn._STYLE + x2.ToString("00") + addOn._CSTYPE[x1];
                        v4 = addOn.AS_SPOILER + addOn._STYLE + x2.ToString("00") + addOn._CSTYPE[x1];
                        a3 = Bin.Hash(v3);
                        a4 = Bin.Hash(v4);
                        if (a3 == a2)
                        {
                            _spoilerStyle = x2;
                            v1 = addOn._CSTYPE[x1];
                            goto LABEL_FRONT_BUMPER; // break the whole loop
                        }

                        if (a4 == a2)
                        {
                            _spoilerStyle = x2;
                            v1 = addOn._CSTYPE[x1];
                            _isAutoSculptSpoiler = eBoolean.True;
                            goto LABEL_FRONT_BUMPER; // break the whole loop
                        }

                        // try carbonfibre
                        a3 = Bin.Hash(v3 + addOn._CF);
                        a4 = Bin.Hash(v4 + addOn._CF);
                        if (a3 == a2)
                        {
                            _spoilerStyle = x2;
                            v1 = addOn._CSTYPE[x1];
                            _isCarbonFibreSpoiler = eBoolean.True;
                            goto LABEL_FRONT_BUMPER; // break the whole loop
                        }

                        if (a4 != a2) continue;
                        _spoilerStyle = x2;
                        v1 = addOn._CSTYPE[x1];
                        _isAutoSculptSpoiler = eBoolean.True;
                        _isCarbonFibreSpoiler = eBoolean.True;
                        goto LABEL_FRONT_BUMPER; // break the whole loop
                    }
                }
            }

            // escape from a really big spoiler loop
            LABEL_FRONT_BUMPER:
            // fix spoiler settings first
            if (v1 == "")
                _spoilerType = eSTypes.BASE; // use BASE to make it clearer
            else
                Enum.TryParse(v1, out _spoilerType);

            // try to match _FRONT_BUMPER
            a2 = *(uint*) (bytePtrT + 0x180);
            if (a2 == 0)
            {
                _autoSculptFrontBumper = -1;
                goto LABEL_REAR_BUMPER;
            }

            for (a3 = 0; a3 < 10; ++a3)
            {
                a1 = Bin.Hash(model + addOn._K10 + a3.ToString("00") + parts._FRONT_BUMPER);
                if (a1 != a2) continue;
                _autoSculptFrontBumper = (sbyte) a3;
                goto LABEL_REAR_BUMPER;
            }

            LABEL_REAR_BUMPER:
            // Try to match _REAR_BUMPER
            a2 = *(uint*) (bytePtrT + 0x188);
            if (a2 == 0)
            {
                _autoSculptRearBumper = -1;
                goto LABEL_ROOF;
            }

            for (a3 = 0; a3 < 10; ++a3) // 10 rear bumper styles
            {
                a1 = Bin.Hash(model + addOn._K10 + a3.ToString("00") + parts._REAR_BUMPER);
                if (a1 != a2) continue;
                _autoSculptRearBumper = (sbyte) a3;
                goto LABEL_ROOF;
            }

            LABEL_ROOF:
            // Try to match _ROOF
            a2 = *(uint*) (bytePtrT + 0x190);
            if (a2 == 0 || Bin.Hash(model + parts._ROOF) == a2)
                _chopTopIsOn = eBoolean.False; // means no roof at all
            else
            {
                a1 = Bin.Hash(model + parts._ROOF + "_CHOP_TOP");
                if (a1 == a2)
                    _chopTopIsOn = eBoolean.True;
            }

            // Try to match ROOF_STYLE
            a2 = *(uint*) (bytePtrT + 0x194);
            a1 = Bin.Hash(parts.ROOF_STYLE + addOn._0 + addOn._0);
            if (a2 == 0 || a1 == a2)
            {
                _roofScoopStyle = 0;
                goto LABEL_HOOD; // skip the rest of the statements
            }

            for (byte x1 = 1; x1 < 19; ++x1) // all 18 roof scoop styles
            {
                var x1Pad = x1.ToString("00");
                v1 = parts.ROOF_STYLE + x1Pad;
                v3 = parts.ROOF_STYLE + x1Pad + addOn._AUTOSCULPT;
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
                    _isAutoSculptRoofScoop = eBoolean.True;
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
                    _isAutoSculptRoofScoop = eBoolean.True;
                    _isCarbonFibreRoofScoop = eBoolean.True;
                    goto LABEL_HOOD;
                }

                if (a4 != a2) continue;
                _roofScoopStyle = x1;
                _isDualRoofScoop = eBoolean.True;
                _isCarbonFibreRoofScoop = eBoolean.True;
                goto LABEL_HOOD;
            }

            // escape from a really big roofscoop loop
            LABEL_HOOD:
            // Try match _HOOD
            a2 = *(uint*) (bytePtrT + 0x198);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._HOOD);
            if (a2 == 0 || a1 == a2)
            {
                _hoodStyle = 0; // means no hood
                goto LABEL_SKIRT;
            }

            for (byte x1 = 1; x1 < 9; ++x1) // 8 styles max
            {
                v3 = model + addOn._STYLE + addOn._0 + x1 + parts._HOOD;
                v4 = model + addOn._STYLE + addOn._0 + x1 + parts._HOOD + addOn._AS;
                a3 = Bin.Hash(v3);
                a4 = Bin.Hash(v4);
                if (a3 == a2)
                {
                    _hoodStyle = x1;
                    goto LABEL_SKIRT;
                }

                if (a4 == a2)
                {
                    _hoodStyle = x1;
                    _isAutoSculptHood = eBoolean.True;
                    goto LABEL_SKIRT;
                }

                a3 = Bin.Hash(v3 + addOn._CF);
                a4 = Bin.Hash(v4 + addOn._CF);
                if (a3 == a2)
                {
                    _hoodStyle = x1;
                    _isCarbonFibreHood = eBoolean.True;
                    goto LABEL_SKIRT;
                }

                if (a4 != a2) continue;
                _hoodStyle = x1;
                _isAutoSculptHood = eBoolean.True;
                _isCarbonFibreHood = eBoolean.True;
                goto LABEL_SKIRT;
            }

            // escape from a really big hood loop
            LABEL_SKIRT:
            // Try to match _SKIRT
            a2 = *(uint*) (bytePtrT + 0x19C);
            if (a2 == 0)
            {
                _autoSculptSkirt = -1;
                goto LABEL_RIM;
            }

            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._SKIRT + "_CAPPED");
            if (a1 == a2)
            {
                _autoSculptSkirt = -2;
                goto LABEL_RIM;
            }

            for (a3 = 0; a3 < 15; ++a3) // basically 14 styles max
            {
                a1 = Bin.Hash(model + addOn._K10 + a3.ToString("00") + parts._SKIRT);
                if (a1 != a2) continue;
                _autoSculptSkirt = (sbyte) a3;
                goto LABEL_RIM;
            }

            LABEL_RIM:
            a2 = *(uint*) (bytePtrT + 0x1B0);
            a1 = Bin.Hash(model + parts._WHEEL);
            if (a2 == 0)
            {
                _rimBrand = BaseArguments.NULL;
                goto LABEL_PRECOMPVINYL;
            }

            if (a1 == a2)
            {
                _rimBrand = BaseArguments.STOCK;
                goto LABEL_PRECOMPVINYL;
            }

            for (byte x1 = 1; x1 < 11; ++x1) // try autosculpt wheels
            {
                a1 = Bin.Hash(Map.RimBrands[0] + addOn._STYLE + x1.ToString("00") + "_17" + addOn._25);
                if (a1 != a2) continue;
                _rimBrand = Map.RimBrands[0];
                _rimStyle = x1;
                _rimSize = 17;
                goto LABEL_PRECOMPVINYL;
            }

            for (byte x1 = 1; x1 < Map.RimBrands.Count; ++x1) // else try match aftermarket wheels
            {
                for (byte x2 = 1; x2 < 7; ++x2) // 3 loops: max manufacturers, 6 styles, 5 sizes
                {
                    for (byte x3 = 17; x3 < 22; ++x3)
                    {
                        a1 = Bin.Hash(Map.RimBrands[x1] + addOn._STYLE + addOn._0 + x2 + "_" + x3 + addOn._25);
                        if (a1 != a2) continue;
                        _rimBrand = Map.RimBrands[x1];
                        _rimStyle = x2;
                        _rimSize = x3;
                        goto LABEL_PRECOMPVINYL;
                    }
                }
            }

            LABEL_PRECOMPVINYL:
            a2 = *(uint*) (bytePtrT + 0x1D4);
            _specificVinyl = Map.Lookup(a2, true) ?? $"{hex}{a2:X8}";
            a2 = *(uint*) (bytePtrT + 0x1D8);
            _genericVinyl = Map.Lookup(a2, true) ?? $"{hex}{a2:X8}";

            // _WINDOW_TINT
            a2 = *(uint*) (bytePtrT + 0x1F8);
            a1 = Bin.Hash(parts.WINDOW_TINT_STOCK);
            if (a2 == 0 || a1 == a2)
                _windowTintType = BaseArguments.STOCK;
            else
            {
                var v2 = Map.Lookup(a2, false); // main for system strings
                _windowTintType = Map.WindowTintMap.Contains(v2) ? v2 : BaseArguments.STOCK;
            }

            // COLOR TYPE
            a2 = *(uint*) (bytePtrT + 0x20C);
            if (Enum.IsDefined(typeof(eCarbonPaint), a2))
                _paintType = (eCarbonPaint) a2;
            else
                _paintType = eCarbonPaint.GLOSS;

            // Paint Swatch
            _paintSwatch = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x210), false));

            // Saturation and Brightness
            _saturation = *(float*) (bytePtrT + 0x214);
            _brightness = *(float*) (bytePtrT + 0x218);

            // Front Bumper Autosculpt
            FRONTBUMPER.AutosculptZone1 = *(bytePtrT + 0x22C);
            FRONTBUMPER.AutosculptZone2 = *(bytePtrT + 0x22D);
            FRONTBUMPER.AutosculptZone3 = *(bytePtrT + 0x22E);
            FRONTBUMPER.AutosculptZone4 = *(bytePtrT + 0x22F);
            FRONTBUMPER.AutosculptZone5 = *(bytePtrT + 0x230);
            FRONTBUMPER.AutosculptZone6 = *(bytePtrT + 0x231);
            FRONTBUMPER.AutosculptZone7 = *(bytePtrT + 0x232);
            FRONTBUMPER.AutosculptZone8 = *(bytePtrT + 0x233);
            FRONTBUMPER.AutosculptZone9 = *(bytePtrT + 0x234);

            // Rear Bumper Autosculpt
            REARBUMPER.AutosculptZone1 = *(bytePtrT + 0x237);
            REARBUMPER.AutosculptZone2 = *(bytePtrT + 0x238);
            REARBUMPER.AutosculptZone3 = *(bytePtrT + 0x239);
            REARBUMPER.AutosculptZone4 = *(bytePtrT + 0x23A);
            REARBUMPER.AutosculptZone5 = *(bytePtrT + 0x23B);
            REARBUMPER.AutosculptZone6 = *(bytePtrT + 0x23C);
            REARBUMPER.AutosculptZone7 = *(bytePtrT + 0x23D);
            REARBUMPER.AutosculptZone8 = *(bytePtrT + 0x23E);
            REARBUMPER.AutosculptZone9 = *(bytePtrT + 0x23F);

            // Skirt Autosculpt
            SKIRT.AutosculptZone1 = *(bytePtrT + 0x242);
            SKIRT.AutosculptZone2 = *(bytePtrT + 0x243);
            SKIRT.AutosculptZone3 = *(bytePtrT + 0x244);
            SKIRT.AutosculptZone4 = *(bytePtrT + 0x245);
            SKIRT.AutosculptZone5 = *(bytePtrT + 0x246);
            SKIRT.AutosculptZone6 = *(bytePtrT + 0x247);
            SKIRT.AutosculptZone7 = *(bytePtrT + 0x248);
            SKIRT.AutosculptZone8 = *(bytePtrT + 0x249);
            SKIRT.AutosculptZone9 = *(bytePtrT + 0x24A);

            // Wheels Autosculpt
            WHEELS.AutosculptZone1 = *(bytePtrT + 0x24D);
            WHEELS.AutosculptZone2 = *(bytePtrT + 0x24E);
            WHEELS.AutosculptZone3 = *(bytePtrT + 0x24F);
            WHEELS.AutosculptZone4 = *(bytePtrT + 0x250);
            WHEELS.AutosculptZone5 = *(bytePtrT + 0x251);
            WHEELS.AutosculptZone6 = *(bytePtrT + 0x252);
            WHEELS.AutosculptZone7 = *(bytePtrT + 0x253);
            WHEELS.AutosculptZone8 = *(bytePtrT + 0x254);
            WHEELS.AutosculptZone9 = *(bytePtrT + 0x255);

            // Hood Bumper Autosculpt
            HOOD.AutosculptZone1 = *(bytePtrT + 0x258);
            HOOD.AutosculptZone2 = *(bytePtrT + 0x259);
            HOOD.AutosculptZone3 = *(bytePtrT + 0x25A);
            HOOD.AutosculptZone4 = *(bytePtrT + 0x25B);
            HOOD.AutosculptZone5 = *(bytePtrT + 0x25C);
            HOOD.AutosculptZone6 = *(bytePtrT + 0x25D);
            HOOD.AutosculptZone7 = *(bytePtrT + 0x25E);
            HOOD.AutosculptZone8 = *(bytePtrT + 0x25F);
            HOOD.AutosculptZone9 = *(bytePtrT + 0x260);

            // Spoiler Autosculpt
            SPOILER.AutosculptZone1 = *(bytePtrT + 0x263);
            SPOILER.AutosculptZone2 = *(bytePtrT + 0x264);
            SPOILER.AutosculptZone3 = *(bytePtrT + 0x265);
            SPOILER.AutosculptZone4 = *(bytePtrT + 0x266);
            SPOILER.AutosculptZone5 = *(bytePtrT + 0x267);
            SPOILER.AutosculptZone6 = *(bytePtrT + 0x268);
            SPOILER.AutosculptZone7 = *(bytePtrT + 0x269);
            SPOILER.AutosculptZone8 = *(bytePtrT + 0x26A);
            SPOILER.AutosculptZone9 = *(bytePtrT + 0x26B);

            // RoofScoop Autosculpt
            ROOFSCOOP.AutosculptZone1 = *(bytePtrT + 0x26E);
            ROOFSCOOP.AutosculptZone2 = *(bytePtrT + 0x26F);
            ROOFSCOOP.AutosculptZone3 = *(bytePtrT + 0x270);
            ROOFSCOOP.AutosculptZone4 = *(bytePtrT + 0x271);
            ROOFSCOOP.AutosculptZone5 = *(bytePtrT + 0x272);
            ROOFSCOOP.AutosculptZone6 = *(bytePtrT + 0x273);
            ROOFSCOOP.AutosculptZone7 = *(bytePtrT + 0x274);
            ROOFSCOOP.AutosculptZone8 = *(bytePtrT + 0x275);
            ROOFSCOOP.AutosculptZone9 = *(bytePtrT + 0x276);

            // Chop top and Exhaust Autosculpt
            ChopTopSize = *(bytePtrT + 0x279);
            ExhaustSize = *(bytePtrT + 0x284);

            // 20 vinyls
            VINYL01.Read(bytePtrT + 0x290 + 0x2C * 0);
            VINYL02.Read(bytePtrT + 0x290 + 0x2C * 1);
            VINYL03.Read(bytePtrT + 0x290 + 0x2C * 2);
            VINYL04.Read(bytePtrT + 0x290 + 0x2C * 3);
            VINYL05.Read(bytePtrT + 0x290 + 0x2C * 4);
            VINYL06.Read(bytePtrT + 0x290 + 0x2C * 5);
            VINYL07.Read(bytePtrT + 0x290 + 0x2C * 6);
            VINYL08.Read(bytePtrT + 0x290 + 0x2C * 7);
            VINYL09.Read(bytePtrT + 0x290 + 0x2C * 8);
            VINYL10.Read(bytePtrT + 0x290 + 0x2C * 9);
            VINYL11.Read(bytePtrT + 0x290 + 0x2C * 10);
            VINYL12.Read(bytePtrT + 0x290 + 0x2C * 11);
            VINYL13.Read(bytePtrT + 0x290 + 0x2C * 12);
            VINYL14.Read(bytePtrT + 0x290 + 0x2C * 13);
            VINYL15.Read(bytePtrT + 0x290 + 0x2C * 14);
            VINYL16.Read(bytePtrT + 0x290 + 0x2C * 15);
            VINYL17.Read(bytePtrT + 0x290 + 0x2C * 16);
            VINYL18.Read(bytePtrT + 0x290 + 0x2C * 17);
            VINYL19.Read(bytePtrT + 0x290 + 0x2C * 18);
            VINYL20.Read(bytePtrT + 0x290 + 0x2C * 19);
        }
    }
}