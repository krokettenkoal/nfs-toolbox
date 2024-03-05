using NfsCore.Global;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SwitchPerfType(ePerformanceType perfType)
		{
			// Clear slot
			ClearPartTableSlot();
			
			// Move to another
			_partPerfType = perfType;
			var index = (int)perfType;
			for (var a1 = 0; a1 < 3; ++a1)
			{
				for (var a2 = 0; a2 < 4; ++a2)
				{
					if (Map.PerfPartTable[index, a1, a2] != 0) continue;
					Map.PerfPartTable[index, a1, a2] = BinKey;
					_upgradeLevel = a1;
					_upgradePartIndex = a2;
					return;
				}
			}
		}
	}
}