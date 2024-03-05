namespace NfsCore.Reflection.Interface
{
    public interface ICastable<out T>
    {
        T MemoryCast(string collectionName);
    }
}