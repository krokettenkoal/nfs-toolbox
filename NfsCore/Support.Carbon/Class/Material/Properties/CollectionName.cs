using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Material
    {
        private string _collection_name;

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        [AccessModifiable]
        public override string CollectionName
        {
            get => _collection_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value.Contains(' '))
                    throw new Exception("CollectionName cannot contain whitespace.");
                if (value.Length > MaxCNameLength)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 27 characters.");
                if (Database.Materials.FindCollection(value) != null)
                    throw new CollectionExistenceException();
                _collection_name = value;
            }
        }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public override uint BinKey { get => Bin.Hash(_collection_name); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public override uint VltKey { get => Vlt.Hash(_collection_name); }
    }
}