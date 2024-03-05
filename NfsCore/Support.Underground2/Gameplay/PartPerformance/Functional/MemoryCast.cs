using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		public override Collectable MemoryCast(string collectionName)
		{
			var result = new PartPerformance(collectionName, Database)
			{
				_partPerfType = _partPerfType,
				_perfBrand1 = _perfBrand1,
				_perfBrand2 = _perfBrand2,
				_perfBrand3 = _perfBrand3,
				_perfBrand4 = _perfBrand4,
				_perfBrand5 = _perfBrand5,
				_perfBrand6 = _perfBrand6,
				_perfBrand7 = _perfBrand7,
				_perfBrand8 = _perfBrand8,
				BeingReplacedByIndex1 = BeingReplacedByIndex1,
				BeingReplacedByIndex2 = BeingReplacedByIndex2,
				NumberOfBrands = NumberOfBrands,
				PerfPartAmplifierFraction = PerfPartAmplifierFraction,
				PerfPartCost = PerfPartCost,
				PerfPartRangeX = PerfPartRangeX,
				PerfPartRangeY = PerfPartRangeY,
				PerfPartRangeZ = PerfPartRangeZ
			};
			return result;
		}
	}
}