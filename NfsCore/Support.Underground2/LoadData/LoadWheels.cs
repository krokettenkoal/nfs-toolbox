using System;
using System.IO;
using NfsCore.Global;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads Wheels files and reads its rim brand strings
        /// </summary>
        /// <param name="wheelsDir">Directory of the game.</param>
        /// <returns>True if success.</returns>
        public static bool LoadWheels(string wheelsDir)
        {
            wheelsDir += @"\CARS\WHEELS";
            if (!Directory.Exists(wheelsDir))
			{
				//Console.WriteLine(@"Directory CARS\WHEELS does not exist.");
				return false;
			}

			var files = Directory.GetFiles(wheelsDir);
			if (files.Length == 0)
			{
				//Console.WriteLine(@"Directory CARS\WHEELS is empty.");
				return false;
			}

			foreach (var file in files)
			{
				if (!Path.GetFileName(file).StartsWith("GEOMETRY_") || !Path.GetExtension(file).Equals(".BIN", StringComparison.CurrentCultureIgnoreCase))
					continue;
				try
				{
					using var br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read));
					if (br.ReadUInt32() != 0x80134000) continue; // if not a wheels file
					br.BaseStream.Position += 4; // skip size
					while (br.BaseStream.Position < br.BaseStream.Length)
					{
						var id = br.ReadUInt32();
						var size = br.ReadInt32();
						var off = (int)br.BaseStream.Position;
						if (id != 0x80134010)
						{
							br.ReadBytes(size);
							continue;
						}
						while ((int)br.BaseStream.Position < off + size)
						{
							id = br.ReadUInt32();
							size = br.ReadInt32();
							if (id == 0x00134011) break;
						}
						if (id != 0x00134011) continue;
						br.BaseStream.Position += 0xA4;
						var rim = ScriptX.NullTerminatedString(br);
						br.BaseStream.Position -= 0xB0 + rim.Length + 1;
						rim = FormatX.GetString(rim, "{X}_X");
						if (!Map.RimBrands.Contains(rim))
							Map.RimBrands.Add(rim);
						br.ReadBytes(br.ReadInt32());
					}
				}
				catch (Exception e)
				{
					while (e.InnerException != null) e = e.InnerException;
					//Console.WriteLine(e.Message);
					return false;
				}
			}
			foreach (var rim in Map.RimBrands)
				Bin.Hash(rim);
			return true;
        }
    }
}