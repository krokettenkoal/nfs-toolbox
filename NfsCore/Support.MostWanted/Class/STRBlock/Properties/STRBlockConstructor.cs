﻿namespace NfsCore.Support.MostWanted.Class
{
	public partial class STRBlock : Shared.Class.STRBlock
	{
		// Default constructor
		public STRBlock() { }

		// Default constructor: disassemble string block
		public unsafe STRBlock(byte* strptr, byte* labptr, int strlen, int lablen, Database.MostWantedDb db)
		{
			this.Database = db;
			this.Disassemble(strptr, strlen);
			this.DisperseLabels(labptr, lablen);
		}

		~STRBlock() { }
	}
}