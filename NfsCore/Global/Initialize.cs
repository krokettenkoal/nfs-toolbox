using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Global
{
    internal static class Initialize
    {
        public static void Init()
        {
            Map.RimBrands.Clear();
            Map.WindowTintMap.Clear();
            Map.CollisionMap.Clear();
            PaintTypes();
            BodyPaints();
            Windshields();
            RimBrandArray();
            HashImportantStrings();
        }

        public static void InitUg2()
        {
            Map.RimBrands.Clear();
            Map.AudioTypes.Clear();
            Map.WindowTintMap.Clear();
            Map.CollisionMap.Clear();
            Map.UG2PaintTypes.Clear();
            Map.UG2CaliperPaints.Clear();
            Map.UG2RimPaints.Clear();
            Map.UG2VinylPaints.Clear();
            Ug2PaintTypes();
            Ug2CaliperPaints();
            Ug2RimPaints();
            Ug2VinylPaints();
            Ug2BankTriggers();
            Windshields();
            HashImportantStrings();
            Map.PerfPartTable = new uint[10, 3, 4];
        }

        /// <summary>
        /// Initializes all paint type strings into raider memory map.
        /// </summary>
        private static void PaintTypes()
        {
            // Paint types
            const string gloss = "GLOSS";
            const string metal = "METAL";
            const string pearl = "PEARL";
            const string matte = "MATTE";
            const string chrome = "CHROME";

            // Extra strings
            const string color = "_L1_COLOR";

            // Main strings
            string paint1;

            // GLOSS/METAL + _L1_COLOR + 00-80
            for (var a1 = 0; a1 < 81; ++a1)
            {
                var a1Padding = a1.ToString("D2");

                paint1 = $"{gloss}{color}{a1Padding}";
                Map.BinKeys[Bin.Hash(paint1)] = paint1;

                paint1 = $"{metal}{color}{a1Padding}";
                Map.BinKeys[Bin.Hash(paint1)] = paint1;

                if (a1 >= 21) continue;
                paint1 = $"{pearl}{a1Padding}";
                Map.BinKeys[Bin.Hash(paint1)] = paint1;

                if (a1 >= 11) continue;
                paint1 = $"{matte}{a1Padding}";
                Map.BinKeys[Bin.Hash(paint1)] = paint1;

                paint1 = $"{chrome}{a1Padding}";
                Map.BinKeys[Bin.Hash(paint1)] = paint1;
            }

            // Cop and Traffic paint types
            paint1 = "COP_L1_COLOR01";
            const string paint2 = "TRAFFIC_L1_COLOR01";
            Map.BinKeys[Bin.Hash(paint1)] = paint1;
            Map.BinKeys[Bin.Hash(paint2)] = paint2;
        }

        /// <summary>
        /// Initializes medium and light windshields for UG2 and MW
        /// </summary>
        private static void Windshields()
        {
            Map.WindowTintMap.AddRange(new[]
            {
                "WINDSHIELD_TINT_L1_BLACK",
                "WINDSHIELD_TINT_L1_GREEN",
                "WINDSHIELD_TINT_L1_BLUE",
                "WINDSHIELD_TINT_L1_RED",
                "WINDSHIELD_TINT_L1_MED_BLACK",
                "WINDSHIELD_TINT_L1_MED_GREEN",
            });

            foreach (var wtm in Map.WindowTintMap)
                Bin.Hash(wtm);
        }

        /// <summary>
        /// Initializes all body paint types into raider memory map.
        /// </summary>
        private static void BodyPaints()
        {
            var paints = Enum.GetNames(typeof(eCarbonPaint));
            foreach (var paint in paints)
                Bin.Hash(paint);
        }

        /// <summary>
        /// Initializes all rim brands into rim brand memory array.
        /// </summary>
        private static void RimBrandArray()
        {
            Map.RimBrands.AddRange(new[]
            {
                "AUTOSCLPT",
                "5ZIGEN",
                "ADR",
                "AR",
                "BBS",
                "CL",
                "ENKEI",
                "GIOVANNA",
                "HRE",
                "IFORGED",
                "KONIG",
                "LOWENHART",
                "OZ",
                "RACINGHART",
                "ROJA",
                "TENZO",
                "TSW",
                "VOLK",
                "WORK",
            });
        }

        /// <summary>
        /// Initializes all UG2 paint type strings into its paint memory map.
        /// </summary>
        private static void Ug2PaintTypes()
        {
            // Paint types
            const string gloss = "GLOSS";
            const string metal = "METAL";
            const string pearl = "PEARL";
            const string hoses = "HOSES";
            const string mufflers = "MUFFLERS";
            const string customPaint = "CUSTOMPAINT_";

            // Extra strings
            const string colorSuffix = "_COLOR";
            const string newInfix = "_NEW_";
            const string testSuffix = "_TEST";
            const string paintSuffix = "_PAINT";
            const string _1 = "1";
            const string _2 = "2";
            const string _3 = "3";
            const string lSuffix = "_L";

            for (var a1 = 1; a1 < 31; ++a1)
            {
                var a1Padding = a1.ToString("D2");

                switch (a1)
                {
                    case < 21:
                    {
                        Map.UG2PaintTypes.AddRange(new[]
                        {
                            $"{gloss}{lSuffix}{_2}{colorSuffix}{a1Padding}",
                            $"{metal}{lSuffix}{_2}{newInfix}{a1Padding}",
                            $"{metal}{lSuffix}{_3}{testSuffix}{a1Padding}",
                            $"{hoses}{lSuffix}{_2}{colorSuffix}{a1Padding}",
                            $"{mufflers}{lSuffix}{_2}{colorSuffix}{a1Padding}",
                            $"{customPaint}{a1}",
                        });

                        if (a1 < 11)
                        {
                            Map.UG2PaintTypes.AddRange(new[]
                            {
                                $"{gloss}{lSuffix}{_1}{colorSuffix}{a1Padding}",
                                $"{metal}{lSuffix}{_2}{colorSuffix}{a1Padding}",
                                $"{hoses}{lSuffix}{_1}{colorSuffix}{a1Padding}",
                                $"{mufflers}{lSuffix}{_1}{colorSuffix}{a1Padding}",
                                $"{pearl}{a1}{paintSuffix}",
                            });
                        }

                        break;
                    }
                    default:
                        Map.UG2PaintTypes.Add($"{metal}{lSuffix}{_3}{newInfix}{a1Padding}");
                        break;
                }

                Map.UG2PaintTypes.AddRange(new[]
                {
                    $"{gloss}{lSuffix}{_3}{testSuffix}{a1Padding}",
                    $"{metal}{lSuffix}{_3}{colorSuffix}{a1Padding}",
                    $"{hoses}{lSuffix}{_3}{colorSuffix}{a1Padding}",
                    $"{mufflers}{lSuffix}{_3}{colorSuffix}{a1Padding}",
                });
            }

            // Fix of one of colors
            Map.UG2PaintTypes.Remove("HOSES_L3_COLOR01");
            Map.UG2PaintTypes.Add("HOSES_L3_TEST01");

            // Hashing of all paint types
            foreach (var paint in Map.UG2PaintTypes)
                Bin.Hash(paint);
        }

        private static void Ug2CaliperPaints()
        {
            const string calipersL = "CALIPERS_L";
            const string colorSuffix = "_COLOR";

            for (var a1 = 1; a1 < 4; ++a1)
            {
                for (var a2 = 1; a2 <= 10 * a1; ++a2)
                    Map.UG2CaliperPaints.Add($"{calipersL}{a1}{colorSuffix}{a2:00}");
            }

            foreach (var paint in Map.UG2CaliperPaints)
                Bin.Hash(paint);
        }

        private static void Ug2RimPaints()
        {
            const string rimsL = "RIMS_L";
            const string colorSuffix = "_COLOR";

            for (var a1 = 1; a1 < 4; ++a1)
            {
                for (var a2 = 1; a2 <= 10 * a1; ++a2)
                    Map.UG2RimPaints.Add($"{rimsL}{a1}{colorSuffix}{a2:00}");
            }

            foreach (var paint in Map.UG2RimPaints)
                Bin.Hash(paint);
        }

        private static void Ug2VinylPaints()
        {
            const string vinylL = "VINYL_L";
            const string colorSuffix = "_COLOR";

            for (var a1 = 1; a1 < 4; ++a1)
            {
                for (var a2 = 1; a2 <= 10 * a1; ++a2)
                    Map.UG2VinylPaints.Add($"{vinylL}{a1}{colorSuffix}{a2:00}");
            }

            foreach (var paint in Map.UG2VinylPaints)
                Bin.Hash(paint);
        }

        /// <summary>
        /// Hashes most important strings used when processing data.
        /// </summary>
        private static void HashImportantStrings()
        {
            Bin.Hash(BaseArguments.RANDOM);
            Bin.Hash(BaseArguments.GLOBAL);
            Bin.Hash(BaseArguments.DEFAULT);
        }

        /// <summary>
        /// Hashes all labels for bank triggers.
        /// </summary>
        private static void Ug2BankTriggers()
        {
            for (var a1 = 0; a1 < 100; ++a1)
                Bin.Hash($"BANK_TRIGGER_{a1:00}");
        }
    }
}