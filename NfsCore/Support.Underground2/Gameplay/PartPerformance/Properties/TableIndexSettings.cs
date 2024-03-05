using System;
using System.Linq;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private ePerformanceType _partPerfType = ePerformanceType.NOS;
		private int _upgradeLevel;
		private int _upgradePartIndex;
		private int _partIndex;
		private readonly bool _cnameIsSet = false;

		[AccessModifiable]
		public ePerformanceType PartPerformanceType
		{
			get => _partPerfType;
			set
			{
				if (!Enum.IsDefined(typeof(ePerformanceType), value))
					throw new MappingFailException();
				if (CheckIfTypeCanBeSwitched(value))
					SwitchPerfType(value);
				else
					throw new Exception("Unable to set: no available perf part slots in this group exist.");
			}
		}

		[AccessModifiable]
		public int UpgradeLevel
		{
			get => _upgradeLevel + 1;
			set
			{
				--value;
				if (CheckIfLevelCanBeSwitched(value))
					SwitchUpgradeLevel(value);
				else
					throw new Exception("Unable to set: no available perf part slots in this level exist.");
			}
		}

		[AccessModifiable]
		public int UpgradePartIndex
		{
			get => _upgradePartIndex;
			set
			{
				if (CheckIfIndexCanBeSwitched(value))
					SwitchUpgradePartIndex(value);
				else
					throw new Exception("Unable to set: the perf slot is already taken by a different part.");
			}
		}

		[AccessModifiable]
		public int PartIndex
		{
			get => _partIndex;
			set
			{
				if (Database.PartPerformances.Collections.Any(cla => cla.PartIndex == value))
				{
					throw new Exception("Performance Part with the same PartIndex already exists.");
				}

				_partIndex = value;
			}
		}
	}
}