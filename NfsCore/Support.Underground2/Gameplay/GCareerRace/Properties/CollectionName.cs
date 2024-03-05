using System;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace
    {
        /// <summary>
        /// Validates the collection name for the GCareerBrand item
        /// </summary>
        protected override void ValidateCollectionName(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName), "This value cannot be left left empty.");
            if (collectionName.Contains(' '))
                throw new Exception("CollectionName cannot contain whitespace.");
            if (Database.GCareerRaces.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }
    }
}