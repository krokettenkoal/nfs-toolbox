﻿using System;
using System.Collections.Generic;
using NfsCore.Reflection.Abstract;
using NfsCore.Support.Shared.Parts.STRParts;
using NfsCore.Utils;

namespace NfsCore.Support.Shared.Class
{
    public abstract class STRBlock : Collectable
    {
        #region Main Properties

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public override uint BinKey => 0;

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public override uint VltKey => 0;

        /// <summary>
        /// Length of the string information array.
        /// </summary>
        public virtual int InfoLength { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assembles string block into a byte array.
        /// </summary>
        /// <returns>Byte array of the string block.</returns>
        public virtual byte[] Assemble()
        {
            return null;
        }

        /// <summary>
        /// Disassembles string block array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the string block array.</param>
        /// <param name="length">The length of the string to disassemble</param>
        protected virtual unsafe void Disassemble(byte* bytePtrT, int length)
        {
        }

        /// <summary>
        /// Disassembles labels block array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the label block array.</param>
        /// <param name="length">The length of the label to disassemble</param>
        protected virtual unsafe void DisperseLabels(byte* bytePtrT, int length)
        {
        }

        /// <summary>
        /// Assembles labels block into a byte array.
        /// </summary>
        /// <returns>Byte array of the labels block.</returns>
        public virtual byte[] ParseLabels()
        {
            return null;
        }

        /// <summary>
        /// Gets the <see cref="StringRecord"/> from the internal list.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to find.</param>
        /// <returns>StringRecord is it exists; otherwise null;</returns>
        public virtual StringRecord GetRecord(uint key)
        {
            return null;
        }

        /// <summary>
        /// Gets the <see cref="StringRecord"/> from the internal list.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to find.</param>
        /// <returns>StringRecord is it exists; otherwise null;</returns>
        public virtual StringRecord GetRecord(string key)
        {
            return GetRecord(ConvertX.ToUInt32(key));
        }

        /// <summary>
        /// Gets all <see cref="StringRecord"/> stored in <see cref="STRBlock"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="StringRecord"/>.</returns>
        public virtual IEnumerable<StringRecord> GetRecords()
        {
            return null;
        }

        /// <summary>
        /// Gets text from the binary key of a label provided.
        /// </summary>
        /// <param name="key">Key of the string label.</param>
        /// <returns>Text of the label as a string.</returns>
        public virtual string GetText(uint key)
        {
            return GetRecord(key)?.Text;
        }

        /// <summary>
        /// Gets text from the binary key of a label provided.
        /// </summary>
        /// <param name="key">Key of the string label.</param>
        /// <returns>Text of the label as a string.</returns>
        public virtual string GetText(string key)
        {
            return GetRecord(key)?.Text;
        }

        /// <summary>
        /// Attempts to add <see cref="StringRecord"/> in the <see cref="STRBlock"/>.
        /// </summary>
        /// <param name="key">Key of the new <see cref="StringRecord"/></param>
        /// <param name="label">Label of the new <see cref="StringRecord"/></param>
        /// <param name="text">Text of the new <see cref="StringRecord"/></param>
        /// <returns>True if adding was successful; false otherwise.</returns>
        public virtual bool TryAddRecord(string key, string label, string text)
        {
            return false;
        }

        /// <summary>
        /// Attempts to add <see cref="StringRecord"/> in the <see cref="STRBlock"/>.
        /// </summary>
        /// <param name="key">Key of the new <see cref="StringRecord"/></param>
        /// <param name="label">Label of the new <see cref="StringRecord"/></param>
        /// <param name="text">Text of the new <see cref="StringRecord"/></param>
        /// <param name="error">Error occured when trying to add the record.</param>
        /// <returns>True if adding was successful; false otherwise.</returns>
        public virtual bool TryAddRecord(string key, string label, string text, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attempts to remove <see cref="StringRecord"/> with the key provided.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to be removed.</param>
        /// <returns>True if removing was successful; false otherwise.</returns>
        public virtual bool TryRemoveRecord(uint key)
        {
            return false;
        }

        /// <summary>
        /// Attempts to remove <see cref="StringRecord"/> with the key provided.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to be removed.</param>
        /// <returns>True if removing was successful; false otherwise.</returns>
        public virtual bool TryRemoveRecord(string key)
        {
            return false;
        }

        /// <summary>
        /// Attempts to remove <see cref="StringRecord"/> with the key provided.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to be removed.</param>
        /// <param name="error">Error occured when trying to remove the record.</param>
        /// <returns>True if removing was successful; false otherwise.</returns>
        public virtual bool TryRemoveRecord(uint key, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Attempts to remove <see cref="StringRecord"/> with the key provided.
        /// </summary>
        /// <param name="key">Key of the <see cref="StringRecord"/> to be removed.</param>
        /// <param name="error">Error occured when trying to remove the record.</param>
        /// <returns>True if removing was successful; false otherwise.</returns>
        public virtual bool TryRemoveRecord(string key, out string error)
        {
            error = null;
            return false;
        }

        /// <summary>
        /// Retrieves all <see cref="StringRecord"/> that have their texts containing text provided.
        /// </summary>
        /// <param name="text">Text that other <see cref="StringRecord"/> should match.</param>
        /// <returns>Enumerable of records containing text provided.</returns>
        public virtual IEnumerable<StringRecord> FindWithText(string text)
        {
            return null;
        }

        #endregion
    }
}