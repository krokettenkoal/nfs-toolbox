using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Disassembles CarTypeInfo array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the <see cref="CarTypeInfo"/></param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            // Get Manufacturer name
            var name = ScriptX.NullTerminatedString(bytePtrT + 0x40, 0x10);
            ManufacturerName = string.IsNullOrWhiteSpace(name) ? BaseArguments.NULL : name;

            HeadlightFOV = *(float*) (bytePtrT + 0x54);
            PadHighPerformance = *(bytePtrT + 0x58);
            NumAvailableSkinNumbers = *(bytePtrT + 0x59);
            WhatGame = *(bytePtrT + 0x5A);
            ConvertibleFlag = *(bytePtrT + 0x5B);
            WheelOuterRadius = *(bytePtrT + 0x5C);
            WheelInnerRadiusMin = *(bytePtrT + 0x5D);
            WheelInnerRadiusMax = *(bytePtrT + 0x5E);
            Padding0 = *(bytePtrT + 0x5F);
            HeadlightPositionX = *(float*) (bytePtrT + 0x60);
            HeadlightPositionY = *(float*) (bytePtrT + 0x64);
            HeadlightPositionZ = *(float*) (bytePtrT + 0x68);
            HeadlightPositionW = *(float*) (bytePtrT + 0x6C);
            DriverRenderingOffsetX = *(float*) (bytePtrT + 0x70);
            DriverRenderingOffsetY = *(float*) (bytePtrT + 0x74);
            DriverRenderingOffsetZ = *(float*) (bytePtrT + 0x78);
            DriverRenderingOffsetW = *(float*) (bytePtrT + 0x7C);
            SteeringWheelRenderingX = *(float*) (bytePtrT + 0x80);
            SteeringWheelRenderingY = *(float*) (bytePtrT + 0x84);
            SteeringWheelRenderingZ = *(float*) (bytePtrT + 0x88);
            SteeringWheelRenderingW = *(float*) (bytePtrT + 0x8C);

            Index = *(int*) (bytePtrT + 0x90);
            UsageType = (eUsageType) (*(int*) (bytePtrT + 0x94));
            MemoryType = (eMemoryType) (*(uint*) (bytePtrT + 0x98));

            MaxInstances1 = *(bytePtrT + 0x9C);
            MaxInstances2 = *(bytePtrT + 0x9D);
            MaxInstances3 = *(bytePtrT + 0x9E);
            MaxInstances4 = *(bytePtrT + 0x9F);
            MaxInstances5 = *(bytePtrT + 0xA0);
            KeepLoaded1 = *(bytePtrT + 0xA1);
            KeepLoaded2 = *(bytePtrT + 0xA2);
            KeepLoaded3 = *(bytePtrT + 0xA3);
            KeepLoaded4 = *(bytePtrT + 0xA4);
            KeepLoaded5 = *(bytePtrT + 0xA5);
            Padding1 = *(short*) (bytePtrT + 0xA6);
            MinTimeBetweenUses1 = *(float*) (bytePtrT + 0xA8);
            MinTimeBetweenUses2 = *(float*) (bytePtrT + 0xAC);
            MinTimeBetweenUses3 = *(float*) (bytePtrT + 0xB0);
            MinTimeBetweenUses4 = *(float*) (bytePtrT + 0xB4);
            MinTimeBetweenUses5 = *(float*) (bytePtrT + 0xB8);
            AvailableSkinNumbers01 = *(bytePtrT + 0xBC);
            AvailableSkinNumbers02 = *(bytePtrT + 0xBD);
            AvailableSkinNumbers03 = *(bytePtrT + 0xBE);
            AvailableSkinNumbers04 = *(bytePtrT + 0xBF);
            AvailableSkinNumbers05 = *(bytePtrT + 0xC0);
            AvailableSkinNumbers06 = *(bytePtrT + 0xC1);
            AvailableSkinNumbers07 = *(bytePtrT + 0xC2);
            AvailableSkinNumbers08 = *(bytePtrT + 0xC3);
            AvailableSkinNumbers09 = *(bytePtrT + 0xC4);
            AvailableSkinNumbers10 = *(bytePtrT + 0xC5);

            DefaultSkinNumber = *(bytePtrT + 0xC6);
            IsSkinnable = (*(bytePtrT + 0xC7) == 0)
                ? eBoolean.False
                : eBoolean.True;
            Padding2 = *(int*) (bytePtrT + 0xC8);

            var key = *(uint*) (bytePtrT + 0xCC);
            DefaultBasePaint = Map.Lookup(key, true) ?? BaseArguments.BPAINT;
        }
    }
}