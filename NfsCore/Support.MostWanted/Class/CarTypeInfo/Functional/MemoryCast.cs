using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new CarTypeInfo(collectionName, Database)
            {
                _spoiler = _spoiler,
                CollisionInternalName = CollisionInternalName,
                UsageType = UsageType,
                MemoryType = MemoryType,
                IsSkinnable = IsSkinnable,
                ManufacturerName = ManufacturerName,
                DefaultBasePaint = DefaultBasePaint,
                HeadlightFOV = HeadlightFOV,
                PadHighPerformance = PadHighPerformance,
                NumAvailableSkinNumbers = NumAvailableSkinNumbers,
                WhatGame = WhatGame,
                ConvertibleFlag = ConvertibleFlag,
                WheelOuterRadius = WheelOuterRadius,
                WheelInnerRadiusMin = WheelInnerRadiusMin,
                WheelInnerRadiusMax = WheelInnerRadiusMax,
                Padding0 = Padding0,
                HeadlightPositionX = HeadlightPositionX,
                HeadlightPositionY = HeadlightPositionY,
                HeadlightPositionZ = HeadlightPositionZ,
                HeadlightPositionW = HeadlightPositionW,
                DriverRenderingOffsetX = DriverRenderingOffsetX,
                DriverRenderingOffsetY = DriverRenderingOffsetY,
                DriverRenderingOffsetZ = DriverRenderingOffsetZ,
                DriverRenderingOffsetW = DriverRenderingOffsetW,
                SteeringWheelRenderingX = SteeringWheelRenderingX,
                SteeringWheelRenderingY = SteeringWheelRenderingY,
                SteeringWheelRenderingZ = SteeringWheelRenderingZ,
                SteeringWheelRenderingW = SteeringWheelRenderingW,
                MaxInstances1 = MaxInstances1,
                MaxInstances2 = MaxInstances2,
                MaxInstances3 = MaxInstances3,
                MaxInstances4 = MaxInstances4,
                MaxInstances5 = MaxInstances5,
                KeepLoaded1 = KeepLoaded1,
                KeepLoaded2 = KeepLoaded2,
                KeepLoaded3 = KeepLoaded3,
                KeepLoaded4 = KeepLoaded4,
                KeepLoaded5 = KeepLoaded5,
                Padding1 = Padding1,
                MinTimeBetweenUses1 = MinTimeBetweenUses1,
                MinTimeBetweenUses2 = MinTimeBetweenUses2,
                MinTimeBetweenUses3 = MinTimeBetweenUses3,
                MinTimeBetweenUses4 = MinTimeBetweenUses4,
                MinTimeBetweenUses5 = MinTimeBetweenUses5,
                AvailableSkinNumbers01 = AvailableSkinNumbers01,
                AvailableSkinNumbers02 = AvailableSkinNumbers02,
                AvailableSkinNumbers03 = AvailableSkinNumbers03,
                AvailableSkinNumbers04 = AvailableSkinNumbers04,
                AvailableSkinNumbers05 = AvailableSkinNumbers05,
                AvailableSkinNumbers06 = AvailableSkinNumbers06,
                AvailableSkinNumbers07 = AvailableSkinNumbers07,
                AvailableSkinNumbers08 = AvailableSkinNumbers08,
                AvailableSkinNumbers09 = AvailableSkinNumbers09,
                AvailableSkinNumbers10 = AvailableSkinNumbers10,
                DefaultSkinNumber = DefaultSkinNumber,
                Padding2 = Padding2
            };

            return result;
        }
    }
}