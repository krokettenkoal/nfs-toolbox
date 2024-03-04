﻿using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class BankTrigger : Collectable
	{
		// Default constructor
		public BankTrigger() { }

		// Default constructor: create new bank trigger
		public BankTrigger(string CName, Database.Underground2Db db)
		{
			this.Database = db;
			this.CollectionName = CName;
			byte maxindex = 0;
			foreach (var bank in this.Database.BankTriggers.Collections)
				if (bank.BankIndex > maxindex) maxindex = bank.BankIndex;
			this.BankIndex = (byte)(maxindex + 1);
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble bank trigger
		public unsafe BankTrigger(byte* byteptr_t, Database.Underground2Db db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~BankTrigger() { }
	}
}