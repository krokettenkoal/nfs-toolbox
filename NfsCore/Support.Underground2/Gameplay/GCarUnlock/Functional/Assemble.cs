using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		public unsafe void Assemble(byte* bytePtrT)
		{
			*(uint*)bytePtrT = Bin.SmartHash(CollectionName);
			*(uint*)(bytePtrT + 4) = Bin.SmartHash(_reqEventCompleted1);
			*(uint*)(bytePtrT + 8) = Bin.SmartHash(_reqEventCompleted2);
		}
	}
}