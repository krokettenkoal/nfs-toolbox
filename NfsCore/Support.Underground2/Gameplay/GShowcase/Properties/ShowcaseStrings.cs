using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		private string _descStringLabel = BaseArguments.NULL;
		private string _destinationPoint = BaseArguments.NULL;
		private string _descAttrib = BaseArguments.NULL;

		[AccessModifiable]
		public string DescStringLabel
		{
			get => _descStringLabel;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_descStringLabel = value;
			}
		}

		[AccessModifiable]
		public string DestinationPoint
		{
			get => _destinationPoint;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_destinationPoint = value;
			}
		}

		[AccessModifiable]
		public string DescAttrib
		{
			get => _descAttrib;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_descAttrib = value;
			}
		}

		[AccessModifiable]
		public byte Unknown0x34 { get; set; }
		
		[AccessModifiable]
		public byte Unknown0x35 { get; set; }
	}
}