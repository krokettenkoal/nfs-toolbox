using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SwitchUpgradeLevel(int level)
		{
			// Clear slot
			var index = (int)_partPerfType;
			ClearPartTableSlot();

			// Move to another
			_upgradeLevel = level;
			for (var a1 = 0; a1 < 4; ++a1)
			{
				if (Map.PerfPartTable[index, level, a1] != 0) continue;
				Map.PerfPartTable[index, level, a1] = BinKey;
				_upgradePartIndex = a1;
				return;
			}
		}
	}
}