using GlobalLib.Core;
using GlobalLib.Utils;

namespace GlobalLib.Support.Carbon
{
	public static partial class LoadData
	{
		private static unsafe void E_VaultKeys(byte* byteptr_t)
		{
			var ID = *(uint*)byteptr_t;
			var size = *(int*)(byteptr_t + 4) + 8;
			if (ID != 0x53747245) return;

			var offset = 8;
			while (offset < size)
			{
				var CName = ScriptX.NullTerminatedString(byteptr_t + offset, size - offset);
				if (CName == null) { offset += 1; continue; }
				var key = Vlt.Hash(CName);
				Map.VltKeys[key] = CName;
				offset += CName.Length + 1;
			}
		}
	}
}