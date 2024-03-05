using NfsCore.Global;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private bool CheckIfLevelCanBeSwitched(int level)
		{
			var index = (int)_partPerfType;
			for (var a1 = 0; a1 < 4; ++a1)
			{
				if (Map.PerfPartTable[index, level, a1] == 0)
					return true;
			}
			return false;
		}
	}
}