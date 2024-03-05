using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		public void ClearPartTableSlot()
		{
			var index = (int)_partPerfType;
			var level = _upgradeLevel;
			var value = _upgradePartIndex;
			if (Map.PerfPartTable[index, level, value] == BinKey)
				Map.PerfPartTable[index, level, value] = 0;
		}
	}
}