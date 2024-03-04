using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		// CollectionName here is an 8-digit hexadecimal containing 4 first major indexes of the slider.
		private string _collection_name;

		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		[AccessModifiable()]
		public override string CollectionName
		{
			get => this._collection_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left left empty.");
				if (value.Contains(" "))
					throw new Exception("CollectionName cannot contain whitespace.");
				if (!Validate.PerfSliderCollectionName(value))
					throw new Exception("Unable to parse value provided as a hexadecimal containing tuning settings.");
				if (this.Database.PerfSliderTunings.FindCollection(value) != null)
					throw new CollectionExistenceException();
				this._collection_name = value;
			}
		}

		public uint BinKey { get => ConvertX.ToUInt32(this._collection_name); }

		public uint VltKey { get => Vlt.Hash(this._collection_name); }
	}
}