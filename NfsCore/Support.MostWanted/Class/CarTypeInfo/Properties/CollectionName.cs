using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        protected override void ValidateCollectionName(string collectionName)
        {
            if (!Deletable)
                throw new CollectionExistenceException("CollectionName of a non-addon car cannot be changed.");
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName), "This value cannot be left empty.");
            if (collectionName.Contains(" "))
                throw new Exception("CollectionName cannot contain whitespace.");
            if (collectionName.Length > MaxCNameLength)
                throw new ArgumentLengthException("Length of the value passed should not exceed 13 characters.");
            if (Database.CarTypeInfos.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();

            if (_collisionExternalName != BaseArguments.NULL)
                _collisionExternalName = collectionName;
        }

        /// <summary>
        /// Represents memory type of the CarTypeInfo
        /// </summary>
        [AccessModifiable]
        public override eMemoryType MemoryType
        {
            get => base.MemoryType;
            set => base.MemoryType = value;
        }
    }
}