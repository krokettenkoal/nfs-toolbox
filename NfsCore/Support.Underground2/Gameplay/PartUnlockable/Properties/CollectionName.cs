using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
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
				throw new NotSupportedException("CollectionName of PartUnlockables cannot be changed.");
			}
		}

		public uint BinKey { get => Bin.Hash(this._collection_name); }

		public uint VltKey { get => Vlt.Hash(this._collection_name); }
	}
}