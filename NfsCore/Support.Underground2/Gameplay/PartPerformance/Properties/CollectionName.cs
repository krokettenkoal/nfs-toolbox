using System;
using NfsCore.Global;
using NfsCore.Reflection.Exception;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PartPerformance
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
            if (Database.PartPerformances.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();

            //  Overwrite collection name in global performance part table if validation succeeds
            if (_cnameIsSet)
                Map.PerfPartTable[(int) _partPerfType, _upgradeLevel, _upgradePartIndex] =
                    ConvertX.ToUInt32(collectionName);
        }

        // CollectionName is the BinKey, but as a string
        public override uint BinKey => Bin.SmartHash(CollName);
    }
}