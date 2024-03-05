namespace NfsCore.Support.Underground2.Class
{
    public partial class FNGroup
    {
        public override string ToString()
        {
            return $"Collection Name: {CollectionName} | " +
                   $"BinKey: {BinKey:X8} | Game: {GameSTR}";
        }
    }
}