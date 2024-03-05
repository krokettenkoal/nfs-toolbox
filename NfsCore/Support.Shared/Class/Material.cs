using System;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.ID;

namespace NfsCore.Support.Shared.Class
{
    public class Material : Collectable
    {
        #region Private Fields

        protected const int UnknownMaterialProp0 = 0;
        protected const int UnknownMaterialProp1 = 1;
        protected const int MaterialLocalizer = 3;

        #endregion

        #region Main Properties

        /// <summary>
        /// ID of the material block
        /// </summary>
        public static uint Id => GlobalId.Materials;

        #endregion

        #region Methods

        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public virtual byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles material array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the material array.</param>
        protected virtual unsafe void Disassemble(byte* bytePtrT) { }

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