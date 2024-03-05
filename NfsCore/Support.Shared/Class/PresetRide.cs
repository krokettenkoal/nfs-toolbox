using System;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Attributes;
using NfsCore.Support.Shared.Parts.PresetParts;
using NfsCore.Utils;

namespace NfsCore.Support.Shared.Class
{
    public class PresetRide : Collectable
    {
        #region Private Fields

        private string _model = "SUPRA";
        protected string FrontendInternal = "supra";
        protected string PVehicleInternal = "supra";

        #endregion

        #region Main Properties

        /// <summary>
        /// Vault memory hash of the frontend value.
        /// </summary>
        public virtual uint FrontendKey => Vlt.Hash(FrontendInternal);

        /// <summary>
        /// Vault memory hash of the pvehicle value.
        /// </summary>
        public virtual uint PvehicleKey => Vlt.Hash(PVehicleInternal);

        /// <summary>
        /// Original model name of the preset ride.
        /// </summary>
        public string OriginalModel { get; protected set; }

        #endregion

        #region AccessModifiable Properties

        /// <summary>
        /// Represents model of the preset ride.
        /// </summary>
        [AccessModifiable]
        public string MODEL
        {
            get => _model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _model = value;
            }
        }

        /// <summary>
        /// Represents frontend name of the preset ride.
        /// </summary>
        public virtual string Frontend
        {
            get => FrontendInternal;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                FrontendInternal = value;
            }
        }

        /// <summary>
        /// Represents pvehicle name of the preset ride.
        /// </summary>
        public virtual string Pvehicle
        {
            get => PVehicleInternal;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                PVehicleInternal = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles preset ride into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset ride.</returns>
        public virtual byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles preset ride array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the preset ride array.</param>
        protected virtual unsafe void Disassemble(byte* bytePtrT) { }

        /// <summary>
        /// Converts all preset parts into binary memory keys.
        /// </summary>
        /// <param name="parts">PresetParts concatenator class of all preset ride's parts.</param>
        /// <returns>Sorted array of all preset parts hashes.</returns>
        protected virtual uint[] StringToKey(Concatenator parts) { return null; }

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}