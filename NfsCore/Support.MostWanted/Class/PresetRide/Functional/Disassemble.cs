using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Shared.Parts.PresetParts;
using NfsCore.Utils;
using NfsCore.Utils.EA;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            // Copy array into the memory
            for (var x = 0; x < 0x290; ++x)
                _data[x] = *(bytePtrT + x);

            var model = ""; // for Model of the car
            const string hex = "0x"; // for hex representations
            string v3; // extra for strings
            var v4 = ""; // extra for strings
            uint a3 = 0; // extra for hashes, loops

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
                goto LABEL_SPOILER;
            }

            a1 = Bin.Hash(model + parts._BASE_KIT);
            if (a1 != a2)
                // (MODEL)_BODY_KIT(00-05)
            {
                for (var x1 = 0; x1 < 6; ++x1) // 5 bodykits max
                {
                    a1 = Bin.Hash(model + parts._BASE_KIT + addOn._KIT + x1);
                    if (a1 != a2) continue;
                    _aftermarketBodyKit = (sbyte) x1;
                    goto LABEL_SPOILER;
                }
            }
            else
            {
                _aftermarketBodyKit = -1;
            }

            LABEL_SPOILER:
            // Try match spoiler
            // (MODEL)_SPOILER[SPOILER_STYLE(01 - 44)(TYPE)(_CF)]
            a2 = *(uint*) (bytePtrT + 0x110);
            if (a2 == 0)
            {
                _spoilerStyle = 0;
                _spoilerType = eSTypes.NULL; // means spoiler is nulled
                goto LABEL_ROOF;
            }

            a1 = Bin.Hash(model + parts._SPOILER);
            if (a1 == a2) // stock spoiler
            {
                _spoilerStyle = 0;
                _spoilerType = eSTypes.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 4; ++x1) // all 4 spoiler types
                {
                    for (byte x2 = 1; x2 < 45; ++x2) // all 44 spoiler styles
                    {
                        v3 = addOn.SPOILER + addOn._STYLE + x2.ToString("00") + addOn._CSTYPE[x1];
                        a3 = Bin.Hash(v3);
                        if (a3 == a2)
                        {
                            _spoilerStyle = x2;
                            v4 = addOn._CSTYPE[x1];
                            goto LABEL_ROOF; // break the whole loop
                        }

                        // try carbon fibre
                        a3 = Bin.Hash(v3 + addOn._CF);
                        if (a3 != a2) continue;
                        _spoilerStyle = x2;
                        v4 = addOn._CSTYPE[x1];
                        _isCarbonFibreSpoiler = eBoolean.True;
                        goto LABEL_ROOF; // break the whole loop
                    }
                }
            }

            // escape from a really big spoiler loop
            LABEL_ROOF:
            // fix spoiler settings first
            if (v4 == string.Empty)
                _spoilerType = eSTypes.BASE; // use BASE to make it clearer
            else
                System.Enum.TryParse(v4, out _spoilerType);

            // Try to match ROOF_STYLE
            a2 = *(uint*) (bytePtrT + 0x158);
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
                v3 = parts.ROOF_STYLE + x1Pad + addOn._OFFSET;
                v4 = parts.ROOF_STYLE + x1Pad + addOn._DUAL;
                a1 = Bin.Hash(v1);
                a3 = Bin.Hash(v3);
                var a4 = Bin.Hash(v4); // extra for hashes, loops
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
                    _isOffsetRoofScoop = eBoolean.True;
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
            a2 = *(uint*) (bytePtrT + 0x15C);
            a1 = Bin.Hash(model + addOn._KIT + addOn._0 + parts._HOOD);
            if (a2 == 0 || a1 == a2)
            {
                _hoodStyle = 0;
                goto LABEL_RIM;
            }

            for (byte x1 = 1; x1 < 33; ++x1) // 33 hood styles
            {
                v1 = model + addOn._STYLE + x1.ToString("00") + parts._HOOD;
                a1 = Bin.Hash(v1);
                if (a1 == a2)
                {
                    _hoodStyle = x1;
                    goto LABEL_RIM;
                }

                // try carbon fibre
                a1 = Bin.Hash(v1 + addOn._CF);
                if (a3 != a2) continue;
                _hoodStyle = x1;
                _isCarbonFibreHood = eBoolean.True;
                goto LABEL_RIM;
            }

            // Escape from a really big hood loop
            LABEL_RIM:
            a2 = *(uint*) (bytePtrT + 0x168);
            if (a2 == 0)
            {
                _rimBrand = BaseArguments.NULL;
                goto LABEL_PRECOMPVINYL;
            }

            a1 = Bin.Hash(model + parts._WHEEL);
            if (a1 == a2)
            {
                _rimBrand = BaseArguments.STOCK;
                goto LABEL_PRECOMPVINYL;
            }

            for (byte x1 = 1; x1 < Map.RimBrands.Count; ++x1) // else try match aftermarket wheels
            {
                for (byte x2 = 1; x2 < 7; ++x2) // 3 loops: 18 manufacturers, 6 styles, 4 sizes
                {
                    for (byte x3 = 17; x3 < 21; ++x3)
                    {
                        a1 = Bin.Hash(Map.RimBrands[x1] + addOn._STYLE + addOn._0 + x2 + "_" +
                                      x3 + addOn._25);
                        if (a1 != a2) continue;
                        _rimBrand = Map.RimBrands[x1];
                        _rimStyle = x2;
                        _rimSize = x3;
                        goto LABEL_PRECOMPVINYL;
                    }
                }
            }

            LABEL_PRECOMPVINYL:
            // Try find Body Paint
            a2 = *(uint*) (bytePtrT + 0x190);
            BodyPaint = Map.Lookup(a2, true) ?? BaseArguments.BPAINT;

            // Try find Vinyl Name
            a2 = *(uint*) (bytePtrT + 0x194);
            VinylName = Map.Lookup(a2, true) ?? (hex + a2.ToString("X8"));

            // Try find Rim Paint
            a2 = *(uint*) (bytePtrT + 0x198);
            RimPaint = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            // Try find swatches
            _vinylColor1 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x19C), false));
            _vinylColor2 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x1A0), false));
            _vinylColor3 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x1A4), false));
            _vinylColor4 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*) (bytePtrT + 0x1A8), false));

            // Read Decals
            DECALS_FRONT_WINDOW.Read(bytePtrT + 0x1AC);
            DECALS_REAR_WINDOW.Read(bytePtrT + 0x1CC);
            DECALS_LEFT_DOOR.Read(bytePtrT + 0x1EC);
            DECALS_RIGHT_DOOR.Read(bytePtrT + 0x20C);
            DECALS_LEFT_QUARTER.Read(bytePtrT + 0x22C);
            DECALS_RIGHT_QUARTER.Read(bytePtrT + 0x24C);

            // _WINDOW_TINT
            a2 = *(uint*) (bytePtrT + 0x26C);
            a1 = Bin.Hash(parts.WINDOW_TINT_STOCK);
            if (a2 == 0 || a1 == a2)
                _windowTintType = BaseArguments.STOCK;
            else
            {
                var v2 = Map.Lookup(a2, false); // main for system strings
                _windowTintType = Map.WindowTintMap.Contains(v2) ? v2 : BaseArguments.STOCK;
            }
        }
    }
}