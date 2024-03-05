using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private bool CheckIfIndexCanBeSwitched(int value)
		{
			var index = (int)_partPerfType;
			return Map.PerfPartTable[index, _upgradeLevel, value] == 0;
		}
	}
}