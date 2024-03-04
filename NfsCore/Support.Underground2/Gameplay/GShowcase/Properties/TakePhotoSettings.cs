using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		private eTakePhotoMethod _take_photo = eTakePhotoMethod.MAGAZINE_YOURSELF;

		[AccessModifiable()]
		[StaticModifiable()]
		public eTakePhotoMethod TakePhotoMethod
		{
			get => this._take_photo;
			set
			{
				if (Enum.IsDefined(typeof(eTakePhotoMethod), value))
					this._take_photo = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public byte BelongsToStage { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public short CashValue { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public float RequiredVisualRating { get; set; }
	}
}