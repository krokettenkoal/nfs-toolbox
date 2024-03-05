using System;
using NfsCore.Reflection.Exception;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
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
            if (!Validate.TrackCollectionName(collectionName))
                throw new Exception("Unable to parse TrackID from the collection name provided.");
            if (Database.Tracks.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();

            //  Update TrackID based on the new collection name
            FormatX.GetUInt16(collectionName, "Track_{X}", out var id);
            TrackID = id;
        }
    }
}