﻿using System;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GShowcase
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
            if (collectionName.Length > 0x1F)
                throw new ArgumentLengthException("Length of the value passed should not exceed 31 characters.");
            if (Database.GShowcases.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }
    }
}