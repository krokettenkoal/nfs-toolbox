using System.IO;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Support.Underground2.Parts.CarParts;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Assembles CarTypeInfo into a byte array.
        /// </summary>
        /// <returns>Byte array of the CarTypeInfo.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[0x890];
            fixed (byte* bytePtrT = &result[0])
            {
                // Write CollectionName
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + a1) = (byte) CollectionName[a1];

                // Write BaseModelName
                for (var a1 = 0; a1 < CollectionName.Length; ++a1)
                    *(bytePtrT + 0x20 + a1) = (byte) CollectionName[a1];

                // Write GeometryBINFileName
                var pathBin = Path.Combine("CARS", CollectionName, "GEOMETRY.BIN");
                for (var a1 = 0; a1 < pathBin.Length; ++a1)
                    *(bytePtrT + 0x40 + a1) = (byte) pathBin[a1];

                // Write GeometryLZCFileName
                var pathLzc = Path.Combine("CARS", CollectionName, "GEOMETRY.LZC");
                for (var a1 = 0; a1 < pathBin.Length; ++a1)
                    *(bytePtrT + 0x60 + a1) = (byte) pathLzc[a1];

                // Write ManufacturerName
                if (ManufacturerName != BaseArguments.NULL)
                {
                    for (var a1 = 0; a1 < ManufacturerName.Length; ++a1)
                        *(bytePtrT + 0xC0 + a1) = (byte) ManufacturerName[a1];
                }

                // Secondary Properties
                *(uint*) (bytePtrT + 0xD0) = BinKey;
                *(float*) (bytePtrT + 0xD4) = HeadlightFOV;
                *(bytePtrT + 0xD8) = PadHighPerformance;
                *(bytePtrT + 0xD9) = NumAvailableSkinNumbers;
                *(bytePtrT + 0xDA) = WhatGame;
                *(bytePtrT + 0xDB) = ConvertibleFlag;
                *(bytePtrT + 0xDC) = WheelOuterRadius;
                *(bytePtrT + 0xDD) = WheelInnerRadiusMin;
                *(bytePtrT + 0xDE) = WheelInnerRadiusMax;
                *(bytePtrT + 0xDF) = Padding0;

                // Vectors
                *(float*) (bytePtrT + 0xE0) = HeadlightPositionX;
                *(float*) (bytePtrT + 0xE4) = HeadlightPositionY;
                *(float*) (bytePtrT + 0xE8) = HeadlightPositionZ;
                *(float*) (bytePtrT + 0xEC) = HeadlightPositionW;
                *(float*) (bytePtrT + 0xF0) = DriverRenderingOffsetX;
                *(float*) (bytePtrT + 0xF4) = DriverRenderingOffsetY;
                *(float*) (bytePtrT + 0xF8) = DriverRenderingOffsetZ;
                *(float*) (bytePtrT + 0xFC) = DriverRenderingOffsetW;
                *(float*) (bytePtrT + 0x100) = SteeringWheelRenderingX;
                *(float*) (bytePtrT + 0x104) = SteeringWheelRenderingY;
                *(float*) (bytePtrT + 0x108) = SteeringWheelRenderingZ;
                *(float*) (bytePtrT + 0x10C) = SteeringWheelRenderingW;
                *(float*) (bytePtrT + 0x110) = UnknownVectorValX;
                *(float*) (bytePtrT + 0x114) = UnknownVectorValY;
                *(float*) (bytePtrT + 0x118) = UnknownVectorValZ;
                *(float*) (bytePtrT + 0x11C) = UnknownVectorValW;

                // Front Left Wheel
                *(float*) (bytePtrT + 0x120) = WHEEL_FRONT_LEFT.XValue;
                *(float*) (bytePtrT + 0x124) = WHEEL_FRONT_LEFT.Springs;
                *(float*) (bytePtrT + 0x128) = WHEEL_FRONT_LEFT.RideHeight;
                *(float*) (bytePtrT + 0x12C) = WHEEL_FRONT_LEFT.UnknownVal;
                *(float*) (bytePtrT + 0x130) = WHEEL_FRONT_LEFT.Diameter;
                *(float*) (bytePtrT + 0x134) = WHEEL_FRONT_LEFT.TireSkidWidth;
                *(int*) (bytePtrT + 0x138) = WHEEL_FRONT_LEFT.WheelID;
                *(float*) (bytePtrT + 0x13C) = WHEEL_FRONT_LEFT.YValue;
                *(float*) (bytePtrT + 0x140) = WHEEL_FRONT_LEFT.WideBodyYValue;

                // Front Left Wheel
                *(float*) (bytePtrT + 0x150) = WHEEL_FRONT_RIGHT.XValue;
                *(float*) (bytePtrT + 0x154) = WHEEL_FRONT_RIGHT.Springs;
                *(float*) (bytePtrT + 0x158) = WHEEL_FRONT_RIGHT.RideHeight;
                *(float*) (bytePtrT + 0x15C) = WHEEL_FRONT_RIGHT.UnknownVal;
                *(float*) (bytePtrT + 0x160) = WHEEL_FRONT_RIGHT.Diameter;
                *(float*) (bytePtrT + 0x164) = WHEEL_FRONT_RIGHT.TireSkidWidth;
                *(int*) (bytePtrT + 0x168) = WHEEL_FRONT_RIGHT.WheelID;
                *(float*) (bytePtrT + 0x16C) = WHEEL_FRONT_RIGHT.YValue;
                *(float*) (bytePtrT + 0x170) = WHEEL_FRONT_RIGHT.WideBodyYValue;

                // Front Left Wheel
                *(float*) (bytePtrT + 0x180) = WHEEL_REAR_RIGHT.XValue;
                *(float*) (bytePtrT + 0x184) = WHEEL_REAR_RIGHT.Springs;
                *(float*) (bytePtrT + 0x188) = WHEEL_REAR_RIGHT.RideHeight;
                *(float*) (bytePtrT + 0x18C) = WHEEL_REAR_RIGHT.UnknownVal;
                *(float*) (bytePtrT + 0x190) = WHEEL_REAR_RIGHT.Diameter;
                *(float*) (bytePtrT + 0x194) = WHEEL_REAR_RIGHT.TireSkidWidth;
                *(int*) (bytePtrT + 0x198) = WHEEL_REAR_RIGHT.WheelID;
                *(float*) (bytePtrT + 0x19C) = WHEEL_REAR_RIGHT.YValue;
                *(float*) (bytePtrT + 0x1A0) = WHEEL_REAR_RIGHT.WideBodyYValue;

                // Front Left Wheel
                *(float*) (bytePtrT + 0x1B0) = WHEEL_REAR_LEFT.XValue;
                *(float*) (bytePtrT + 0x1B4) = WHEEL_REAR_LEFT.Springs;
                *(float*) (bytePtrT + 0x1B8) = WHEEL_REAR_LEFT.RideHeight;
                *(float*) (bytePtrT + 0x1BC) = WHEEL_REAR_LEFT.UnknownVal;
                *(float*) (bytePtrT + 0x1C0) = WHEEL_REAR_LEFT.Diameter;
                *(float*) (bytePtrT + 0x1C4) = WHEEL_REAR_LEFT.TireSkidWidth;
                *(int*) (bytePtrT + 0x1C8) = WHEEL_REAR_LEFT.WheelID;
                *(float*) (bytePtrT + 0x1CC) = WHEEL_REAR_LEFT.YValue;
                *(float*) (bytePtrT + 0x1D0) = WHEEL_REAR_LEFT.WideBodyYValue;

                // Base Tires Performance
                *(float*) (bytePtrT + 0x1E0) = BASE_TIRES.StaticGripScale;
                *(float*) (bytePtrT + 0x1E4) = BASE_TIRES.YawSpeedScale;
                *(float*) (bytePtrT + 0x1E8) = BASE_TIRES.SteeringAmplifier;
                *(float*) (bytePtrT + 0x1EC) = BASE_TIRES.DynamicGripScale;
                *(float*) (bytePtrT + 0x1F0) = BASE_TIRES.SteeringResponse;
                *(float*) (bytePtrT + 0x200) = BASE_TIRES.DriftYawControl;
                *(float*) (bytePtrT + 0x204) = BASE_TIRES.DriftCounterSteerBuildUp;
                *(float*) (bytePtrT + 0x208) = BASE_TIRES.DriftCounterSteerReduction;
                *(float*) (bytePtrT + 0x20C) = BASE_TIRES.PowerSlideBreakThru1;
                *(float*) (bytePtrT + 0x210) = BASE_TIRES.PowerSlideBreakThru2;

                // Pvehicle Values
                *(float*) (bytePtrT + 0x220) = PVEHICLE.Massx1000Multiplier;
                *(float*) (bytePtrT + 0x224) = PVEHICLE.TensorScaleX;
                *(float*) (bytePtrT + 0x228) = PVEHICLE.TensorScaleY;
                *(float*) (bytePtrT + 0x22C) = PVEHICLE.TensorScaleZ;
                *(float*) (bytePtrT + 0x230) = PVEHICLE.TensorScaleW;
                *(float*) (bytePtrT + 0x270) = PVEHICLE.InitialHandlingRating;
                *(float*) (bytePtrT + 0x370) = PVEHICLE.TopSpeedUnderflow;
                *(float*) (bytePtrT + 0x3A0) = PVEHICLE.StockTopSpeedLimiter;

                // Ecar Values
                *(float*) (bytePtrT + 0x244) = ECAR.EcarUnknown1;
                *(float*) (bytePtrT + 0x258) = ECAR.EcarUnknown2;
                *(float*) (bytePtrT + 0x26C) = Float1Pt0;
                *(float*) (bytePtrT + 0x394) = Float2Pt5;
                *(float*) (bytePtrT + 0x398) = Float17Pt0;
                *(float*) (bytePtrT + 0x710) = ECAR.HandlingBuffer;
                *(float*) (bytePtrT + 0x714) = ECAR.TopSuspFrontHeightReduce;
                *(float*) (bytePtrT + 0x718) = ECAR.TopSuspRearHeightReduce;
                *(int*) (bytePtrT + 0x720) = ECAR.NumPlayerCameras;
                *(int*) (bytePtrT + 0x724) = ECAR.NumAICameras;
                *(int*) (bytePtrT + 0x87C) = ECAR.Cost;

                // Base Suspension Performance
                *(float*) (bytePtrT + 0x280) = BASE_SUSPENSION.ShockStiffnessFront;
                *(float*) (bytePtrT + 0x284) = BASE_SUSPENSION.ShockExtStiffnessFront;
                *(float*) (bytePtrT + 0x288) = BASE_SUSPENSION.SpringProgressionFront;
                *(float*) (bytePtrT + 0x28C) = BASE_SUSPENSION.ShockValvingFront;
                *(float*) (bytePtrT + 0x290) = BASE_SUSPENSION.SwayBarFront;
                *(float*) (bytePtrT + 0x294) = BASE_SUSPENSION.TrackWidthFront;
                *(float*) (bytePtrT + 0x298) = BASE_SUSPENSION.CounterBiasFront;
                *(float*) (bytePtrT + 0x29C) = BASE_SUSPENSION.ShockDigressionFront;
                *(float*) (bytePtrT + 0x2A0) = BASE_SUSPENSION.ShockStiffnessRear;
                *(float*) (bytePtrT + 0x2A4) = BASE_SUSPENSION.ShockExtStiffnessRear;
                *(float*) (bytePtrT + 0x2A8) = BASE_SUSPENSION.SpringProgressionRear;
                *(float*) (bytePtrT + 0x2AC) = BASE_SUSPENSION.ShockValvingRear;
                *(float*) (bytePtrT + 0x2B0) = BASE_SUSPENSION.SwayBarRear;
                *(float*) (bytePtrT + 0x2B4) = BASE_SUSPENSION.TrackWidthRear;
                *(float*) (bytePtrT + 0x2B8) = BASE_SUSPENSION.CounterBiasRear;
                *(float*) (bytePtrT + 0x2BC) = BASE_SUSPENSION.ShockDigressionRear;

                // Base Transmission Performance
                *(float*) (bytePtrT + 0x2C0) = BASE_TRANSMISSION.ClutchSlip;
                *(float*) (bytePtrT + 0x2C4) = BASE_TRANSMISSION.OptimalShift;
                *(float*) (bytePtrT + 0x2C8) = BASE_TRANSMISSION.FinalDriveRatio;
                *(float*) (bytePtrT + 0x2CC) = BASE_TRANSMISSION.FinalDriveRatio2;
                *(float*) (bytePtrT + 0x2D0) = BASE_TRANSMISSION.TorqueSplit;
                *(float*) (bytePtrT + 0x2D4) = BASE_TRANSMISSION.BurnoutStrength;
                *(int*) (bytePtrT + 0x2D8) = BASE_TRANSMISSION.NumberOfGears;
                *(float*) (bytePtrT + 0x2DC) = BASE_TRANSMISSION.GearEfficiency;
                *(float*) (bytePtrT + 0x2E0) = BASE_TRANSMISSION.GearRatioR;
                *(float*) (bytePtrT + 0x2E4) = BASE_TRANSMISSION.GearRatioN;
                *(float*) (bytePtrT + 0x2E8) = BASE_TRANSMISSION.GearRatio1;
                *(float*) (bytePtrT + 0x2EC) = BASE_TRANSMISSION.GearRatio2;
                *(float*) (bytePtrT + 0x2F0) = BASE_TRANSMISSION.GearRatio3;
                *(float*) (bytePtrT + 0x2F4) = BASE_TRANSMISSION.GearRatio4;
                *(float*) (bytePtrT + 0x2F8) = BASE_TRANSMISSION.GearRatio5;
                *(float*) (bytePtrT + 0x2FC) = BASE_TRANSMISSION.GearRatio6;

                // Base RPM Performance
                *(float*) (bytePtrT + 0x300) = BASE_RPM.IdleRPMAdd;
                *(float*) (bytePtrT + 0x304) = BASE_RPM.RedLineRPMAdd;
                *(float*) (bytePtrT + 0x308) = BASE_RPM.MaxRPMAdd;

                // Base Engine Performance
                *(float*) (bytePtrT + 0x30C) = BASE_ENGINE.SpeedRefreshRate;
                *(float*) (bytePtrT + 0x310) = BASE_ENGINE.EngineTorque1;
                *(float*) (bytePtrT + 0x314) = BASE_ENGINE.EngineTorque2;
                *(float*) (bytePtrT + 0x318) = BASE_ENGINE.EngineTorque3;
                *(float*) (bytePtrT + 0x31C) = BASE_ENGINE.EngineTorque4;
                *(float*) (bytePtrT + 0x320) = BASE_ENGINE.EngineTorque5;
                *(float*) (bytePtrT + 0x324) = BASE_ENGINE.EngineTorque6;
                *(float*) (bytePtrT + 0x328) = BASE_ENGINE.EngineTorque7;
                *(float*) (bytePtrT + 0x32C) = BASE_ENGINE.EngineTorque8;
                *(float*) (bytePtrT + 0x330) = BASE_ENGINE.EngineTorque9;
                *(float*) (bytePtrT + 0x334) = BASE_ENGINE.EngineBraking1;
                *(float*) (bytePtrT + 0x338) = BASE_ENGINE.EngineBraking2;
                *(float*) (bytePtrT + 0x33C) = BASE_ENGINE.EngineBraking3;

                // Base Turbo Performance
                *(float*) (bytePtrT + 0x340) = BASE_TURBO.TurboBraking;
                *(float*) (bytePtrT + 0x344) = BASE_TURBO.TurboVacuum;
                *(float*) (bytePtrT + 0x348) = BASE_TURBO.TurboHeatHigh;
                *(float*) (bytePtrT + 0x34C) = BASE_TURBO.TurboHeatLow;
                *(float*) (bytePtrT + 0x350) = BASE_TURBO.TurboHighBoost;
                *(float*) (bytePtrT + 0x354) = BASE_TURBO.TurboLowBoost;
                *(float*) (bytePtrT + 0x358) = BASE_TURBO.TurboSpool;
                *(float*) (bytePtrT + 0x35C) = BASE_TURBO.TurboSpoolTimeDown;
                *(float*) (bytePtrT + 0x360) = BASE_TURBO.TurboSpoolTimeUp;

                // Base Brakes Performance
                *(float*) (bytePtrT + 0x374) = BASE_BRAKES.FrontDownForce;
                *(float*) (bytePtrT + 0x378) = BASE_BRAKES.RearDownForce;
                *(float*) (bytePtrT + 0x37C) = BASE_BRAKES.BumpJumpForce;
                *(float*) (bytePtrT + 0x380) = BASE_BRAKES.SteeringRatio;
                *(float*) (bytePtrT + 0x384) = BASE_BRAKES.BrakeStrength;
                *(float*) (bytePtrT + 0x388) = BASE_BRAKES.HandBrakeStrength;
                *(float*) (bytePtrT + 0x38C) = BASE_BRAKES.BrakeBias;

                // DriftAdditionalYawControl Performance
                *(float*) (bytePtrT + 0x3C0) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl1;
                *(float*) (bytePtrT + 0x3C4) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl2;
                *(float*) (bytePtrT + 0x3C8) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl3;
                *(float*) (bytePtrT + 0x3CC) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl4;
                *(float*) (bytePtrT + 0x3D0) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl5;
                *(float*) (bytePtrT + 0x3D4) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl6;
                *(float*) (bytePtrT + 0x3D8) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl7;
                *(float*) (bytePtrT + 0x3DC) = DRIFT_ADD_CONTROL.DriftAdditionalYawControl8;

                // Skip Street + Pro Engine and Street Turbo, 0x03E0 - 0x0450
                *(float*) (bytePtrT + 0x3E0) = TOP_ENGINE.EngineTorque1 / 3;
                *(float*) (bytePtrT + 0x3E4) = TOP_ENGINE.EngineTorque2 / 3;
                *(float*) (bytePtrT + 0x3E8) = TOP_ENGINE.EngineTorque3 / 3;
                *(float*) (bytePtrT + 0x3EC) = TOP_ENGINE.EngineTorque4 / 3;
                *(float*) (bytePtrT + 0x3F0) = TOP_ENGINE.EngineTorque5 / 3;
                *(float*) (bytePtrT + 0x3F4) = TOP_ENGINE.EngineTorque6 / 3;
                *(float*) (bytePtrT + 0x3F8) = TOP_ENGINE.EngineTorque7 / 3;
                *(float*) (bytePtrT + 0x3FC) = TOP_ENGINE.EngineTorque8 / 3;
                *(float*) (bytePtrT + 0x400) = TOP_ENGINE.EngineTorque9 / 3;
                *(float*) (bytePtrT + 0x404) = TOP_ENGINE.EngineTorque1 / 3;
                *(float*) (bytePtrT + 0x408) = TOP_ENGINE.EngineTorque2 / 3;
                *(float*) (bytePtrT + 0x40C) = TOP_ENGINE.EngineTorque3 / 3;
                *(float*) (bytePtrT + 0x410) = TOP_ENGINE.EngineTorque4 / 3;
                *(float*) (bytePtrT + 0x414) = TOP_ENGINE.EngineTorque5 / 3;
                *(float*) (bytePtrT + 0x418) = TOP_ENGINE.EngineTorque6 / 3;
                *(float*) (bytePtrT + 0x41C) = TOP_ENGINE.EngineTorque7 / 3;
                *(float*) (bytePtrT + 0x420) = TOP_ENGINE.EngineTorque8 / 3;
                *(float*) (bytePtrT + 0x424) = TOP_ENGINE.EngineTorque9 / 3;
                *(float*) (bytePtrT + 0x428) = TOP_TURBO.TurboBraking / 10;
                *(float*) (bytePtrT + 0x42C) = TOP_TURBO.TurboVacuum / 10;
                *(float*) (bytePtrT + 0x430) = TOP_TURBO.TurboHeatHigh / 10;
                *(float*) (bytePtrT + 0x434) = TOP_TURBO.TurboHeatLow / 10;
                *(float*) (bytePtrT + 0x438) = TOP_TURBO.TurboHighBoost / 10;
                *(float*) (bytePtrT + 0x43C) = TOP_TURBO.TurboLowBoost / 10;
                *(float*) (bytePtrT + 0x440) = TOP_TURBO.TurboSpool / 10;
                *(float*) (bytePtrT + 0x444) = TOP_TURBO.TurboSpoolTimeDown / 10;
                *(float*) (bytePtrT + 0x448) = TOP_TURBO.TurboSpoolTimeUp / 10;

                // Top Weight Reduction Performance
                *(float*) (bytePtrT + 0x450) = TOP_WEIGHT_REDUCTION.WeightReductionMassMultiplier;
                *(float*) (bytePtrT + 0x454) = TOP_WEIGHT_REDUCTION.WeightReductionGripAddon;
                *(float*) (bytePtrT + 0x458) = TOP_WEIGHT_REDUCTION.WeightReductionHandlingRating;

                // Street Transmission Performance
                *(float*) (bytePtrT + 0x460) = STREET_TRANSMISSION.ClutchSlip;
                *(float*) (bytePtrT + 0x464) = STREET_TRANSMISSION.OptimalShift;
                *(float*) (bytePtrT + 0x468) = STREET_TRANSMISSION.FinalDriveRatio;
                *(float*) (bytePtrT + 0x46C) = STREET_TRANSMISSION.FinalDriveRatio2;
                *(float*) (bytePtrT + 0x470) = STREET_TRANSMISSION.TorqueSplit;
                *(float*) (bytePtrT + 0x474) = STREET_TRANSMISSION.BurnoutStrength;
                *(int*) (bytePtrT + 0x478) = STREET_TRANSMISSION.NumberOfGears;
                *(float*) (bytePtrT + 0x47C) = STREET_TRANSMISSION.GearEfficiency;
                *(float*) (bytePtrT + 0x480) = STREET_TRANSMISSION.GearRatioR;
                *(float*) (bytePtrT + 0x484) = STREET_TRANSMISSION.GearRatioN;
                *(float*) (bytePtrT + 0x488) = STREET_TRANSMISSION.GearRatio1;
                *(float*) (bytePtrT + 0x48C) = STREET_TRANSMISSION.GearRatio2;
                *(float*) (bytePtrT + 0x490) = STREET_TRANSMISSION.GearRatio3;
                *(float*) (bytePtrT + 0x494) = STREET_TRANSMISSION.GearRatio4;
                *(float*) (bytePtrT + 0x498) = STREET_TRANSMISSION.GearRatio5;
                *(float*) (bytePtrT + 0x49C) = STREET_TRANSMISSION.GearRatio6;

                // Pro Transmission Performance
                *(float*) (bytePtrT + 0x4A0) = PRO_TRANSMISSION.ClutchSlip;
                *(float*) (bytePtrT + 0x4A4) = PRO_TRANSMISSION.OptimalShift;
                *(float*) (bytePtrT + 0x4A8) = PRO_TRANSMISSION.FinalDriveRatio;
                *(float*) (bytePtrT + 0x4AC) = PRO_TRANSMISSION.FinalDriveRatio2;
                *(float*) (bytePtrT + 0x4B0) = PRO_TRANSMISSION.TorqueSplit;
                *(float*) (bytePtrT + 0x4B4) = PRO_TRANSMISSION.BurnoutStrength;
                *(int*) (bytePtrT + 0x4B8) = PRO_TRANSMISSION.NumberOfGears;
                *(float*) (bytePtrT + 0x4BC) = PRO_TRANSMISSION.GearEfficiency;
                *(float*) (bytePtrT + 0x4C0) = PRO_TRANSMISSION.GearRatioR;
                *(float*) (bytePtrT + 0x4C4) = PRO_TRANSMISSION.GearRatioN;
                *(float*) (bytePtrT + 0x4C8) = PRO_TRANSMISSION.GearRatio1;
                *(float*) (bytePtrT + 0x4CC) = PRO_TRANSMISSION.GearRatio2;
                *(float*) (bytePtrT + 0x4D0) = PRO_TRANSMISSION.GearRatio3;
                *(float*) (bytePtrT + 0x4D4) = PRO_TRANSMISSION.GearRatio4;
                *(float*) (bytePtrT + 0x4D8) = PRO_TRANSMISSION.GearRatio5;
                *(float*) (bytePtrT + 0x4DC) = PRO_TRANSMISSION.GearRatio6;

                // Top Transmission Performance
                *(float*) (bytePtrT + 0x4E0) = TOP_TRANSMISSION.ClutchSlip;
                *(float*) (bytePtrT + 0x4E4) = TOP_TRANSMISSION.OptimalShift;
                *(float*) (bytePtrT + 0x4E8) = TOP_TRANSMISSION.FinalDriveRatio;
                *(float*) (bytePtrT + 0x4EC) = TOP_TRANSMISSION.FinalDriveRatio2;
                *(float*) (bytePtrT + 0x4F0) = TOP_TRANSMISSION.TorqueSplit;
                *(float*) (bytePtrT + 0x4F4) = TOP_TRANSMISSION.BurnoutStrength;
                *(int*) (bytePtrT + 0x4F8) = TOP_TRANSMISSION.NumberOfGears;
                *(float*) (bytePtrT + 0x4FC) = TOP_TRANSMISSION.GearEfficiency;
                *(float*) (bytePtrT + 0x500) = TOP_TRANSMISSION.GearRatioR;
                *(float*) (bytePtrT + 0x504) = TOP_TRANSMISSION.GearRatioN;
                *(float*) (bytePtrT + 0x508) = TOP_TRANSMISSION.GearRatio1;
                *(float*) (bytePtrT + 0x50C) = TOP_TRANSMISSION.GearRatio2;
                *(float*) (bytePtrT + 0x510) = TOP_TRANSMISSION.GearRatio3;
                *(float*) (bytePtrT + 0x514) = TOP_TRANSMISSION.GearRatio4;
                *(float*) (bytePtrT + 0x518) = TOP_TRANSMISSION.GearRatio5;
                *(float*) (bytePtrT + 0x51C) = TOP_TRANSMISSION.GearRatio6;

                // Top Engine Performance
                *(float*) (bytePtrT + 0x52C) = TOP_ENGINE.SpeedRefreshRate;
                *(float*) (bytePtrT + 0x530) = TOP_ENGINE.EngineTorque1;
                *(float*) (bytePtrT + 0x534) = TOP_ENGINE.EngineTorque2;
                *(float*) (bytePtrT + 0x538) = TOP_ENGINE.EngineTorque3;
                *(float*) (bytePtrT + 0x53C) = TOP_ENGINE.EngineTorque4;
                *(float*) (bytePtrT + 0x540) = TOP_ENGINE.EngineTorque5;
                *(float*) (bytePtrT + 0x544) = TOP_ENGINE.EngineTorque6;
                *(float*) (bytePtrT + 0x548) = TOP_ENGINE.EngineTorque7;
                *(float*) (bytePtrT + 0x54C) = TOP_ENGINE.EngineTorque8;
                *(float*) (bytePtrT + 0x550) = TOP_ENGINE.EngineTorque9;
                *(float*) (bytePtrT + 0x554) = TOP_ENGINE.EngineBraking1;
                *(float*) (bytePtrT + 0x558) = TOP_ENGINE.EngineBraking2;
                *(float*) (bytePtrT + 0x55C) = TOP_ENGINE.EngineBraking3;

                // Street RPM Performance
                *(float*) (bytePtrT + 0x560) = STREET_RPM.IdleRPMAdd;
                *(float*) (bytePtrT + 0x564) = STREET_RPM.RedLineRPMAdd;
                *(float*) (bytePtrT + 0x568) = STREET_RPM.MaxRPMAdd;
                *(float*) (bytePtrT + 0x56C) = TOP_ENGINE.SpeedRefreshRate / 3;

                // Street ECU Performance
                *(float*) (bytePtrT + 0x570) = STREET_ECU.ECUx1000Add;
                *(float*) (bytePtrT + 0x574) = STREET_ECU.ECUx2000Add;
                *(float*) (bytePtrT + 0x578) = STREET_ECU.ECUx3000Add;
                *(float*) (bytePtrT + 0x57C) = STREET_ECU.ECUx4000Add;
                *(float*) (bytePtrT + 0x580) = STREET_ECU.ECUx5000Add;
                *(float*) (bytePtrT + 0x584) = STREET_ECU.ECUx6000Add;
                *(float*) (bytePtrT + 0x588) = STREET_ECU.ECUx7000Add;
                *(float*) (bytePtrT + 0x58C) = STREET_ECU.ECUx8000Add;
                *(float*) (bytePtrT + 0x590) = STREET_ECU.ECUx9000Add;
                *(float*) (bytePtrT + 0x594) = STREET_ECU.ECUx10000Add;
                *(float*) (bytePtrT + 0x598) = STREET_ECU.ECUx11000Add;
                *(float*) (bytePtrT + 0x59C) = STREET_ECU.ECUx12000Add;

                // Pro RPM Performance
                *(float*) (bytePtrT + 0x5A0) = PRO_RPM.IdleRPMAdd;
                *(float*) (bytePtrT + 0x5A4) = PRO_RPM.RedLineRPMAdd;
                *(float*) (bytePtrT + 0x5A8) = PRO_RPM.MaxRPMAdd;
                *(float*) (bytePtrT + 0x5AC) = TOP_ENGINE.SpeedRefreshRate * 2 / 3;

                // Pro ECU Performance
                *(float*) (bytePtrT + 0x5B0) = PRO_ECU.ECUx1000Add;
                *(float*) (bytePtrT + 0x5B4) = PRO_ECU.ECUx2000Add;
                *(float*) (bytePtrT + 0x5B8) = PRO_ECU.ECUx3000Add;
                *(float*) (bytePtrT + 0x5BC) = PRO_ECU.ECUx4000Add;
                *(float*) (bytePtrT + 0x5C0) = PRO_ECU.ECUx5000Add;
                *(float*) (bytePtrT + 0x5C4) = PRO_ECU.ECUx6000Add;
                *(float*) (bytePtrT + 0x5C8) = PRO_ECU.ECUx7000Add;
                *(float*) (bytePtrT + 0x5CC) = PRO_ECU.ECUx8000Add;
                *(float*) (bytePtrT + 0x5D0) = PRO_ECU.ECUx9000Add;
                *(float*) (bytePtrT + 0x5D4) = PRO_ECU.ECUx10000Add;
                *(float*) (bytePtrT + 0x5D8) = PRO_ECU.ECUx11000Add;
                *(float*) (bytePtrT + 0x5DC) = PRO_ECU.ECUx12000Add;

                // Top RPM Performance
                *(float*) (bytePtrT + 0x5E0) = TOP_RPM.IdleRPMAdd;
                *(float*) (bytePtrT + 0x5E4) = TOP_RPM.RedLineRPMAdd;
                *(float*) (bytePtrT + 0x5E8) = TOP_RPM.MaxRPMAdd;
                *(float*) (bytePtrT + 0x5EC) = TOP_ENGINE.SpeedRefreshRate;

                // Top ECU Performance
                *(float*) (bytePtrT + 0x5F0) = TOP_ECU.ECUx1000Add;
                *(float*) (bytePtrT + 0x5F4) = TOP_ECU.ECUx2000Add;
                *(float*) (bytePtrT + 0x5F8) = TOP_ECU.ECUx3000Add;
                *(float*) (bytePtrT + 0x5FC) = TOP_ECU.ECUx4000Add;
                *(float*) (bytePtrT + 0x600) = TOP_ECU.ECUx5000Add;
                *(float*) (bytePtrT + 0x604) = TOP_ECU.ECUx6000Add;
                *(float*) (bytePtrT + 0x608) = TOP_ECU.ECUx7000Add;
                *(float*) (bytePtrT + 0x60C) = TOP_ECU.ECUx8000Add;
                *(float*) (bytePtrT + 0x610) = TOP_ECU.ECUx9000Add;
                *(float*) (bytePtrT + 0x614) = TOP_ECU.ECUx10000Add;
                *(float*) (bytePtrT + 0x618) = TOP_ECU.ECUx11000Add;
                *(float*) (bytePtrT + 0x61C) = TOP_ECU.ECUx12000Add;

                // Top Turbo Performance
                *(float*) (bytePtrT + 0x620) = TOP_TURBO.TurboBraking;
                *(float*) (bytePtrT + 0x624) = TOP_TURBO.TurboVacuum;
                *(float*) (bytePtrT + 0x628) = TOP_TURBO.TurboHeatHigh;
                *(float*) (bytePtrT + 0x62C) = TOP_TURBO.TurboHeatLow;
                *(float*) (bytePtrT + 0x630) = TOP_TURBO.TurboHighBoost;
                *(float*) (bytePtrT + 0x634) = TOP_TURBO.TurboLowBoost;
                *(float*) (bytePtrT + 0x638) = TOP_TURBO.TurboSpool;
                *(float*) (bytePtrT + 0x63C) = TOP_TURBO.TurboSpoolTimeDown;
                *(float*) (bytePtrT + 0x640) = TOP_TURBO.TurboSpoolTimeUp;

                // Top Tires Performance
                *(float*) (bytePtrT + 0x650) = TOP_TIRES.StaticGripScale;
                *(float*) (bytePtrT + 0x654) = TOP_TIRES.YawSpeedScale;
                *(float*) (bytePtrT + 0x658) = TOP_TIRES.SteeringAmplifier;
                *(float*) (bytePtrT + 0x65C) = TOP_TIRES.DynamicGripScale;
                *(float*) (bytePtrT + 0x660) = TOP_TIRES.SteeringResponse;
                *(float*) (bytePtrT + 0x670) = TOP_TIRES.DriftYawControl;
                *(float*) (bytePtrT + 0x674) = TOP_TIRES.DriftCounterSteerBuildUp;
                *(float*) (bytePtrT + 0x678) = TOP_TIRES.DriftCounterSteerReduction;
                *(float*) (bytePtrT + 0x67C) = TOP_TIRES.PowerSlideBreakThru1;
                *(float*) (bytePtrT + 0x680) = TOP_TIRES.PowerSlideBreakThru2;

                // Top Nitrous Performance
                *(float*) (bytePtrT + 0x690) = TOP_NITROUS.NOSCapacity;
                *(int*) (bytePtrT + 0x694) = Int326;
                *(float*) (bytePtrT + 0x69C) = TOP_NITROUS.NOSTorqueBoost;

                // Top Brakes Performance
                *(float*) (bytePtrT + 0x6A0) = 0;
                *(float*) (bytePtrT + 0x6A4) = TOP_BRAKES.RearDownForce;
                *(float*) (bytePtrT + 0x6A8) = TOP_BRAKES.BumpJumpForce;
                *(float*) (bytePtrT + 0x6B0) = TOP_BRAKES.FrontDownForce;
                *(float*) (bytePtrT + 0x6B4) = TOP_BRAKES.RearDownForce;
                *(float*) (bytePtrT + 0x6B8) = TOP_BRAKES.BumpJumpForce;
                *(float*) (bytePtrT + 0x6C0) = TOP_BRAKES.BrakeStrength;
                *(float*) (bytePtrT + 0x6C4) = TOP_BRAKES.HandBrakeStrength;
                *(float*) (bytePtrT + 0x6C8) = TOP_BRAKES.BrakeBias;
                *(float*) (bytePtrT + 0x6CC) = TOP_BRAKES.SteeringRatio;

                // Top Suspension Performance
                *(float*) (bytePtrT + 0x6D0) = TOP_SUSPENSION.ShockStiffnessFront;
                *(float*) (bytePtrT + 0x6D4) = TOP_SUSPENSION.ShockExtStiffnessFront;
                *(float*) (bytePtrT + 0x6D8) = TOP_SUSPENSION.SpringProgressionFront;
                *(float*) (bytePtrT + 0x6DC) = TOP_SUSPENSION.ShockValvingFront;
                *(float*) (bytePtrT + 0x6E0) = TOP_SUSPENSION.SwayBarFront;
                *(float*) (bytePtrT + 0x6E4) = TOP_SUSPENSION.TrackWidthFront;
                *(float*) (bytePtrT + 0x6E8) = TOP_SUSPENSION.CounterBiasFront;
                *(float*) (bytePtrT + 0x6EC) = TOP_SUSPENSION.ShockDigressionFront;
                *(float*) (bytePtrT + 0x6F0) = TOP_SUSPENSION.ShockStiffnessRear;
                *(float*) (bytePtrT + 0x6F4) = TOP_SUSPENSION.ShockExtStiffnessRear;
                *(float*) (bytePtrT + 0x6F8) = TOP_SUSPENSION.SpringProgressionRear;
                *(float*) (bytePtrT + 0x6FC) = TOP_SUSPENSION.ShockValvingRear;
                *(float*) (bytePtrT + 0x700) = TOP_SUSPENSION.SwayBarRear;
                *(float*) (bytePtrT + 0x704) = TOP_SUSPENSION.TrackWidthRear;
                *(float*) (bytePtrT + 0x708) = TOP_SUSPENSION.CounterBiasRear;
                *(float*) (bytePtrT + 0x70C) = TOP_SUSPENSION.ShockDigressionRear;

                // Player Cameras
                *(short*) (bytePtrT + 0x730) = (short) eCameraType.FAR;
                *(short*) (bytePtrT + 0x732) = (short) (PLAYER_CAMERA_FAR.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x734) = PLAYER_CAMERA_FAR.CameraLag;
                *(float*) (bytePtrT + 0x738) = PLAYER_CAMERA_FAR.CameraHeight;
                *(float*) (bytePtrT + 0x73C) = PLAYER_CAMERA_FAR.CameraLatOffset;
                *(short*) (bytePtrT + 0x740) = (short) eCameraType.CLOSE;
                *(short*) (bytePtrT + 0x742) = (short) (PLAYER_CAMERA_CLOSE.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x744) = PLAYER_CAMERA_CLOSE.CameraLag;
                *(float*) (bytePtrT + 0x748) = PLAYER_CAMERA_CLOSE.CameraHeight;
                *(float*) (bytePtrT + 0x74C) = PLAYER_CAMERA_CLOSE.CameraLatOffset;
                *(short*) (bytePtrT + 0x750) = (short) eCameraType.BUMPER;
                *(short*) (bytePtrT + 0x752) = (short) (PLAYER_CAMERA_BUMPER.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x754) = PLAYER_CAMERA_BUMPER.CameraLag;
                *(float*) (bytePtrT + 0x758) = PLAYER_CAMERA_BUMPER.CameraHeight;
                *(float*) (bytePtrT + 0x75C) = PLAYER_CAMERA_BUMPER.CameraLatOffset;
                *(short*) (bytePtrT + 0x760) = (short) eCameraType.DRIVER;
                *(short*) (bytePtrT + 0x762) = (short) (PLAYER_CAMERA_DRIVER.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x764) = PLAYER_CAMERA_DRIVER.CameraLag;
                *(float*) (bytePtrT + 0x768) = PLAYER_CAMERA_DRIVER.CameraHeight;
                *(float*) (bytePtrT + 0x76C) = PLAYER_CAMERA_DRIVER.CameraLatOffset;
                *(short*) (bytePtrT + 0x770) = (short) eCameraType.HOOD;
                *(short*) (bytePtrT + 0x772) = (short) (PLAYER_CAMERA_HOOD.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x774) = PLAYER_CAMERA_HOOD.CameraLag;
                *(float*) (bytePtrT + 0x778) = PLAYER_CAMERA_HOOD.CameraHeight;
                *(float*) (bytePtrT + 0x77C) = PLAYER_CAMERA_HOOD.CameraLatOffset;
                *(short*) (bytePtrT + 0x780) = (short) eCameraType.DRIFT;
                *(short*) (bytePtrT + 0x782) = (short) (PLAYER_CAMERA_DRIFT.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x784) = PLAYER_CAMERA_DRIFT.CameraLag;
                *(float*) (bytePtrT + 0x788) = PLAYER_CAMERA_DRIFT.CameraHeight;
                *(float*) (bytePtrT + 0x78C) = PLAYER_CAMERA_DRIFT.CameraLatOffset;

                // AI Cameras
                *(short*) (bytePtrT + 0x790) = (short) eCameraType.FAR;
                *(short*) (bytePtrT + 0x792) = (short) (AI_CAMERA_FAR.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x794) = AI_CAMERA_FAR.CameraLag;
                *(float*) (bytePtrT + 0x798) = AI_CAMERA_FAR.CameraHeight;
                *(float*) (bytePtrT + 0x79C) = AI_CAMERA_FAR.CameraLatOffset;
                *(short*) (bytePtrT + 0x7A0) = (short) eCameraType.CLOSE;
                *(short*) (bytePtrT + 0x7A2) = (short) (AI_CAMERA_CLOSE.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x7A4) = AI_CAMERA_CLOSE.CameraLag;
                *(float*) (bytePtrT + 0x7A8) = AI_CAMERA_CLOSE.CameraHeight;
                *(float*) (bytePtrT + 0x7AC) = AI_CAMERA_CLOSE.CameraLatOffset;
                *(short*) (bytePtrT + 0x7B0) = (short) eCameraType.BUMPER;
                *(short*) (bytePtrT + 0x7B2) = (short) (AI_CAMERA_BUMPER.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x7B4) = AI_CAMERA_BUMPER.CameraLag;
                *(float*) (bytePtrT + 0x7B8) = AI_CAMERA_BUMPER.CameraHeight;
                *(float*) (bytePtrT + 0x7BC) = AI_CAMERA_BUMPER.CameraLatOffset;
                *(short*) (bytePtrT + 0x7C0) = (short) eCameraType.DRIVER;
                *(short*) (bytePtrT + 0x7C2) = (short) (AI_CAMERA_DRIVER.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x7C4) = AI_CAMERA_DRIVER.CameraLag;
                *(float*) (bytePtrT + 0x7C8) = AI_CAMERA_DRIVER.CameraHeight;
                *(float*) (bytePtrT + 0x7CC) = AI_CAMERA_DRIVER.CameraLatOffset;
                *(short*) (bytePtrT + 0x7D0) = (short) eCameraType.HOOD;
                *(short*) (bytePtrT + 0x7D2) = (short) (AI_CAMERA_HOOD.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x7D4) = AI_CAMERA_HOOD.CameraLag;
                *(float*) (bytePtrT + 0x7D8) = AI_CAMERA_HOOD.CameraHeight;
                *(float*) (bytePtrT + 0x7DC) = AI_CAMERA_HOOD.CameraLatOffset;
                *(short*) (bytePtrT + 0x7E0) = (short) eCameraType.DRIFT;
                *(short*) (bytePtrT + 0x7E2) = (short) (AI_CAMERA_DRIFT.CameraAngle / 180 * 32768);
                *(float*) (bytePtrT + 0x7E4) = AI_CAMERA_DRIFT.CameraLag;
                *(float*) (bytePtrT + 0x7E8) = AI_CAMERA_DRIFT.CameraHeight;
                *(float*) (bytePtrT + 0x7EC) = AI_CAMERA_DRIFT.CameraLatOffset;

                // Rigid Controls (if an added car, or usage type modified, or rigid controls are missing or broken
                if (Deletable || Modified || _rigidControls is not {Length: 40})
                {
                    if (UsageType == eUsageType.Traffic)
                    {
                        for (var a1 = 0; a1 < 40; ++a1)
                            *(ushort*) (bytePtrT + 0x7F0 + a1 * 2) = RigidControls.RigidTrafControls[a1];
                    }
                    else
                    {
                        for (var a1 = 0; a1 < 40; ++a1)
                            *(ushort*) (bytePtrT + 0x7F0 + a1 * 2) = RigidControls.RigidRacerControls[a1];
                    }
                }
                else
                {
                    for (var a1 = 0; a1 < 40; ++a1)
                        *(ushort*) (bytePtrT + 0x7F0 + a1 * 2) = _rigidControls[a1];
                }

                // Secondary Properties
                *(int*) (bytePtrT + 0x840) = Index;
                *(int*) (bytePtrT + 0x844) = (int) UsageType;
                *(uint*) (bytePtrT + 0x84C) = Bin.Hash(_defaultBasePaint);
                *(uint*) (bytePtrT + 0x850) = Bin.Hash(_defaultBasePaint2);
                *(bytePtrT + 0x854) = MaxInstances1;
                *(bytePtrT + 0x855) = MaxInstances2;
                *(bytePtrT + 0x856) = MaxInstances3;
                *(bytePtrT + 0x857) = MaxInstances4;
                *(bytePtrT + 0x858) = MaxInstances5;
                *(bytePtrT + 0x859) = KeepLoaded1;
                *(bytePtrT + 0x85A) = KeepLoaded1;
                *(bytePtrT + 0x85B) = KeepLoaded1;
                *(bytePtrT + 0x85C) = KeepLoaded1;
                *(bytePtrT + 0x85D) = KeepLoaded1;
                *(short*) (bytePtrT + 0x85E) = Padding1;
                *(float*) (bytePtrT + 0x860) = MinTimeBetweenUses1;
                *(float*) (bytePtrT + 0x864) = MinTimeBetweenUses2;
                *(float*) (bytePtrT + 0x868) = MinTimeBetweenUses3;
                *(float*) (bytePtrT + 0x86C) = MinTimeBetweenUses4;
                *(float*) (bytePtrT + 0x870) = MinTimeBetweenUses5;
                *(bytePtrT + 0x874) = DefaultSkinNumber;
                *(int*) (bytePtrT + 0x878) = Padding2;
                *(bytePtrT + 0x880) = AvailableSkinNumbers01;
                *(bytePtrT + 0x881) = AvailableSkinNumbers02;
                *(bytePtrT + 0x882) = AvailableSkinNumbers03;
                *(bytePtrT + 0x883) = AvailableSkinNumbers04;
                *(bytePtrT + 0x884) = AvailableSkinNumbers05;
                *(bytePtrT + 0x885) = AvailableSkinNumbers06;
                *(bytePtrT + 0x886) = AvailableSkinNumbers07;
                *(bytePtrT + 0x887) = AvailableSkinNumbers08;
                *(bytePtrT + 0x888) = AvailableSkinNumbers09;
                *(bytePtrT + 0x889) = AvailableSkinNumbers10;
                *(bytePtrT + 0x88A) = (byte) _isSuv;
                *(bytePtrT + 0x88C) = (byte) IsSkinnable;
            }

            return result;
        }
    }
}