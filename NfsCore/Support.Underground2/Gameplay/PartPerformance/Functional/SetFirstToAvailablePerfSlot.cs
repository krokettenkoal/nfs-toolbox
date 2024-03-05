using NfsCore.Global;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SetToFirstAvailablePerfSlot()
		{
			for (var a1 = 0; a1 < 10; ++a1)
			{
				for (var a2 = 0; a2 < 3; ++a2)
				{
					for (var a3 = 0; a3 < 4; ++a3)
					{
						if (Map.PerfPartTable[a1, a2, a3] != 0) continue;
						_partPerfType = (ePerformanceType)a1;
						_upgradeLevel = a2;
						_upgradePartIndex = a3;
						Map.PerfPartTable[a1, a2, a3] = BinKey;
						return;
					}
				}
			}
		}
	}
}