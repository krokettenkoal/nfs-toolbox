using System;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class WorldShop
    {
        private string _shopFilename;

        [AccessModifiable]
        public string ShopFilename
        {
            get => _shopFilename;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value.Length > 0xF)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 15 characters.");
                _shopFilename = value;
            }
        }
    }
}