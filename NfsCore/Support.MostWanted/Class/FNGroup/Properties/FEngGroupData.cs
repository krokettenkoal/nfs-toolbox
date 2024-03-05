using System;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class FNGroup
    {
        private byte[] _data;

        /// <summary>
        /// Data of the FEng file.
        /// </summary>
        public byte[] Data
        {
            get => _data;
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _data = value;
            }
        }
    }
}