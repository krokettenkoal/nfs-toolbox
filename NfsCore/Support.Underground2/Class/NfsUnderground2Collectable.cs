using NfsCore.Global;
using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Class
{
    public abstract class NfsUnderground2Collectable : Collectable
    {
        public override GameINT GameINT => GameINT.Underground2;
        public new Database.Underground2Db Database { get; protected init; }
    }
}