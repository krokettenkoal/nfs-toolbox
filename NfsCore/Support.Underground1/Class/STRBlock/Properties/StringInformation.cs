using System.Collections.Generic;
using System.Linq;
using NfsCore.Reflection;
using NfsCore.Support.Shared.Parts.STRParts;
using NfsCore.Utils;

namespace NfsCore.Support.Underground1.Class
{
    public partial class STRBlock
    {
        private readonly List<StringRecord> _stringInfo = new();

        /// <summary>
        /// Length of the string information array.
        /// </summary>
        public override int InfoLength => _stringInfo.Count;

        /// <summary>
        /// Gets the <see cref="StringRecord"/> from the internal list.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to find.</param>
        /// <returns>StringRecord is it exists; otherwise null;</returns>
        public override StringRecord GetRecord(uint key)
        {
            return _stringInfo.Find(s => s.Key == key);
        }

        /// <summary>
        /// Gets all <see cref="StringRecord"/> stored in <see cref="STRBlock"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="StringRecord"/>.</returns>
        public override IEnumerable<StringRecord> GetRecords()
        {
            return _stringInfo;
        }

        /// <summary>
        /// Attempts to add <see cref="StringRecord"/> in the <see cref="STRBlock"/>.
        /// </summary>
        /// <param name="key">Key of the new <see cref="StringRecord"/></param>
        /// <param name="label">Label of the new <see cref="StringRecord"/></param>
        /// <param name="text">Text of the new <see cref="StringRecord"/></param>
        /// <returns>True if adding was successful; false otherwise.</returns>
        public override bool TryAddRecord(string key, string label, string text)
        {
            var hash = key == BaseArguments.AUTO ? Bin.Hash(label) : ConvertX.ToUInt32(key);
            if (hash == 0) return false;
            if (GetRecord(hash) != null) return false;
            _stringInfo.Add(new StringRecord(this)
            {
                Key = hash,
                Label = label,
                Text = text
            });
            return true;
        }

        /// <summary>
        /// Attempts to add <see cref="StringRecord"/> in the <see cref="STRBlock"/>.
        /// </summary>
        /// <param name="key">Key of the new <see cref="StringRecord"/></param>
        /// <param name="label">Label of the new <see cref="StringRecord"/></param>
        /// <param name="text">Text of the new <see cref="StringRecord"/></param>
        /// <param name="error">Error occured when trying to add the record.</param>
        /// <returns>True if adding was successful; false otherwise.</returns>
        public override bool TryAddRecord(string key, string label, string text, out string error)
        {
            error = null;
            var hash = key == BaseArguments.AUTO ? Bin.Hash(label) : ConvertX.ToUInt32(key);
            if (hash == 0)
            {
                error = $"Unable to convert string to a hexadecimal hash or hash equals 0.";
                return false;
            }

            if (GetRecord(hash) != null)
            {
                error = $"StringRecord with key 0x{hash:X8} already exist.";
                return false;
            }

            _stringInfo.Add(new StringRecord(this)
            {
                Key = hash,
                Label = label,
                Text = text
            });
            return true;
        }

        /// <summary>
        /// Removes string record at the index specified.
        /// </summary>
        /// <param name="key">Index of the record to be removed.</param>
        /// <returns>True if deleting was successful.</returns>
        public override bool TryRemoveRecord(uint key)
        {
            var record = GetRecord(key);
            if (record == null) return false;
            _stringInfo.Remove(record);
            return true;
        }

        /// <summary>
        /// Attempts to remove <see cref="StringRecord"/> with the key provided.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to be removed.</param>
        /// <param name="error">Error occured when trying to remove the record.</param>
        /// <returns>True if removing was successful; false otherwise.</returns>
        public override bool TryRemoveRecord(uint key, out string error)
        {
            error = null;
            var record = GetRecord(key);
            if (record == null)
            {
                error = $"StringRecord with key 0x{key:X8} does not exist.";
                return false;
            }

            _stringInfo.Remove(record);
            return true;
        }

        /// <summary>
        /// Retrieves all <see cref="StringRecord"/> that have their texts containing text provided.
        /// </summary>
        /// <param name="text">Text that other <see cref="StringRecord"/> should match.</param>
        /// <returns>Enumerable of records containing text provided.</returns>
        public override IEnumerable<StringRecord> FindWithText(string text)
        {
            return _stringInfo.Where(record => record.Text?.Contains(text) ?? false);
        }
    }
}