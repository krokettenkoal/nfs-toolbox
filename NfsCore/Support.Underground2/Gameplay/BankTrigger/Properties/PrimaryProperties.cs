using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class BankTrigger
	{
		private eBoolean _initially_unlocked = eBoolean.False;

		[AccessModifiable]
		[StaticModifiable]
		public ushort CashValue { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public eBoolean InitiallyUnlocked
		{
			get => _initially_unlocked;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					_initially_unlocked = value;
				else
					throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
			}
		}

		[AccessModifiable]
		public byte BankIndex { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public int RequiredStagesCompleted { get; set; }
	}
}