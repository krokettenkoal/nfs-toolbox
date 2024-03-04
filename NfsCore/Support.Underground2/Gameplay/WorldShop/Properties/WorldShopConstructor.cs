using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class WorldShop : Collectable
	{
		// Default constructor
		public WorldShop() { }

		// Default constructor: create new world shop
		public WorldShop(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble world shop
		public unsafe WorldShop(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~WorldShop() { }
	}
}