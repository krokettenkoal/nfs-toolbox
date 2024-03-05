using System.Linq;
using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PerfSliderTuning
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new PerfSliderTuning(collectionName, Database);
            uint maxKey = 0;
            foreach (var slider in Database.PerfSliderTunings.Collections.Where(slider => slider.BinKey > maxKey))
                maxKey = slider.BinKey;
            result.CollName = (maxKey + 1).ToString();
            result.MaxSliderValueRatio = MaxSliderValueRatio;
            result.MinSliderValueRatio = MinSliderValueRatio;
            result.ValueSpread1 = ValueSpread1;
            result.ValueSpread2 = ValueSpread2;
            return result;
        }
    }
}