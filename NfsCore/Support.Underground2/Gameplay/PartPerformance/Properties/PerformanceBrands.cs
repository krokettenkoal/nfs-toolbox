using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private string _perfBrand1 = BaseArguments.NULL;
		private string _perfBrand2 = BaseArguments.NULL;
		private string _perfBrand3 = BaseArguments.NULL;
		private string _perfBrand4 = BaseArguments.NULL;
		private string _perfBrand5 = BaseArguments.NULL;
		private string _perfBrand6 = BaseArguments.NULL;
		private string _perfBrand7 = BaseArguments.NULL;
		private string _perfBrand8 = BaseArguments.NULL;

		[AccessModifiable]
		[StaticModifiable]
		public int NumberOfBrands { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand1
		{
			get => _perfBrand1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand1 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand2
		{
			get => _perfBrand2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand2 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand3
		{
			get => _perfBrand3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand3 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand4
		{
			get => _perfBrand4;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand4 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand5
		{
			get => _perfBrand5;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand5 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand6
		{
			get => _perfBrand6;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand6 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand7
		{
			get => _perfBrand7;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand7 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public string PerfPartBrand8
		{
			get => _perfBrand8;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_perfBrand8 = value;
			}
		}
	}
}