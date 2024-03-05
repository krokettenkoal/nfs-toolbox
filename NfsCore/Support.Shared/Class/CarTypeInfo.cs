using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Enum;
using NfsCore.Reflection.Exception;
using NfsCore.Utils;

namespace NfsCore.Support.Shared.Class
{
    public class CarTypeInfo : Collectable
    {
        #region Private Fields

        private string _manufacturerName;
        private int _index = -1;
        private eUsageType _usageType = eUsageType.Racer;
        private eMemoryType _memoryType = eMemoryType.Racing;
        private eBoolean _isSkinnable = eBoolean.True;
        private string _defaultBasePaint = BaseArguments.BPAINT;
        protected string CollInternalName = BaseArguments.NULL;

		#endregion

		#region Main Properties

        /// <summary>
        /// Provides info on whether this cartypeinfo was modified.
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// Original collection name of the cartypeinfo.
        /// </summary>
        public string OriginalName { get; protected init; }

        #endregion

        #region AccessModifiable Properties

        /// <summary>
        /// Represents manufacturer name of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        public string ManufacturerName
        {
            get => _manufacturerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                if (value.Length > 15)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 15 characters.");
                _manufacturerName = value;
            }
        }

        /// <summary>
        /// Represents internal collision name of the cartypeinfo.
        /// </summary>
        public virtual string CollisionInternalName
        {
            get => CollInternalName;
            set
            {
                if (value == BaseArguments.NULL || Map.CollisionMap.ContainsValue(value))
                    CollInternalName = value;
                else
                    throw new MappingFailException();
            }
        }

        /// <summary>
        /// Represents index of the cartypeinfo in Global data.
        /// </summary>
        public int Index
        {
            get => _index;
            set
            {
                if (value is > byte.MaxValue or < byte.MinValue)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed was outside of range of possible values.");
                
                _index = value;
            }
        }

        /// <summary>
        /// Represents usage type of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        public eUsageType UsageType
        {
            get => _usageType;
            set
            {
                if (Enum.IsDefined(typeof(eUsageType), value))
                {
                    //if (!this.Deletable)
                    //    throw new Exception("Usage type of a core car cannot be changed.");
                    if (_usageType != value)
                        Modified = true;
                    _usageType = value;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents memory type of the cartypeinfo.
        /// </summary>
        public virtual eMemoryType MemoryType
        {
            get => _memoryType;
            set
            {
                if (Enum.IsDefined(typeof(eMemoryType), value))
                    _memoryType = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents boolean as an int of whether cartypeinfo is skinnable.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public eBoolean IsSkinnable
        {
            get => _isSkinnable;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    _isSkinnable = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Represents paint type of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public virtual string DefaultBasePaint
        {
            get => _defaultBasePaint;
            set
            {
                if (value == BaseArguments.NULL || Map.BinKeys.ContainsValue(value))
                    _defaultBasePaint = value;
                else
                    throw new MappingFailException();
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public float HeadlightFOV { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte PadHighPerformance { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte NumAvailableSkinNumbers { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte WhatGame { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte ConvertibleFlag { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte WheelOuterRadius { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte WheelInnerRadiusMin { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte WheelInnerRadiusMax { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte Padding0 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float HeadlightPositionX { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float HeadlightPositionY { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float HeadlightPositionZ { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float HeadlightPositionW { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float DriverRenderingOffsetX { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float DriverRenderingOffsetY { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float DriverRenderingOffsetZ { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float DriverRenderingOffsetW { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float SteeringWheelRenderingX { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float SteeringWheelRenderingY { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float SteeringWheelRenderingZ { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float SteeringWheelRenderingW { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte MaxInstances1 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte MaxInstances2 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte MaxInstances3 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte MaxInstances4 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte MaxInstances5 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte KeepLoaded1 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte KeepLoaded2 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte KeepLoaded3 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte KeepLoaded4 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte KeepLoaded5 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public short Padding1 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float MinTimeBetweenUses1 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float MinTimeBetweenUses2 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float MinTimeBetweenUses3 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float MinTimeBetweenUses4 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public float MinTimeBetweenUses5 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers01 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers02 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers03 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers04 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers05 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers06 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers07 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers08 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers09 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte AvailableSkinNumbers10 { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public byte DefaultSkinNumber { get; set; } = 0;

        [AccessModifiable]
        [StaticModifiable]
        public int Padding2 { get; set; } = 0;

        #endregion

        #region Methods

        /// <summary>
        /// Assembles cartypeinfo into a byte array.
        /// </summary>
        /// <returns>Byte array of the cartypeinfo.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles cartypeinfo array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the cartypeinfo array.</param>
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