using NfsCore.Global;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private static bool CheckIfTypeCanBeSwitched(ePerformanceType perfType)
		{
			var index = (int)perfType;
			for (var a1 = 0; a1 < 3; ++a1)
			{
				for (var a2 = 0; a2 < 4; ++a2)
				{
					if (Map.PerfPartTable[index, a1, a2] == 0)
						return true;
				}
			}
			return false;
		}
	}
}