using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private eBoolean _inReverseStage1 = eBoolean.False;
		private eBoolean _inReverseStage2 = eBoolean.False;
		private eBoolean _inReverseStage3 = eBoolean.False;
		private eBoolean _inReverseStage4 = eBoolean.False;

		[AccessModifiable]
		[StaticModifiable]
		public ushort TrackID_Stage1 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public ushort TrackID_Stage2 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public ushort TrackID_Stage3 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public ushort TrackID_Stage4 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte NumLaps_Stage1 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte NumLaps_Stage2 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte NumLaps_Stage3 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public byte NumLaps_Stage4 { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public eBoolean InReverseDirection_Stage1
		{
			get => _inReverseStage1;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					_inReverseStage1 = value;
				else
					throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public eBoolean InReverseDirection_Stage2
		{
			get => _inReverseStage2;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					_inReverseStage2 = value;
				else
					throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public eBoolean InReverseDirection_Stage3
		{
			get => _inReverseStage3;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					_inReverseStage3 = value;
				else
					throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public eBoolean InReverseDirection_Stage4
		{
			get => _inReverseStage4;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					_inReverseStage4 = value;
				else
					throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
			}
		}
	}
}