namespace NfsCore.Support.MostWanted.Class
{
    public partial class Material
    {
        public override string ToString()
        {
            return $"Collection Name: {CollectionName} | " +
                   $"BinKey: {BinKey:X8} | Game: {GameSTR}";
        }
    }
}