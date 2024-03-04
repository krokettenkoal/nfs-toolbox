﻿using System.IO;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2
{
	public static partial class SaveData
	{
		private static void I_CarSkins(Database.Underground2Db db, BinaryWriter bw)
		{
			bw.Write(GlobalId.CarSkins);
			bw.Write(-1);
			var pos = bw.BaseStream.Position;
			int a1 = 0;
			foreach (var car in db.CarTypeInfos.Collections)
			{
				var arr = car.GetCarSkins(a1++);
				if (arr != null) bw.Write(arr);
			}
			bw.BaseStream.Position = pos - 4;
			bw.Write((int)(bw.BaseStream.Length - pos));
			bw.BaseStream.Position = bw.BaseStream.Length;
		}
	}
}