using System;

namespace NfsCore.Support.Underground1.Class
{
    public partial class FNGroup
    {
        private byte[] _DATA;

        /// <summary>
        /// Data of the FEng file.
        /// </summary>
        public byte[] Data
        {
            get => _DATA;
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _DATA = value;
            }
        }
    }
}