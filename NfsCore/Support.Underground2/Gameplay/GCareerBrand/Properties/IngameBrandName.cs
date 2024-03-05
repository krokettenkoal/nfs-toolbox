using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerBrand
    {
        private string _inGameBrandName = BaseArguments.NULL;

        [AccessModifiable]
        public string IngameBrandName
        {
            get => _inGameBrandName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value.Length > 0x1F)
                    throw new ArgumentLengthException("Length of the value should not exceed 31 character.");
                _inGameBrandName = value;
            }
        }
    }
}