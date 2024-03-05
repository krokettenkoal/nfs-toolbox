using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private ePartUnlockReq _unlockMethodLevel1 = ePartUnlockReq.INITIALLY_UNLOCKED;
		private ePartUnlockReq _unlockMethodLevel2 = ePartUnlockReq.INITIALLY_UNLOCKED;
		private ePartUnlockReq _unlockMethodLevel3 = ePartUnlockReq.INITIALLY_UNLOCKED;

		[AccessModifiable]
		[StaticModifiable]
		public float VisualRating_Level1 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float VisualRating_Level2 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float VisualRating_Level3 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public short PartPrice_Level1 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public short PartPrice_Level2 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public short PartPrice_Level3 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public ePartUnlockReq UnlockMethod_Level1
		{
			get => _unlockMethodLevel1;
			set
			{
				if (!Enum.IsDefined(typeof(ePartUnlockReq), value))
					throw new MappingFailException();
				else
					_unlockMethodLevel1 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public ePartUnlockReq UnlockMethod_Level2
		{
			get => _unlockMethodLevel2;
			set
			{
				if (!Enum.IsDefined(typeof(ePartUnlockReq), value))
					throw new MappingFailException();
				else
					_unlockMethodLevel2 = value;
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public ePartUnlockReq UnlockMethod_Level3
		{
			get => _unlockMethodLevel3;
			set
			{
				if (!Enum.IsDefined(typeof(ePartUnlockReq), value))
					throw new MappingFailException();
				else
					_unlockMethodLevel3 = value;
			}
		}
	}
}