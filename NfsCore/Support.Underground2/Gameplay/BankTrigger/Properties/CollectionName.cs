using System;
using NfsCore.Reflection.Exception;
using NfsCore.Support.Underground2.Framework;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class BankTrigger
    {
        /// <summary>
        /// Validates the collection name of the BankTrigger item
        /// </summary>
        protected override void ValidateCollectionName(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName), "This value cannot be left left empty.");
            if (collectionName.Contains(' '))
                throw new Exception("CollectionName cannot contain whitespace.");
            if (!Validate.BankTriggerCollectionName(collectionName))
                throw new Exception("CollectionName should be of format BANK_TRIGGER_# with 2-digit index.");
            if (Database.BankTriggers.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }
    }
}