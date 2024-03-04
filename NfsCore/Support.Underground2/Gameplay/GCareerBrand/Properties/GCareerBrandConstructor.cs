using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GCareerBrand : Collectable
	{
		// Default constructor
		public GCareerBrand() { }

		// Default constructor: create new career brand
		public GCareerBrand(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble career brand
		public unsafe GCareerBrand(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~GCareerBrand() { }
	}
}