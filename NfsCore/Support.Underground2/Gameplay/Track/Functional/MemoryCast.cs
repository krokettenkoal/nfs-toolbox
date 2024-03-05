using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new Track(collectionName, Database)
            {
                _difficultyForward = _difficultyForward,
                _difficultyReverse = _difficultyReverse,
                _driftType = _driftType,
                _isLoopingRace = _isLoopingRace,
                _isPerformanceTuning = _isPerformanceTuning,
                _isValidRace = _isValidRace,
                _locationDirectory = _locationDirectory,
                _locationIndex = _locationIndex,
                _locationType = _locationType,
                _raceDescription = _raceDescription,
                _raceGameplayMode = _raceGameplayMode,
                _regionDirectory = _regionDirectory,
                _regionName = _regionName,
                _reverseVersionExists = _reverseVersionExists,
                _sunInfoName = _sunInfoName,
                _trackDirectory = _trackDirectory,
                CarRaceStartConfig = CarRaceStartConfig,
                RaceLength = RaceLength,
                TimeLimitToBeatForward = TimeLimitToBeatForward,
                TimeLimitToBeatReverse = TimeLimitToBeatReverse,
                ScoreToBeatDriftForward = ScoreToBeatDriftForward,
                ScoreToBeatDriftReverse = ScoreToBeatDriftReverse,
                NumSecBeforeShorcutsAllowed = NumSecBeforeShorcutsAllowed,
                DriftSecondsMax = DriftSecondsMax,
                DriftSecondsMin = DriftSecondsMin,
                TrackMapCalibrationOffsetX = TrackMapCalibrationOffsetX,
                TrackMapCalibrationOffsetY = TrackMapCalibrationOffsetY,
                TrackMapCalibrationRotation = TrackMapCalibrationRotation,
                TrackMapCalibrationWidth = TrackMapCalibrationWidth,
                TrackMapCalibrationZoomIn = TrackMapCalibrationZoomIn,
                TrackMapFinishlineAngle = TrackMapFinishlineAngle,
                TrackMapStartgridAngle = TrackMapStartgridAngle,
                MenuMapStartZoomed = MenuMapStartZoomed,
                MenuMapZoomOffsetX = MenuMapZoomOffsetX,
                MenuMapZoomOffsetY = MenuMapZoomOffsetY,
                MenuMapZoomWidth = MenuMapZoomWidth,
                MaxTrafficCars_0_0 = MaxTrafficCars_0_0,
                MaxTrafficCars_0_1 = MaxTrafficCars_0_1,
                MaxTrafficCars_1_0 = MaxTrafficCars_1_0,
                MaxTrafficCars_1_1 = MaxTrafficCars_1_1,
                MaxTrafficCars_2_0 = MaxTrafficCars_2_0,
                MaxTrafficCars_2_1 = MaxTrafficCars_2_1,
                MaxTrafficCars_3_0 = MaxTrafficCars_3_0,
                MaxTrafficCars_3_1 = MaxTrafficCars_3_1,
                TrafAllowedNearFinishline = TrafAllowedNearFinishline,
                TrafAllowedNearStartgrid = TrafAllowedNearStartgrid,
                TrafMinInitDistFromFinish = TrafMinInitDistFromFinish,
                TrafMinInitDistFromStart = TrafMinInitDistFromStart,
                TrafMinInitDistInbetweenA = TrafMinInitDistInbetweenA,
                TrafMinInitDistInbetweenB = TrafMinInitDistInbetweenB,
                TrafOncomingFraction1 = TrafOncomingFraction1,
                TrafOncomingFraction2 = TrafOncomingFraction2,
                TrafOncomingFraction3 = TrafOncomingFraction3,
                TrafOncomingFraction4 = TrafOncomingFraction4
            };

            return result;
        }
    }
}