using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SwitchUpgradePartIndex(int value)
		{
			// Clear slot
			var index = (int)_partPerfType;
			var level = _upgradeLevel;
			ClearPartTableSlot();

			// Move to another
			_upgradePartIndex = value;
			Map.PerfPartTable[index, level, value] = BinKey;
		}
	}
}