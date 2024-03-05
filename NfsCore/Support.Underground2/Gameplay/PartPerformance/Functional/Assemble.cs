using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartPerformance
    {
        public unsafe void Assemble(byte* bytePtrT)
        {
            *(int*) bytePtrT = _partIndex;
            *(uint*) (bytePtrT + 0x04) = BinKey;
            *(int*) (bytePtrT + 0x08) = PerfPartCost;
            *(int*) (bytePtrT + 0x0C) = NumberOfBrands;

            const uint negative = 0xFFFFFFFF;
            var perfKey1 = Bin.SmartHash(_perfBrand1);
            var perfKey2 = Bin.SmartHash(_perfBrand2);
            var perfKey3 = Bin.SmartHash(_perfBrand3);
            var perfKey4 = Bin.SmartHash(_perfBrand4);
            var perfKey5 = Bin.SmartHash(_perfBrand5);
            var perfKey6 = Bin.SmartHash(_perfBrand6);
            var perfKey7 = Bin.SmartHash(_perfBrand7);
            var perfKey8 = Bin.SmartHash(_perfBrand8);

            *(uint*) (bytePtrT + 0x10) = perfKey1 == 0 ? negative : perfKey1;
            *(uint*) (bytePtrT + 0x14) = perfKey2 == 0 ? negative : perfKey2;
            *(uint*) (bytePtrT + 0x18) = perfKey3 == 0 ? negative : perfKey3;
            *(uint*) (bytePtrT + 0x1C) = perfKey4 == 0 ? negative : perfKey4;
            *(uint*) (bytePtrT + 0x20) = perfKey5 == 0 ? negative : perfKey5;
            *(uint*) (bytePtrT + 0x24) = perfKey6 == 0 ? negative : perfKey6;
            *(uint*) (bytePtrT + 0x28) = perfKey7 == 0 ? negative : perfKey7;
            *(uint*) (bytePtrT + 0x2C) = perfKey8 == 0 ? negative : perfKey8;

            *(float*) (bytePtrT + 0x30) = PerfPartAmplifierFraction;
            *(float*) (bytePtrT + 0x34) = PerfPartRangeX;
            *(float*) (bytePtrT + 0x38) = PerfPartRangeY;
            *(float*) (bytePtrT + 0x3C) = PerfPartRangeZ;

            *(int*) (bytePtrT + 0x40) = BeingReplacedByIndex1;
            *(int*) (bytePtrT + 0x44) = BeingReplacedByIndex2;
            *(int*) (bytePtrT + 0x48) = -1;
            *(int*) (bytePtrT + 0x4C) = -1;
            *(int*) (bytePtrT + 0x50) = -1;
            *(int*) (bytePtrT + 0x54) = -1;
            *(int*) (bytePtrT + 0x58) = -1;
        }
    }
}