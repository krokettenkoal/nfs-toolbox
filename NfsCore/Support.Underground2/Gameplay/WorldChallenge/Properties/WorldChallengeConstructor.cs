using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class WorldChallenge : Collectable
	{
		// Default constructor
		public WorldChallenge() { }

		// Default constructor: create new world challenge
		public WorldChallenge(string CName, Database.Underground2Db db)
		{
			this.Database = db;
			this.CollectionName = CName;
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble world challenge
		public unsafe WorldChallenge(byte* ptr_header, byte* ptr_string, Database.Underground2Db db)
		{
			this.Database = db;
			this.Disassemble(ptr_header, ptr_string);
		}

		~WorldChallenge() { }
	}
}