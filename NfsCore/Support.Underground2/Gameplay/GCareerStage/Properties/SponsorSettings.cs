using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		private string _stageSponsor1 = BaseArguments.NULL;
		private string _stageSponsor2 = BaseArguments.NULL;
		private string _stageSponsor3 = BaseArguments.NULL;
		private string _stageSponsor4 = BaseArguments.NULL;
		private string _stageSponsor5 = BaseArguments.NULL;

		[AccessModifiable]
		public string StageSponsor1
		{
			get => _stageSponsor1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_stageSponsor1 = value;
			}
		}

		[AccessModifiable]
		public string StageSponsor2
		{
			get => _stageSponsor2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_stageSponsor2 = value;
			}
		}

		[AccessModifiable]
		public string StageSponsor3
		{
			get => _stageSponsor3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_stageSponsor3 = value;
			}
		}

		[AccessModifiable]
		public string StageSponsor4
		{
			get => _stageSponsor4;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_stageSponsor4 = value;
			}
		}

		[AccessModifiable]
		public string StageSponsor5
		{
			get => _stageSponsor5;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_stageSponsor5 = value;
			}
		}
	}
}