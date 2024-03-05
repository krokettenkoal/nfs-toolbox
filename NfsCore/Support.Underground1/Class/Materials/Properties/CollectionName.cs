using System;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground1.Class
{
    public partial class Material
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        protected override void ValidateCollectionName(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName), "This value cannot be left empty.");
            if (collectionName.Contains(' '))
                throw new Exception("CollectionName cannot contain whitespace.");
            if (collectionName.Length > MaxCNameLength)
                throw new ArgumentLengthException("Length of the value passed should not exceed 27 characters.");
            if (Database.Materials.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }
    }
}