using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		private string _reqEventCompleted1 = BaseArguments.NULL;
		private string _reqEventCompleted2 = BaseArguments.NULL;

		[AccessModifiable]
		[StaticModifiable]
		public string ReqEventCompleted1
		{
			get => _reqEventCompleted1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_reqEventCompleted1 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string ReqEventCompleted2
		{
			get => _reqEventCompleted2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_reqEventCompleted2 = value;
			}
		}
	}
}