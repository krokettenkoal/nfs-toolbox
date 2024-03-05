namespace NfsCore.Reflection.Interface
{
    internal interface IOperative
    {
        bool TryAddCollection(string collectionName, string root);
        bool TryAddCollection(string collectionName, string root, out string error);
        bool TryRemoveCollection(string collectionName, string root);
        bool TryRemoveCollection(string collectionName, string root, out string error);
        bool TryCloneCollection(string newName, string copyFrom, string root);
        bool TryCloneCollection(string newName, string copyFrom, string root, out string error);
        bool TryImportCollection(string root, string filepath);
        bool TryImportCollection(string root, string filepath, out string error);
        bool TryExportCollection(string collectionName, string root, string filepath);
        bool TryExportCollection(string collectionName, string root, string filepath, out string error);
    }
}