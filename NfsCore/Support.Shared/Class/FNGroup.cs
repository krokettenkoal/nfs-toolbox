using System;
using System.Collections.Generic;
using System.Linq;
using NfsCore.Reflection.Abstract;
using NfsCore.Support.Shared.Parts.FNGParts;

namespace NfsCore.Support.Shared.Class
{
    public abstract class FNGroup : Collectable
    {
        #region Main Properties

        /// <summary>
        /// Size of the <see cref="FNGroup"/> in Global memory.
        /// </summary>
        public uint Size { get; protected set; }

        /// <summary>
        /// Represents boolean of whether this <see cref="FNGroup"/> can be destroyed b/c it is repetitive.
        /// </summary>
        public bool Destroy { get; protected set; }

        /// <summary>
        /// List of all <see cref="FEngColor"/> that <see cref="FNGroup"/> contains.
        /// </summary>
        protected readonly List<FEngColor> ColorInfo = new();

        /// <summary>
        /// Length of the color information array.
        /// </summary>
        public int InfoLength => ColorInfo.Count;

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
        /// Assembles frontend group into a byte array.
        /// </summary>
        /// <returns>Byte array of the frontend group.</returns>
        public virtual byte[] Assemble()
        {
            return null;
        }

        /// <summary>
        /// Disassembles frontend group array into separate properties.
        /// </summary>
        /// <param name="data">The frontend group data array to disassemble.</param>
        protected virtual void Disassemble(byte[] data)
        {
        }

        /// <summary>
        /// Gets <see cref="FEngColor"/> from a specific index.
        /// </summary>
        /// <param name="index">Index of the color.</param>
        /// <returns><see cref="FEngColor"/> class.</returns>
        public FEngColor GetColor(int index)
        {
            return index >= InfoLength ? null : ColorInfo[index];
        }

        /// <summary>
        /// Attempts to set new <see cref="FEngColor"/> at specific color.
        /// </summary>
        /// <param name="index">Index of the color to set.</param>
        /// <param name="color">New <see cref="FEngColor"/> to set.</param>
        /// <returns>True if setting new color was successful; false otherwise.</returns>
        public bool TrySetOne(int index, FEngColor color)
        {
            var thisColor = GetColor(index);
            if (thisColor == null) return false;
            thisColor.Alpha = color.Alpha;
            thisColor.Red = color.Red;
            thisColor.Green = color.Green;
            thisColor.Blue = color.Blue;
            return true;
        }

        /// <summary>
        /// Attempts to set new <see cref="FEngColor"/> at specific color.
        /// </summary>
        /// <param name="index">Index of the color to set.</param>
        /// <param name="color">New <see cref="FEngColor"/> to set.</param>
        /// <param name="error">Error occured when trying to set one color.</param>
        /// <returns>True if setting new color was successful; false otherwise.</returns>
        public bool TrySetOne(int index, FEngColor color, out string error)
        {
            error = null;
            var thisColor = GetColor(index);
            if (thisColor == null)
            {
                error = $"Color with index {index} does not exist.";
                return false;
            }

            thisColor.Alpha = color.Alpha;
            thisColor.Red = color.Red;
            thisColor.Green = color.Green;
            thisColor.Blue = color.Blue;
            return true;
        }

        /// <summary>
        /// Attempts to set same <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="index">Index of the <see cref="FEngColor"/> to match.</param>
        /// <param name="newBase">New <see cref="FEngColor"/> to set.</param>
        /// <param name="keepAlpha">True if alpha value should be kept; false otherwise.</param>
        /// <returns>True if setting same colors was successful; false otherwise.</returns>
        public bool TrySetSame(int index, FEngColor newBase, bool keepAlpha)
        {
            var exColor = GetColor(index);
            if (exColor == null) return false;
            var sample = new FEngColor(null)
            {
                Alpha = exColor.Alpha,
                Red = exColor.Red,
                Green = exColor.Green,
                Blue = exColor.Blue
            };
            foreach (var color in ColorInfo.Where(color => color == sample))
            {
                color.Red = newBase.Red;
                color.Green = newBase.Green;
                color.Blue = newBase.Blue;
                if (!keepAlpha) color.Alpha = newBase.Alpha;
            }

            return true;
        }

        /// <summary>
        /// Attempts to set same <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="index">Index of the <see cref="FEngColor"/> to match.</param>
        /// <param name="newBase">New <see cref="FEngColor"/> to set.</param>
        /// <param name="keepAlpha">True if alpha value should be kept; false otherwise.</param>
        /// <param name="error">Error occured when trying to set same colors.</param>
        /// <returns>True if setting same colors was successful; false otherwise.</returns>
        public bool TrySetSame(int index, FEngColor newBase, bool keepAlpha, out string error)
        {
            error = null;
            var exColor = GetColor(index);
            if (exColor == null)
            {
                error = $"Color with index {index} does not exist.";
                return false;
            }

            var sample = new FEngColor(null)
            {
                Alpha = exColor.Alpha,
                Red = exColor.Red,
                Green = exColor.Green,
                Blue = exColor.Blue
            };
            foreach (var color in ColorInfo.Where(color => color == sample))
            {
                color.Red = newBase.Red;
                color.Green = newBase.Green;
                color.Blue = newBase.Blue;
                if (!keepAlpha) color.Alpha = newBase.Alpha;
            }

            return true;
        }

        /// <summary>
        /// Attempts to set all <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="color"><see cref="FEngColor"/> to set for all colors.</param>
        /// <param name="keepAlpha">True if alpha value should be kept; false otherwise.</param>
        /// <returns>True if setting all colors was successful; false otherwise.</returns>
        public bool TrySetAll(FEngColor color, bool keepAlpha)
        {
            foreach (var thisColor in ColorInfo)
            {
                thisColor.Red = color.Red;
                thisColor.Green = color.Green;
                thisColor.Blue = color.Blue;
                if (!keepAlpha) thisColor.Alpha = color.Alpha;
            }

            return true;
        }

        /// <summary>
        /// Attempts to set all <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="color"><see cref="FEngColor"/> to set for all colors.</param>
        /// <param name="keepAlpha">True if alpha value should be kept; false otherwise.</param>
        /// <param name="error">Error occured when trying to set all colors.</param>
        /// <returns>True if setting all colors was successful; false otherwise.</returns>
        public bool TrySetAll(FEngColor color, bool keepAlpha, out string error)
        {
            error = null;
            foreach (var thisColor in ColorInfo)
            {
                thisColor.Red = color.Red;
                thisColor.Green = color.Green;
                thisColor.Blue = color.Blue;
                if (!keepAlpha) thisColor.Alpha = color.Alpha;
            }

            return true;
        }

        #endregion
    }
}