using System.IO;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Assembles cartypeinfo into a byte array.
        /// </summary>
        /// <returns>Byte array of the cartypeinfo.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[0xD0];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write CollectionName
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + a1) = (byte) CollectionName[a1];

                // Write BaseModelName
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + 0x10 + a1) = (byte) CollectionName[a1];

                // Write GeometryFileName
                var path = Path.Combine("CARS", CollectionName, "GEOMETRY.BIN");
                for (var a1 = 0; a1 < path.Length; ++a1)
                    *(bytePtrT + 0x20 + a1) = (byte) path[a1];

                // Write ManufacturerName
                if (ManufacturerName != BaseArguments.NULL)
                {
                    for (var a1 = 0; a1 < ManufacturerName.Length; ++a1)
                        *(bytePtrT + 0x40 + a1) = (byte) ManufacturerName[a1];
                }

                // Write all settings
                *(uint*) (bytePtrT + 0x50) = BinKey;
                *(float*) (bytePtrT + 0x54) = HeadlightFOV;
                *(bytePtrT + 0x58) = PadHighPerformance;
                *(bytePtrT + 0x59) = NumAvailableSkinNumbers;
                *(bytePtrT + 0x5A) = WhatGame;
                *(bytePtrT + 0x5B) = ConvertibleFlag;
                *(bytePtrT + 0x5C) = WheelOuterRadius;
                *(bytePtrT + 0x5D) = WheelInnerRadiusMin;
                *(bytePtrT + 0x5E) = WheelInnerRadiusMax;
                *(bytePtrT + 0x5F) = Padding0;
                *(float*) (bytePtrT + 0x60) = HeadlightPositionX;
                *(float*) (bytePtrT + 0x64) = HeadlightPositionY;
                *(float*) (bytePtrT + 0x68) = HeadlightPositionZ;
                *(float*) (bytePtrT + 0x6C) = HeadlightPositionW;
                *(float*) (bytePtrT + 0x70) = DriverRenderingOffsetX;
                *(float*) (bytePtrT + 0x74) = DriverRenderingOffsetY;
                *(float*) (bytePtrT + 0x78) = DriverRenderingOffsetZ;
                *(float*) (bytePtrT + 0x7C) = DriverRenderingOffsetW;
                *(float*) (bytePtrT + 0x80) = SteeringWheelRenderingX;
                *(float*) (bytePtrT + 0x84) = SteeringWheelRenderingY;
                *(float*) (bytePtrT + 0x88) = SteeringWheelRenderingZ;
                *(float*) (bytePtrT + 0x8C) = SteeringWheelRenderingW;

                *(int*) (bytePtrT + 0x90) = Index;
                *(int*) (bytePtrT + 0x94) = (int) UsageType;
                *(uint*) (bytePtrT + 0x98) = (uint) MemoryType;

                *(bytePtrT + 0x9C) = MaxInstances1;
                *(bytePtrT + 0x9D) = MaxInstances2;
                *(bytePtrT + 0x9E) = MaxInstances3;
                *(bytePtrT + 0x9F) = MaxInstances4;
                *(bytePtrT + 0xA0) = MaxInstances5;
                *(bytePtrT + 0xA1) = KeepLoaded1;
                *(bytePtrT + 0xA2) = KeepLoaded2;
                *(bytePtrT + 0xA3) = KeepLoaded3;
                *(bytePtrT + 0xA4) = KeepLoaded4;
                *(bytePtrT + 0xA5) = KeepLoaded5;
                *(short*) (bytePtrT + 0xA6) = Padding1;
                *(float*) (bytePtrT + 0xA8) = MinTimeBetweenUses1;
                *(float*) (bytePtrT + 0xAC) = MinTimeBetweenUses2;
                *(float*) (bytePtrT + 0xB0) = MinTimeBetweenUses3;
                *(float*) (bytePtrT + 0xB4) = MinTimeBetweenUses4;
                *(float*) (bytePtrT + 0xB8) = MinTimeBetweenUses5;
                *(bytePtrT + 0xBC) = AvailableSkinNumbers01;
                *(bytePtrT + 0xBD) = AvailableSkinNumbers02;
                *(bytePtrT + 0xBE) = AvailableSkinNumbers03;
                *(bytePtrT + 0xBF) = AvailableSkinNumbers04;
                *(bytePtrT + 0xC0) = AvailableSkinNumbers05;
                *(bytePtrT + 0xC1) = AvailableSkinNumbers06;
                *(bytePtrT + 0xC2) = AvailableSkinNumbers07;
                *(bytePtrT + 0xC3) = AvailableSkinNumbers08;
                *(bytePtrT + 0xC4) = AvailableSkinNumbers09;
                *(bytePtrT + 0xC5) = AvailableSkinNumbers10;

                *(bytePtrT + 0xC6) = DefaultSkinNumber;
                *(bytePtrT + 0xC7) = (IsSkinnable == eBoolean.True) ? (byte) 1 : (byte) 0;
                *(int*) (bytePtrT + 0xC8) = Padding2;

                if (string.IsNullOrWhiteSpace(DefaultBasePaint))
                {
                }
                else if (DefaultBasePaint.StartsWith("0x"))
                    *(uint*) (bytePtrT + 0xCC) = ConvertX.ToUInt32(DefaultBasePaint);
                else
                    *(uint*) (bytePtrT + 0xCC) = Bin.Hash(DefaultBasePaint);

                if (*(uint*) (bytePtrT + 0xCC) == 0)
                    *(uint*) (bytePtrT + 0xCC) = Bin.Hash(BaseArguments.BPAINT);
            }

            return result;
        }
    }
}