using System;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        protected override void ValidateCollectionName(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName), "This value cannot be left empty.");
            if (collectionName.Contains(" "))
                throw new Exception("CollectionName cannot contain whitespace.");
            if (collectionName.Length > MaxCNameLength)
                throw new ArgumentLengthException("Length of the value passed should not exceed 31 characters.");
            if (Database.PresetRides.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }
    }
}