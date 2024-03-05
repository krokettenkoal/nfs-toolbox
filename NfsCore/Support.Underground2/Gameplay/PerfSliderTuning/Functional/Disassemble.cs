namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PerfSliderTuning
    {
        private unsafe void Disassemble(byte* bytePtrT)
        {
            int index = (byte) *(int*) bytePtrT;
            int level = *(bytePtrT + 0x04);
            int slide = *(bytePtrT + 0x05);
            int slamp = *(bytePtrT + 0x06);

            // CollectionName
            CollName = $"0x{index:X2}{level:X2}{slide:X2}{slamp:X2}";

            // Slider Settings
            MinSliderValueRatio = *(float*) (bytePtrT + 0x08);
            MaxSliderValueRatio = *(float*) (bytePtrT + 0x0C);
            ValueSpread1 = *(float*) (bytePtrT + 0x10);
            ValueSpread2 = *(float*) (bytePtrT + 0x14);
        }
    }
}