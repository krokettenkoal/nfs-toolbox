using System;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class Track : Collectable
	{
		// Default constructor
		public Track() { }

		// Default constructor: create new track
		public Track(string CName, Database.Underground2Db db)
		{
			this.Database = db;
			this.CollectionName = CName;
			this.RegionName = "L4RA";
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble track
		public unsafe Track(IntPtr byteptr_t, string CName, Database.Underground2Db db)
		{
			this.Database = db;
			this._collection_name = CName;
			this.Disassemble((byte*)byteptr_t);
		}

		~Track() { }
	}
}