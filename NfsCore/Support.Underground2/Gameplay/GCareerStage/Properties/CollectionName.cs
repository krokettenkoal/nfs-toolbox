using System;
using NfsCore.Reflection.Exception;
using NfsCore.Support.Underground2.Framework;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerStage
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        protected override void ValidateCollectionName(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName), "This value cannot be left left empty.");
            if (collectionName.Contains(' '))
                throw new Exception("CollectionName cannot contain whitespace.");
            if (!Validate.CareerStageCollectionName(collectionName))
                throw new Exception("Unable to parse stage number from the value provided.");
            if (Database.GCareerStages.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }
    }
}