using NfsCore.Global;
using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground1.Class
{
    public abstract class NfsUnderground1Collectable : Collectable
    {
        public override GameINT GameINT => GameINT.Underground1;
        public new Database.Underground1Db Database { get; protected init; }
    }
}