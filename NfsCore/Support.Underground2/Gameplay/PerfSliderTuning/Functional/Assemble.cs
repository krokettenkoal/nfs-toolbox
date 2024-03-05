using NfsCore.Utils.EA;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PerfSliderTuning
    {
        public unsafe void Assemble(byte* bytePtrT)
        {
            // Since CollectionName is of type 0x{1}{2}{3}{4}, use SAT GetColors functions
            int i1 = SAT.GetAlpha(CollName);
            var i2 = SAT.GetRed(CollName);
            var i3 = SAT.GetGreen(CollName);
            var i4 = SAT.GetBlue(CollName);
            *(int*) bytePtrT = i1;
            *(bytePtrT + 0x04) = i2;
            *(bytePtrT + 0x05) = i3;
            *(bytePtrT + 0x06) = i4;
            *(float*) (bytePtrT + 0x08) = MinSliderValueRatio;
            *(float*) (bytePtrT + 0x0C) = MaxSliderValueRatio;
            *(float*) (bytePtrT + 0x10) = ValueSpread1;
            *(float*) (bytePtrT + 0x14) = ValueSpread2;
        }
    }
}