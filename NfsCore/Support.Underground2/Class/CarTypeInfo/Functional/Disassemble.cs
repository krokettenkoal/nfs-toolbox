using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Disassembles cartypeinfo array into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the cartypeinfo array.</param>
        protected override unsafe void Disassemble(byte* bytePtrT)
        {
            // Manufacturer name
            var name = ScriptX.NullTerminatedString(bytePtrT + 0xC0, 0x10);
            ManufacturerName = string.IsNullOrWhiteSpace(name) ? BaseArguments.NULL : name;

            // Secondary Properties
            HeadlightFOV = *(float*) (bytePtrT + 0xD4);
            PadHighPerformance = *(bytePtrT + 0xD8);
            NumAvailableSkinNumbers = *(bytePtrT + 0xD9);
            WhatGame = *(bytePtrT + 0xDA);
            ConvertibleFlag = *(bytePtrT + 0xDB);
            WheelOuterRadius = *(bytePtrT + 0xDC);
            WheelInnerRadiusMin = *(bytePtrT + 0xDD);
            WheelInnerRadiusMax = *(bytePtrT + 0xDE);
            Padding0 = *(bytePtrT + 0xDF);

            // Vectors
            HeadlightPositionX = *(float*) (bytePtrT + 0xE0);
            HeadlightPositionY = *(float*) (bytePtrT + 0xE4);
            HeadlightPositionZ = *(float*) (bytePtrT + 0xE8);
            HeadlightPositionW = *(float*) (bytePtrT + 0xEC);
            DriverRenderingOffsetX = *(float*) (bytePtrT + 0xF0);
            DriverRenderingOffsetY = *(float*) (bytePtrT + 0xF4);
            DriverRenderingOffsetZ = *(float*) (bytePtrT + 0xF8);
            DriverRenderingOffsetW = *(float*) (bytePtrT + 0xFC);
            SteeringWheelRenderingX = *(float*) (bytePtrT + 0x100);
            SteeringWheelRenderingY = *(float*) (bytePtrT + 0x104);
            SteeringWheelRenderingZ = *(float*) (bytePtrT + 0x108);
            SteeringWheelRenderingW = *(float*) (bytePtrT + 0x10C);
            UnknownVectorValX = *(float*) (bytePtrT + 0x110);
            UnknownVectorValY = *(float*) (bytePtrT + 0x114);
            UnknownVectorValZ = *(float*) (bytePtrT + 0x118);
            UnknownVectorValW = *(float*) (bytePtrT + 0x11C);

            // Front Left Wheel
            WHEEL_FRONT_LEFT.XValue = *(float*) (bytePtrT + 0x120);
            WHEEL_FRONT_LEFT.Springs = *(float*) (bytePtrT + 0x124);
            WHEEL_FRONT_LEFT.RideHeight = *(float*) (bytePtrT + 0x128);
            WHEEL_FRONT_LEFT.UnknownVal = *(float*) (bytePtrT + 0x12C);
            WHEEL_FRONT_LEFT.Diameter = *(float*) (bytePtrT + 0x130);
            WHEEL_FRONT_LEFT.TireSkidWidth = *(float*) (bytePtrT + 0x134);
            WHEEL_FRONT_LEFT.WheelID = *(int*) (bytePtrT + 0x138);
            WHEEL_FRONT_LEFT.YValue = *(float*) (bytePtrT + 0x13C);
            WHEEL_FRONT_LEFT.WideBodyYValue = *(float*) (bytePtrT + 0x140);

            // Front Left Wheel
            WHEEL_FRONT_RIGHT.XValue = *(float*) (bytePtrT + 0x150);
            WHEEL_FRONT_RIGHT.Springs = *(float*) (bytePtrT + 0x154);
            WHEEL_FRONT_RIGHT.RideHeight = *(float*) (bytePtrT + 0x158);
            WHEEL_FRONT_RIGHT.UnknownVal = *(float*) (bytePtrT + 0x15C);
            WHEEL_FRONT_RIGHT.Diameter = *(float*) (bytePtrT + 0x160);
            WHEEL_FRONT_RIGHT.TireSkidWidth = *(float*) (bytePtrT + 0x164);
            WHEEL_FRONT_RIGHT.WheelID = *(int*) (bytePtrT + 0x168);
            WHEEL_FRONT_RIGHT.YValue = *(float*) (bytePtrT + 0x16C);
            WHEEL_FRONT_RIGHT.WideBodyYValue = *(float*) (bytePtrT + 0x170);

            // Front Left Wheel
            WHEEL_REAR_RIGHT.XValue = *(float*) (bytePtrT + 0x180);
            WHEEL_REAR_RIGHT.Springs = *(float*) (bytePtrT + 0x184);
            WHEEL_REAR_RIGHT.RideHeight = *(float*) (bytePtrT + 0x188);
            WHEEL_REAR_RIGHT.UnknownVal = *(float*) (bytePtrT + 0x18C);
            WHEEL_REAR_RIGHT.Diameter = *(float*) (bytePtrT + 0x190);
            WHEEL_REAR_RIGHT.TireSkidWidth = *(float*) (bytePtrT + 0x194);
            WHEEL_REAR_RIGHT.WheelID = *(int*) (bytePtrT + 0x198);
            WHEEL_REAR_RIGHT.YValue = *(float*) (bytePtrT + 0x19C);
            WHEEL_REAR_RIGHT.WideBodyYValue = *(float*) (bytePtrT + 0x1A0);

            // Front Left Wheel
            WHEEL_REAR_LEFT.XValue = *(float*) (bytePtrT + 0x1B0);
            WHEEL_REAR_LEFT.Springs = *(float*) (bytePtrT + 0x1B4);
            WHEEL_REAR_LEFT.RideHeight = *(float*) (bytePtrT + 0x1B8);
            WHEEL_REAR_LEFT.UnknownVal = *(float*) (bytePtrT + 0x1BC);
            WHEEL_REAR_LEFT.Diameter = *(float*) (bytePtrT + 0x1C0);
            WHEEL_REAR_LEFT.TireSkidWidth = *(float*) (bytePtrT + 0x1C4);
            WHEEL_REAR_LEFT.WheelID = *(int*) (bytePtrT + 0x1C8);
            WHEEL_REAR_LEFT.YValue = *(float*) (bytePtrT + 0x1CC);
            WHEEL_REAR_LEFT.WideBodyYValue = *(float*) (bytePtrT + 0x1D0);

            // Base Tires Performance
            BASE_TIRES.StaticGripScale = *(float*) (bytePtrT + 0x1E0);
            BASE_TIRES.YawSpeedScale = *(float*) (bytePtrT + 0x1E4);
            BASE_TIRES.SteeringAmplifier = *(float*) (bytePtrT + 0x1E8);
            BASE_TIRES.DynamicGripScale = *(float*) (bytePtrT + 0x1EC);
            BASE_TIRES.SteeringResponse = *(float*) (bytePtrT + 0x1F0);
            BASE_TIRES.DriftYawControl = *(float*) (bytePtrT + 0x200);
            BASE_TIRES.DriftCounterSteerBuildUp = *(float*) (bytePtrT + 0x204);
            BASE_TIRES.DriftCounterSteerReduction = *(float*) (bytePtrT + 0x208);
            BASE_TIRES.PowerSlideBreakThru1 = *(float*) (bytePtrT + 0x20C);
            BASE_TIRES.PowerSlideBreakThru2 = *(float*) (bytePtrT + 0x210);

            // Pvehicle Values
            PVEHICLE.Massx1000Multiplier = *(float*) (bytePtrT + 0x220);
            PVEHICLE.TensorScaleX = *(float*) (bytePtrT + 0x224);
            PVEHICLE.TensorScaleY = *(float*) (bytePtrT + 0x228);
            PVEHICLE.TensorScaleZ = *(float*) (bytePtrT + 0x22C);
            PVEHICLE.TensorScaleW = *(float*) (bytePtrT + 0x230);
            PVEHICLE.InitialHandlingRating = *(float*) (bytePtrT + 0x270);
            PVEHICLE.TopSpeedUnderflow = *(float*) (bytePtrT + 0x370);
            PVEHICLE.StockTopSpeedLimiter = *(float*) (bytePtrT + 0x3A0);

            // Ecar Values
            ECAR.EcarUnknown1 = *(float*) (bytePtrT + 0x244);
            ECAR.EcarUnknown2 = *(float*) (bytePtrT + 0x258);
            ECAR.HandlingBuffer = *(float*) (bytePtrT + 0x710);
            ECAR.TopSuspFrontHeightReduce = *(float*) (bytePtrT + 0x714);
            ECAR.TopSuspRearHeightReduce = *(float*) (bytePtrT + 0x718);
            ECAR.NumPlayerCameras = *(int*) (bytePtrT + 0x720);
            ECAR.NumAICameras = *(int*) (bytePtrT + 0x724);
            ECAR.Cost = *(int*) (bytePtrT + 0x87C);

            // Base Suspension Performance
            BASE_SUSPENSION.ShockStiffnessFront = *(float*) (bytePtrT + 0x280);
            BASE_SUSPENSION.ShockExtStiffnessFront = *(float*) (bytePtrT + 0x284);
            BASE_SUSPENSION.SpringProgressionFront = *(float*) (bytePtrT + 0x288);
            BASE_SUSPENSION.ShockValvingFront = *(float*) (bytePtrT + 0x28C);
            BASE_SUSPENSION.SwayBarFront = *(float*) (bytePtrT + 0x290);
            BASE_SUSPENSION.TrackWidthFront = *(float*) (bytePtrT + 0x294);
            BASE_SUSPENSION.CounterBiasFront = *(float*) (bytePtrT + 0x298);
            BASE_SUSPENSION.ShockDigressionFront = *(float*) (bytePtrT + 0x29C);
            BASE_SUSPENSION.ShockStiffnessRear = *(float*) (bytePtrT + 0x2A0);
            BASE_SUSPENSION.ShockExtStiffnessRear = *(float*) (bytePtrT + 0x2A4);
            BASE_SUSPENSION.SpringProgressionRear = *(float*) (bytePtrT + 0x2A8);
            BASE_SUSPENSION.ShockValvingRear = *(float*) (bytePtrT + 0x2AC);
            BASE_SUSPENSION.SwayBarRear = *(float*) (bytePtrT + 0x2B0);
            BASE_SUSPENSION.TrackWidthRear = *(float*) (bytePtrT + 0x2B4);
            BASE_SUSPENSION.CounterBiasRear = *(float*) (bytePtrT + 0x2B8);
            BASE_SUSPENSION.ShockDigressionRear = *(float*) (bytePtrT + 0x2BC);

            // Base Transmission Performance
            BASE_TRANSMISSION.ClutchSlip = *(float*) (bytePtrT + 0x2C0);
            BASE_TRANSMISSION.OptimalShift = *(float*) (bytePtrT + 0x2C4);
            BASE_TRANSMISSION.FinalDriveRatio = *(float*) (bytePtrT + 0x2C8);
            BASE_TRANSMISSION.FinalDriveRatio2 = *(float*) (bytePtrT + 0x2CC);
            BASE_TRANSMISSION.TorqueSplit = *(float*) (bytePtrT + 0x2D0);
            BASE_TRANSMISSION.BurnoutStrength = *(float*) (bytePtrT + 0x2D4);
            BASE_TRANSMISSION.NumberOfGears = *(int*) (bytePtrT + 0x2D8);
            BASE_TRANSMISSION.GearEfficiency = *(float*) (bytePtrT + 0x2DC);
            BASE_TRANSMISSION.GearRatioR = *(float*) (bytePtrT + 0x2E0);
            BASE_TRANSMISSION.GearRatioN = *(float*) (bytePtrT + 0x2E4);
            BASE_TRANSMISSION.GearRatio1 = *(float*) (bytePtrT + 0x2E8);
            BASE_TRANSMISSION.GearRatio2 = *(float*) (bytePtrT + 0x2EC);
            BASE_TRANSMISSION.GearRatio3 = *(float*) (bytePtrT + 0x2F0);
            BASE_TRANSMISSION.GearRatio4 = *(float*) (bytePtrT + 0x2F4);
            BASE_TRANSMISSION.GearRatio5 = *(float*) (bytePtrT + 0x2F8);
            BASE_TRANSMISSION.GearRatio6 = *(float*) (bytePtrT + 0x2FC);

            // Base RPM Performance
            BASE_RPM.IdleRPMAdd = *(float*) (bytePtrT + 0x300);
            BASE_RPM.RedLineRPMAdd = *(float*) (bytePtrT + 0x304);
            BASE_RPM.MaxRPMAdd = *(float*) (bytePtrT + 0x308);

            // Base Engine Performance
            BASE_ENGINE.SpeedRefreshRate = *(float*) (bytePtrT + 0x30C);
            BASE_ENGINE.EngineTorque1 = *(float*) (bytePtrT + 0x310);
            BASE_ENGINE.EngineTorque2 = *(float*) (bytePtrT + 0x314);
            BASE_ENGINE.EngineTorque3 = *(float*) (bytePtrT + 0x318);
            BASE_ENGINE.EngineTorque4 = *(float*) (bytePtrT + 0x31C);
            BASE_ENGINE.EngineTorque5 = *(float*) (bytePtrT + 0x320);
            BASE_ENGINE.EngineTorque6 = *(float*) (bytePtrT + 0x324);
            BASE_ENGINE.EngineTorque7 = *(float*) (bytePtrT + 0x328);
            BASE_ENGINE.EngineTorque8 = *(float*) (bytePtrT + 0x32C);
            BASE_ENGINE.EngineTorque9 = *(float*) (bytePtrT + 0x330);
            BASE_ENGINE.EngineBraking1 = *(float*) (bytePtrT + 0x334);
            BASE_ENGINE.EngineBraking2 = *(float*) (bytePtrT + 0x338);
            BASE_ENGINE.EngineBraking3 = *(float*) (bytePtrT + 0x33C);

            // Base Turbo Performance
            BASE_TURBO.TurboBraking = *(float*) (bytePtrT + 0x340);
            BASE_TURBO.TurboVacuum = *(float*) (bytePtrT + 0x344);
            BASE_TURBO.TurboHeatHigh = *(float*) (bytePtrT + 0x348);
            BASE_TURBO.TurboHeatLow = *(float*) (bytePtrT + 0x34C);
            BASE_TURBO.TurboHighBoost = *(float*) (bytePtrT + 0x350);
            BASE_TURBO.TurboLowBoost = *(float*) (bytePtrT + 0x354);
            BASE_TURBO.TurboSpool = *(float*) (bytePtrT + 0x358);
            BASE_TURBO.TurboSpoolTimeDown = *(float*) (bytePtrT + 0x35C);
            BASE_TURBO.TurboSpoolTimeUp = *(float*) (bytePtrT + 0x360);

            // Base Brakes Performance
            BASE_BRAKES.FrontDownForce = *(float*) (bytePtrT + 0x374);
            BASE_BRAKES.RearDownForce = *(float*) (bytePtrT + 0x378);
            BASE_BRAKES.BumpJumpForce = *(float*) (bytePtrT + 0x37C);
            BASE_BRAKES.SteeringRatio = *(float*) (bytePtrT + 0x380);
            BASE_BRAKES.BrakeStrength = *(float*) (bytePtrT + 0x384);
            BASE_BRAKES.HandBrakeStrength = *(float*) (bytePtrT + 0x388);
            BASE_BRAKES.BrakeBias = *(float*) (bytePtrT + 0x38C);

            // DriftAdditionalYawControl Performance
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl1 = *(float*) (bytePtrT + 0x3C0);
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl2 = *(float*) (bytePtrT + 0x3C4);
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl3 = *(float*) (bytePtrT + 0x3C8);
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl4 = *(float*) (bytePtrT + 0x3CC);
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl5 = *(float*) (bytePtrT + 0x3D0);
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl6 = *(float*) (bytePtrT + 0x3D4);
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl7 = *(float*) (bytePtrT + 0x3D8);
            DRIFT_ADD_CONTROL.DriftAdditionalYawControl8 = *(float*) (bytePtrT + 0x3DC);

            // Skip Street + Pro Engine and Street Turbo, 0x03E0 - 0x0450

            // Top Weight Reduction Performance
            TOP_WEIGHT_REDUCTION.WeightReductionMassMultiplier = *(float*) (bytePtrT + 0x450);
            TOP_WEIGHT_REDUCTION.WeightReductionGripAddon = *(float*) (bytePtrT + 0x454);
            TOP_WEIGHT_REDUCTION.WeightReductionHandlingRating = *(float*) (bytePtrT + 0x458);

            // Street Transmission Performance
            STREET_TRANSMISSION.ClutchSlip = *(float*) (bytePtrT + 0x460);
            STREET_TRANSMISSION.OptimalShift = *(float*) (bytePtrT + 0x464);
            STREET_TRANSMISSION.FinalDriveRatio = *(float*) (bytePtrT + 0x468);
            STREET_TRANSMISSION.FinalDriveRatio2 = *(float*) (bytePtrT + 0x46C);
            STREET_TRANSMISSION.TorqueSplit = *(float*) (bytePtrT + 0x470);
            STREET_TRANSMISSION.BurnoutStrength = *(float*) (bytePtrT + 0x474);
            STREET_TRANSMISSION.NumberOfGears = *(int*) (bytePtrT + 0x478);
            STREET_TRANSMISSION.GearEfficiency = *(float*) (bytePtrT + 0x47C);
            STREET_TRANSMISSION.GearRatioR = *(float*) (bytePtrT + 0x480);
            STREET_TRANSMISSION.GearRatioN = *(float*) (bytePtrT + 0x484);
            STREET_TRANSMISSION.GearRatio1 = *(float*) (bytePtrT + 0x488);
            STREET_TRANSMISSION.GearRatio2 = *(float*) (bytePtrT + 0x48C);
            STREET_TRANSMISSION.GearRatio3 = *(float*) (bytePtrT + 0x490);
            STREET_TRANSMISSION.GearRatio4 = *(float*) (bytePtrT + 0x494);
            STREET_TRANSMISSION.GearRatio5 = *(float*) (bytePtrT + 0x498);
            STREET_TRANSMISSION.GearRatio6 = *(float*) (bytePtrT + 0x49C);

            // Pro Transmission Performance
            PRO_TRANSMISSION.ClutchSlip = *(float*) (bytePtrT + 0x4A0);
            PRO_TRANSMISSION.OptimalShift = *(float*) (bytePtrT + 0x4A4);
            PRO_TRANSMISSION.FinalDriveRatio = *(float*) (bytePtrT + 0x4A8);
            PRO_TRANSMISSION.FinalDriveRatio2 = *(float*) (bytePtrT + 0x4AC);
            PRO_TRANSMISSION.TorqueSplit = *(float*) (bytePtrT + 0x4B0);
            PRO_TRANSMISSION.BurnoutStrength = *(float*) (bytePtrT + 0x4B4);
            PRO_TRANSMISSION.NumberOfGears = *(int*) (bytePtrT + 0x4B8);
            PRO_TRANSMISSION.GearEfficiency = *(float*) (bytePtrT + 0x4BC);
            PRO_TRANSMISSION.GearRatioR = *(float*) (bytePtrT + 0x4C0);
            PRO_TRANSMISSION.GearRatioN = *(float*) (bytePtrT + 0x4C4);
            PRO_TRANSMISSION.GearRatio1 = *(float*) (bytePtrT + 0x4C8);
            PRO_TRANSMISSION.GearRatio2 = *(float*) (bytePtrT + 0x4CC);
            PRO_TRANSMISSION.GearRatio3 = *(float*) (bytePtrT + 0x4D0);
            PRO_TRANSMISSION.GearRatio4 = *(float*) (bytePtrT + 0x4D4);
            PRO_TRANSMISSION.GearRatio5 = *(float*) (bytePtrT + 0x4D8);
            PRO_TRANSMISSION.GearRatio6 = *(float*) (bytePtrT + 0x4DC);

            // Top Transmission Performance
            TOP_TRANSMISSION.ClutchSlip = *(float*) (bytePtrT + 0x4E0);
            TOP_TRANSMISSION.OptimalShift = *(float*) (bytePtrT + 0x4E4);
            TOP_TRANSMISSION.FinalDriveRatio = *(float*) (bytePtrT + 0x4E8);
            TOP_TRANSMISSION.FinalDriveRatio2 = *(float*) (bytePtrT + 0x4EC);
            TOP_TRANSMISSION.TorqueSplit = *(float*) (bytePtrT + 0x4F0);
            TOP_TRANSMISSION.BurnoutStrength = *(float*) (bytePtrT + 0x4F4);
            TOP_TRANSMISSION.NumberOfGears = *(int*) (bytePtrT + 0x4F8);
            TOP_TRANSMISSION.GearEfficiency = *(float*) (bytePtrT + 0x4FC);
            TOP_TRANSMISSION.GearRatioR = *(float*) (bytePtrT + 0x500);
            TOP_TRANSMISSION.GearRatioN = *(float*) (bytePtrT + 0x504);
            TOP_TRANSMISSION.GearRatio1 = *(float*) (bytePtrT + 0x508);
            TOP_TRANSMISSION.GearRatio2 = *(float*) (bytePtrT + 0x50C);
            TOP_TRANSMISSION.GearRatio3 = *(float*) (bytePtrT + 0x510);
            TOP_TRANSMISSION.GearRatio4 = *(float*) (bytePtrT + 0x514);
            TOP_TRANSMISSION.GearRatio5 = *(float*) (bytePtrT + 0x518);
            TOP_TRANSMISSION.GearRatio6 = *(float*) (bytePtrT + 0x51C);

            // Top Engine Performance
            TOP_ENGINE.SpeedRefreshRate = *(float*) (bytePtrT + 0x52C);
            TOP_ENGINE.EngineTorque1 = *(float*) (bytePtrT + 0x530);
            TOP_ENGINE.EngineTorque2 = *(float*) (bytePtrT + 0x534);
            TOP_ENGINE.EngineTorque3 = *(float*) (bytePtrT + 0x538);
            TOP_ENGINE.EngineTorque4 = *(float*) (bytePtrT + 0x53C);
            TOP_ENGINE.EngineTorque5 = *(float*) (bytePtrT + 0x540);
            TOP_ENGINE.EngineTorque6 = *(float*) (bytePtrT + 0x544);
            TOP_ENGINE.EngineTorque7 = *(float*) (bytePtrT + 0x548);
            TOP_ENGINE.EngineTorque8 = *(float*) (bytePtrT + 0x54C);
            TOP_ENGINE.EngineTorque9 = *(float*) (bytePtrT + 0x550);
            TOP_ENGINE.EngineBraking1 = *(float*) (bytePtrT + 0x554);
            TOP_ENGINE.EngineBraking2 = *(float*) (bytePtrT + 0x558);
            TOP_ENGINE.EngineBraking3 = *(float*) (bytePtrT + 0x55C);

            // Street RPM Performance
            STREET_RPM.IdleRPMAdd = *(float*) (bytePtrT + 0x560);
            STREET_RPM.RedLineRPMAdd = *(float*) (bytePtrT + 0x564);
            STREET_RPM.MaxRPMAdd = *(float*) (bytePtrT + 0x568);

            // Street ECU Performance
            STREET_ECU.ECUx1000Add = *(float*) (bytePtrT + 0x570);
            STREET_ECU.ECUx2000Add = *(float*) (bytePtrT + 0x574);
            STREET_ECU.ECUx3000Add = *(float*) (bytePtrT + 0x578);
            STREET_ECU.ECUx4000Add = *(float*) (bytePtrT + 0x57C);
            STREET_ECU.ECUx5000Add = *(float*) (bytePtrT + 0x580);
            STREET_ECU.ECUx6000Add = *(float*) (bytePtrT + 0x584);
            STREET_ECU.ECUx7000Add = *(float*) (bytePtrT + 0x588);
            STREET_ECU.ECUx8000Add = *(float*) (bytePtrT + 0x58C);
            STREET_ECU.ECUx9000Add = *(float*) (bytePtrT + 0x590);
            STREET_ECU.ECUx10000Add = *(float*) (bytePtrT + 0x594);
            STREET_ECU.ECUx11000Add = *(float*) (bytePtrT + 0x598);
            STREET_ECU.ECUx12000Add = *(float*) (bytePtrT + 0x59C);

            // Pro RPM Performance
            PRO_RPM.IdleRPMAdd = *(float*) (bytePtrT + 0x5A0);
            PRO_RPM.RedLineRPMAdd = *(float*) (bytePtrT + 0x5A4);
            PRO_RPM.MaxRPMAdd = *(float*) (bytePtrT + 0x5A8);

            // Pro ECU Performance
            PRO_ECU.ECUx1000Add = *(float*) (bytePtrT + 0x5B0);
            PRO_ECU.ECUx2000Add = *(float*) (bytePtrT + 0x5B4);
            PRO_ECU.ECUx3000Add = *(float*) (bytePtrT + 0x5B8);
            PRO_ECU.ECUx4000Add = *(float*) (bytePtrT + 0x5BC);
            PRO_ECU.ECUx5000Add = *(float*) (bytePtrT + 0x5C0);
            PRO_ECU.ECUx6000Add = *(float*) (bytePtrT + 0x5C4);
            PRO_ECU.ECUx7000Add = *(float*) (bytePtrT + 0x5C8);
            PRO_ECU.ECUx8000Add = *(float*) (bytePtrT + 0x5CC);
            PRO_ECU.ECUx9000Add = *(float*) (bytePtrT + 0x5D0);
            PRO_ECU.ECUx10000Add = *(float*) (bytePtrT + 0x5D4);
            PRO_ECU.ECUx11000Add = *(float*) (bytePtrT + 0x5D8);
            PRO_ECU.ECUx12000Add = *(float*) (bytePtrT + 0x5DC);

            // Top RPM Performance
            TOP_RPM.IdleRPMAdd = *(float*) (bytePtrT + 0x5E0);
            TOP_RPM.RedLineRPMAdd = *(float*) (bytePtrT + 0x5E4);
            TOP_RPM.MaxRPMAdd = *(float*) (bytePtrT + 0x5E8);

            // Top ECU Performance
            TOP_ECU.ECUx1000Add = *(float*) (bytePtrT + 0x5F0);
            TOP_ECU.ECUx2000Add = *(float*) (bytePtrT + 0x5F4);
            TOP_ECU.ECUx3000Add = *(float*) (bytePtrT + 0x5F8);
            TOP_ECU.ECUx4000Add = *(float*) (bytePtrT + 0x5FC);
            TOP_ECU.ECUx5000Add = *(float*) (bytePtrT + 0x600);
            TOP_ECU.ECUx6000Add = *(float*) (bytePtrT + 0x604);
            TOP_ECU.ECUx7000Add = *(float*) (bytePtrT + 0x608);
            TOP_ECU.ECUx8000Add = *(float*) (bytePtrT + 0x60C);
            TOP_ECU.ECUx9000Add = *(float*) (bytePtrT + 0x610);
            TOP_ECU.ECUx10000Add = *(float*) (bytePtrT + 0x614);
            TOP_ECU.ECUx11000Add = *(float*) (bytePtrT + 0x618);
            TOP_ECU.ECUx12000Add = *(float*) (bytePtrT + 0x61C);

            // Top Turbo Performance
            TOP_TURBO.TurboBraking = *(float*) (bytePtrT + 0x620);
            TOP_TURBO.TurboVacuum = *(float*) (bytePtrT + 0x624);
            TOP_TURBO.TurboHeatHigh = *(float*) (bytePtrT + 0x628);
            TOP_TURBO.TurboHeatLow = *(float*) (bytePtrT + 0x62C);
            TOP_TURBO.TurboHighBoost = *(float*) (bytePtrT + 0x630);
            TOP_TURBO.TurboLowBoost = *(float*) (bytePtrT + 0x634);
            TOP_TURBO.TurboSpool = *(float*) (bytePtrT + 0x638);
            TOP_TURBO.TurboSpoolTimeDown = *(float*) (bytePtrT + 0x63C);
            TOP_TURBO.TurboSpoolTimeUp = *(float*) (bytePtrT + 0x640);

            // Top Tires Performance
            TOP_TIRES.StaticGripScale = *(float*) (bytePtrT + 0x650);
            TOP_TIRES.YawSpeedScale = *(float*) (bytePtrT + 0x654);
            TOP_TIRES.SteeringAmplifier = *(float*) (bytePtrT + 0x658);
            TOP_TIRES.DynamicGripScale = *(float*) (bytePtrT + 0x65C);
            TOP_TIRES.SteeringResponse = *(float*) (bytePtrT + 0x660);
            TOP_TIRES.DriftYawControl = *(float*) (bytePtrT + 0x670);
            TOP_TIRES.DriftCounterSteerBuildUp = *(float*) (bytePtrT + 0x674);
            TOP_TIRES.DriftCounterSteerReduction = *(float*) (bytePtrT + 0x678);
            TOP_TIRES.PowerSlideBreakThru1 = *(float*) (bytePtrT + 0x67C);
            TOP_TIRES.PowerSlideBreakThru2 = *(float*) (bytePtrT + 0x680);

            // Top Nitrous Performance
            TOP_NITROUS.NOSCapacity = *(float*) (bytePtrT + 0x690);
            TOP_NITROUS.NOSTorqueBoost = *(float*) (bytePtrT + 0x69C);

            // Top Brakes Performance
            TOP_BRAKES.FrontDownForce = *(float*) (bytePtrT + 0x6B0);
            TOP_BRAKES.RearDownForce = *(float*) (bytePtrT + 0x6B4);
            TOP_BRAKES.BumpJumpForce = *(float*) (bytePtrT + 0x6B8);
            TOP_BRAKES.BrakeStrength = *(float*) (bytePtrT + 0x6C0);
            TOP_BRAKES.HandBrakeStrength = *(float*) (bytePtrT + 0x6C4);
            TOP_BRAKES.BrakeBias = *(float*) (bytePtrT + 0x6C8);
            TOP_BRAKES.SteeringRatio = *(float*) (bytePtrT + 0x6CC);

            // Top Suspension Performance
            TOP_SUSPENSION.ShockStiffnessFront = *(float*) (bytePtrT + 0x6D0);
            TOP_SUSPENSION.ShockExtStiffnessFront = *(float*) (bytePtrT + 0x6D4);
            TOP_SUSPENSION.SpringProgressionFront = *(float*) (bytePtrT + 0x6D8);
            TOP_SUSPENSION.ShockValvingFront = *(float*) (bytePtrT + 0x6DC);
            TOP_SUSPENSION.SwayBarFront = *(float*) (bytePtrT + 0x6E0);
            TOP_SUSPENSION.TrackWidthFront = *(float*) (bytePtrT + 0x6E4);
            TOP_SUSPENSION.CounterBiasFront = *(float*) (bytePtrT + 0x6E8);
            TOP_SUSPENSION.ShockDigressionFront = *(float*) (bytePtrT + 0x6EC);
            TOP_SUSPENSION.ShockStiffnessRear = *(float*) (bytePtrT + 0x6F0);
            TOP_SUSPENSION.ShockExtStiffnessRear = *(float*) (bytePtrT + 0x6F4);
            TOP_SUSPENSION.SpringProgressionRear = *(float*) (bytePtrT + 0x6F8);
            TOP_SUSPENSION.ShockValvingRear = *(float*) (bytePtrT + 0x6FC);
            TOP_SUSPENSION.SwayBarRear = *(float*) (bytePtrT + 0x700);
            TOP_SUSPENSION.TrackWidthRear = *(float*) (bytePtrT + 0x704);
            TOP_SUSPENSION.CounterBiasRear = *(float*) (bytePtrT + 0x708);
            TOP_SUSPENSION.ShockDigressionRear = *(float*) (bytePtrT + 0x70C);

            // Player Cameras
            PLAYER_CAMERA_FAR.CameraAngle = ((float) *(short*) (bytePtrT + 0x732)) * 180 / 32768;
            PLAYER_CAMERA_FAR.CameraLag = *(float*) (bytePtrT + 0x734);
            PLAYER_CAMERA_FAR.CameraHeight = *(float*) (bytePtrT + 0x738);
            PLAYER_CAMERA_FAR.CameraLatOffset = *(float*) (bytePtrT + 0x73C);
            PLAYER_CAMERA_CLOSE.CameraAngle = ((float) *(short*) (bytePtrT + 0x742)) * 180 / 32768;
            PLAYER_CAMERA_CLOSE.CameraLag = *(float*) (bytePtrT + 0x744);
            PLAYER_CAMERA_CLOSE.CameraHeight = *(float*) (bytePtrT + 0x748);
            PLAYER_CAMERA_CLOSE.CameraLatOffset = *(float*) (bytePtrT + 0x74C);
            PLAYER_CAMERA_BUMPER.CameraAngle = ((float) *(short*) (bytePtrT + 0x752)) * 180 / 32768;
            PLAYER_CAMERA_BUMPER.CameraLag = *(float*) (bytePtrT + 0x754);
            PLAYER_CAMERA_BUMPER.CameraHeight = *(float*) (bytePtrT + 0x758);
            PLAYER_CAMERA_BUMPER.CameraLatOffset = *(float*) (bytePtrT + 0x75C);
            PLAYER_CAMERA_DRIVER.CameraAngle = ((float) *(short*) (bytePtrT + 0x762)) * 180 / 32768;
            PLAYER_CAMERA_DRIVER.CameraLag = *(float*) (bytePtrT + 0x764);
            PLAYER_CAMERA_DRIVER.CameraHeight = *(float*) (bytePtrT + 0x768);
            PLAYER_CAMERA_DRIVER.CameraLatOffset = *(float*) (bytePtrT + 0x76C);
            PLAYER_CAMERA_HOOD.CameraAngle = ((float) *(short*) (bytePtrT + 0x772)) * 180 / 32768;
            PLAYER_CAMERA_HOOD.CameraLag = *(float*) (bytePtrT + 0x774);
            PLAYER_CAMERA_HOOD.CameraHeight = *(float*) (bytePtrT + 0x778);
            PLAYER_CAMERA_HOOD.CameraLatOffset = *(float*) (bytePtrT + 0x77C);
            PLAYER_CAMERA_DRIFT.CameraAngle = ((float) *(short*) (bytePtrT + 0x782)) * 180 / 32768;
            PLAYER_CAMERA_DRIFT.CameraLag = *(float*) (bytePtrT + 0x784);
            PLAYER_CAMERA_DRIFT.CameraHeight = *(float*) (bytePtrT + 0x788);
            PLAYER_CAMERA_DRIFT.CameraLatOffset = *(float*) (bytePtrT + 0x78C);

            // AI Cameras
            AI_CAMERA_FAR.CameraAngle = ((float) *(short*) (bytePtrT + 0x792)) * 180 / 32768;
            AI_CAMERA_FAR.CameraLag = *(float*) (bytePtrT + 0x794);
            AI_CAMERA_FAR.CameraHeight = *(float*) (bytePtrT + 0x798);
            AI_CAMERA_FAR.CameraLatOffset = *(float*) (bytePtrT + 0x79C);
            AI_CAMERA_CLOSE.CameraAngle = ((float) *(short*) (bytePtrT + 0x7A2)) * 180 / 32768;
            AI_CAMERA_CLOSE.CameraLag = *(float*) (bytePtrT + 0x7A4);
            AI_CAMERA_CLOSE.CameraHeight = *(float*) (bytePtrT + 0x7A8);
            AI_CAMERA_CLOSE.CameraLatOffset = *(float*) (bytePtrT + 0x7AC);
            AI_CAMERA_BUMPER.CameraAngle = ((float) *(short*) (bytePtrT + 0x7B2)) * 180 / 32768;
            AI_CAMERA_BUMPER.CameraLag = *(float*) (bytePtrT + 0x7B4);
            AI_CAMERA_BUMPER.CameraHeight = *(float*) (bytePtrT + 0x7B8);
            AI_CAMERA_BUMPER.CameraLatOffset = *(float*) (bytePtrT + 0x7BC);
            AI_CAMERA_DRIVER.CameraAngle = ((float) *(short*) (bytePtrT + 0x7C2)) * 180 / 32768;
            AI_CAMERA_DRIVER.CameraLag = *(float*) (bytePtrT + 0x7C4);
            AI_CAMERA_DRIVER.CameraHeight = *(float*) (bytePtrT + 0x7C8);
            AI_CAMERA_DRIVER.CameraLatOffset = *(float*) (bytePtrT + 0x7CC);
            AI_CAMERA_HOOD.CameraAngle = ((float) *(short*) (bytePtrT + 0x7D2)) * 180 / 32768;
            AI_CAMERA_HOOD.CameraLag = *(float*) (bytePtrT + 0x7D4);
            AI_CAMERA_HOOD.CameraHeight = *(float*) (bytePtrT + 0x7D8);
            AI_CAMERA_HOOD.CameraLatOffset = *(float*) (bytePtrT + 0x7DC);
            AI_CAMERA_DRIFT.CameraAngle = ((float) *(short*) (bytePtrT + 0x7E2)) * 180 / 32768;
            AI_CAMERA_DRIFT.CameraLag = *(float*) (bytePtrT + 0x7E4);
            AI_CAMERA_DRIFT.CameraHeight = *(float*) (bytePtrT + 0x7E8);
            AI_CAMERA_DRIFT.CameraLatOffset = *(float*) (bytePtrT + 0x7EC);

            // Rigid Controls
            _rigidControls = new ushort[40];
            for (var a1 = 0; a1 < 40; ++a1)
                _rigidControls[a1] = *(ushort*) (bytePtrT + 0x7F0 + a1 * 2);

            // Secondary Properties
            Index = *(int*) (bytePtrT + 0x840);
            UsageType = (eUsageType) (*(int*) (bytePtrT + 0x844));
            var key = *(uint*) (bytePtrT + 0x84C);
            _defaultBasePaint = Map.Lookup(key, true) ?? BaseArguments.UGPAINT;
            key = *(uint*) (bytePtrT + 0x850);
            _defaultBasePaint2 = Map.Lookup(key, true) ?? BaseArguments.UGPAINT;
            MaxInstances1 = *(bytePtrT + 0x854);
            MaxInstances2 = *(bytePtrT + 0x855);
            MaxInstances3 = *(bytePtrT + 0x856);
            MaxInstances4 = *(bytePtrT + 0x857);
            MaxInstances5 = *(bytePtrT + 0x858);
            KeepLoaded1 = *(bytePtrT + 0x859);
            KeepLoaded1 = *(bytePtrT + 0x85A);
            KeepLoaded1 = *(bytePtrT + 0x85B);
            KeepLoaded1 = *(bytePtrT + 0x85C);
            KeepLoaded1 = *(bytePtrT + 0x85D);
            Padding1 = *(short*) (bytePtrT + 0x85E);
            MinTimeBetweenUses1 = *(float*) (bytePtrT + 0x860);
            MinTimeBetweenUses2 = *(float*) (bytePtrT + 0x864);
            MinTimeBetweenUses3 = *(float*) (bytePtrT + 0x868);
            MinTimeBetweenUses4 = *(float*) (bytePtrT + 0x86C);
            MinTimeBetweenUses5 = *(float*) (bytePtrT + 0x870);
            DefaultSkinNumber = (byte) (*(int*) (bytePtrT + 0x874));
            Padding2 = *(int*) (bytePtrT + 0x878);
            AvailableSkinNumbers01 = *(bytePtrT + 0x880);
            AvailableSkinNumbers02 = *(bytePtrT + 0x881);
            AvailableSkinNumbers03 = *(bytePtrT + 0x882);
            AvailableSkinNumbers04 = *(bytePtrT + 0x883);
            AvailableSkinNumbers05 = *(bytePtrT + 0x884);
            AvailableSkinNumbers06 = *(bytePtrT + 0x885);
            AvailableSkinNumbers07 = *(bytePtrT + 0x886);
            AvailableSkinNumbers08 = *(bytePtrT + 0x887);
            AvailableSkinNumbers09 = *(bytePtrT + 0x888);
            AvailableSkinNumbers10 = *(bytePtrT + 0x889);
            _isSuv = (*(short*) (bytePtrT + 0x88A) == 1)
                ? eBoolean.True
                : eBoolean.False;
            IsSkinnable = (*(int*) (bytePtrT + 0x88C) == 0)
                ? eBoolean.False
                : eBoolean.True;
        }
    }
}