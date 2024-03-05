namespace NfsCore.Reflection.Interface
{
    public interface ICopyable<out T>
    {
        T PlainCopy();
    }
}