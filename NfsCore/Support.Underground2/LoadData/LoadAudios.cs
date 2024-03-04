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
        /// <param name="audiosDir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static bool LoadAudios(string audiosDir)
        {
            audiosDir += @"\CARS\AUDIO\GEOMETRY.BIN";
            if (!File.Exists(audiosDir))
			{
				//Console.WriteLine(@"File CARS\AUDIO\GEOMETRY.BIN does not exist.");
				return false;
			}

			try
			{
				using var br = new BinaryReader(File.Open(audiosDir, FileMode.Open, FileAccess.Read));
				if (br.ReadUInt32() != 0x80134000)
					throw new FileLoadException(@"File CARS\AUDIO\GEOMETRY.BIN is an invalid geometry file");
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
					var audio = ScriptX.NullTerminatedString(br);
					br.BaseStream.Position -= 0xB0 + audio.Length + 1;
					audio = audio[..audio.LastIndexOf('_')]; // throw away _A and _PAIN
					Bin.Hash(audio); // put in the map
					if (!Map.AudioTypes.Contains(audio))
						Map.AudioTypes.Add(audio);
					br.ReadBytes(br.ReadInt32());
				}
			}
			catch (Exception e)
			{
				while (e.InnerException != null) e = e.InnerException;
				//Console.WriteLine(e.Message);
				return false;
			}

			for (var a1 = 0; a1 < Map.AudioTypes.Count; ++a1)
			{
				var audio = Map.AudioTypes[a1];
				if (audio.StartsWith("AUDIO_COMP_SPEAKER"))
					Map.AudioTypes[a1] = $"{audio[..18]}_{audio.Substring(18, audio.Length - 18)}";
			}
			return true;
        }
    }
}