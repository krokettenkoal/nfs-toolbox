﻿namespace NfsCore.Support.Underground2
{
	public static partial class SaveData
	{
		private static byte[] CPI_Part1(Database.Underground2Db db)
		{
			return db.SlotTypes.Part1.Data;
		}
	}
}