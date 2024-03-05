namespace NfsCore.Reflection.Interface
{
    public interface ISetValue
    {
        bool SetValue(string propertyName, object value);
        bool SetValue(string propertyName, object value, ref string error);
    }
}