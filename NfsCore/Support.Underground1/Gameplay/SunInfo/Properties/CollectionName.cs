using System;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground1.Gameplay
{
    public partial class SunInfo
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
                throw new ArgumentLengthException("Length of the value passed should not exceed 23 characters.");
            if (Database.SunInfos.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }
    }
}