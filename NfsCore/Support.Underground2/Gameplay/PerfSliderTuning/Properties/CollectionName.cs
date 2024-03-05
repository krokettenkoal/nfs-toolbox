using System;
using NfsCore.Reflection.Exception;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class PerfSliderTuning
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
            if (!Validate.PerfSliderCollectionName(collectionName))
                throw new Exception("Unable to parse value provided as a hexadecimal containing tuning settings.");
            if (Database.PerfSliderTunings.FindCollection(collectionName) != null)
                throw new CollectionExistenceException();
        }

        public override uint BinKey => ConvertX.ToUInt32(CollName);
    }
}