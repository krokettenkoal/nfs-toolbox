using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class GShowcase : Collectable
	{
		// Default constructor
		public GShowcase() { }

		// Default constructor: create new showcase
		public GShowcase(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble showcase
		public unsafe GShowcase(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~GShowcase() { }
	}
}