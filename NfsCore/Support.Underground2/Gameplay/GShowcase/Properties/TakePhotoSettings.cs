using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		private eTakePhotoMethod _takePhoto = eTakePhotoMethod.MAGAZINE_YOURSELF;

		[AccessModifiable]
		[StaticModifiable]
		public eTakePhotoMethod TakePhotoMethod
		{
			get => _takePhoto;
			set
			{
				if (Enum.IsDefined(typeof(eTakePhotoMethod), value))
					_takePhoto = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable]
		[StaticModifiable]
		public byte BelongsToStage { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public short CashValue { get; set; }

		[AccessModifiable]
		[StaticModifiable]
		public float RequiredVisualRating { get; set; }
	}
}