using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		private eSponsorRaceType _sponsorRace1 = eSponsorRaceType.Circuit;
		private eSponsorRaceType _sponsorRace2 = eSponsorRaceType.Circuit;
		private eSponsorRaceType _sponsorRace3 = eSponsorRaceType.Circuit;

		[AccessModifiable]
		[StaticModifiable]
		public eSponsorRaceType ReqSponsorRace1
		{
			get => _sponsorRace1;
			set
			{
				if (Enum.IsDefined(typeof(eSponsorRaceType), value))
					_sponsorRace1 = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public eSponsorRaceType ReqSponsorRace2
		{
			get => _sponsorRace2;
			set
			{
				if (Enum.IsDefined(typeof(eSponsorRaceType), value))
					_sponsorRace2 = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public eSponsorRaceType ReqSponsorRace3
		{
			get => _sponsorRace3;
			set
			{
				if (Enum.IsDefined(typeof(eSponsorRaceType), value))
					_sponsorRace3 = value;
				else
					throw new MappingFailException();
			}
		}
	}
}