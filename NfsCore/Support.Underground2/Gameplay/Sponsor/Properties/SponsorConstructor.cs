﻿using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class Sponsor : Collectable
	{
		// Default constructor
		public Sponsor() { }

		// Default constructor: create new sponsor
		public Sponsor(string CName, Database.Underground2Db db)
		{
			this.Database = db;
			this.CollectionName = CName;
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble sponsor
		public unsafe Sponsor(byte* ptr_header, byte* ptr_string, Database.Underground2Db db)
		{
			this.Database = db;
			this.Disassemble(ptr_header, ptr_string);
		}

		~Sponsor() { }
	}
}