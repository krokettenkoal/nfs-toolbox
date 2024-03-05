using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartPerformance
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            // CollectionName and stuff
            _partIndex = *(int*) bytePtrT;
            var key = *(uint*) (bytePtrT + 4);
            CollName = Map.Lookup(key, true) ?? $"0x{key:X8}";
            PerfPartCost = *(int*) (bytePtrT + 8);
            NumberOfBrands = *(int*) (bytePtrT + 0xC);

            // Resolve all brands (use non-reflective for speed)
            if (NumberOfBrands < 1) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x10);
            _perfBrand1 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            if (NumberOfBrands < 2) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x14);
            _perfBrand2 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            if (NumberOfBrands < 3) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x18);
            _perfBrand3 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            if (NumberOfBrands < 4) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x1C);
            _perfBrand4 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            if (NumberOfBrands < 5) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x20);
            _perfBrand5 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            if (NumberOfBrands < 6) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x24);
            _perfBrand6 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            if (NumberOfBrands < 7) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x28);
            _perfBrand7 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            if (NumberOfBrands < 8) goto LABEL_SKIP;
            key = *(uint*) (bytePtrT + 0x2C);
            _perfBrand8 = Map.Lookup(key, true) ?? $"0x{key:X8}";

            // Do the rest of the values
            LABEL_SKIP:
            PerfPartAmplifierFraction = *(float*) (bytePtrT + 0x30);
            PerfPartRangeX = *(float*) (bytePtrT + 0x34);
            PerfPartRangeY = *(float*) (bytePtrT + 0x38);
            PerfPartRangeZ = *(float*) (bytePtrT + 0x3C);
            BeingReplacedByIndex1 = *(int*) (bytePtrT + 0x40);
            BeingReplacedByIndex2 = *(int*) (bytePtrT + 0x44);
        }
    }
}