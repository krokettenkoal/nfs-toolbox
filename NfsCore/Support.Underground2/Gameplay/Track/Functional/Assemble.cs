using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
    {
        /// <summary>
        /// Assembles material into a byte array.
        /// </summary>
        /// <returns>Byte array of the material.</returns>
        public unsafe byte[] Assemble()
        {
            var result = new byte[0x128];
            fixed (byte* bytePtrT = &result[0])
            {
                for (var a1 = 0; a1 < _raceDescription.Length; ++a1)
                    *(bytePtrT + a1) = (byte) _raceDescription[a1];
                var raceDir = $"{_locationDirectory}\\{CollName}";
                for (var a1 = 0; a1 < raceDir.Length; ++a1)
                    *(bytePtrT + 0x20 + a1) = (byte) raceDir[a1];
                for (var a1 = 0; a1 < _regionName.Length; ++a1)
                    *(bytePtrT + 0x40 + a1) = (byte) _regionName[a1];
                for (var a1 = 0; a1 < _regionDirectory.Length; ++a1)
                    *(bytePtrT + 0x48 + a1) = (byte) _regionDirectory[a1];
                for (var a1 = 0; a1 < _locationDirectory.Length; ++a1)
                    *(bytePtrT + 0x6C + a1) = (byte) _locationDirectory[a1];
                *(int*) (bytePtrT + 0x68) = _locationIndex;
                *(int*) (bytePtrT + 0x7C) = (int) _locationType;
                *(int*) (bytePtrT + 0x80) = (int) _driftType;
                *(bytePtrT + 0x84) = (_isValidRace == eBoolean.True) ? (byte) 1 : (byte) 0;
                *(bytePtrT + 0x85) = (_isLoopingRace == eBoolean.True) ? (byte) 0 : (byte) 1;
                *(bytePtrT + 0x86) = (_reverseVersionExists == eBoolean.True) ? (byte) 1 : (byte) 0;
                *(bytePtrT + 0x88) = (_isPerformanceTuning == eBoolean.True) ? (byte) 1 : (byte) 0;
                *(ushort*) (bytePtrT + 0x8A) = TrackID;
                *(ushort*) (bytePtrT + 0x8C) = TrackID;
                *(uint*) (bytePtrT + 0x90) = Bin.SmartHash(_sunInfoName);
                *(int*) (bytePtrT + 0x94) = (int) _raceGameplayMode;
                *(uint*) (bytePtrT + 0x98) = RaceLength;
                *(float*) (bytePtrT + 0x9C) = TimeLimitToBeatForward;
                *(float*) (bytePtrT + 0xA0) = TimeLimitToBeatReverse;
                *(int*) (bytePtrT + 0xA4) = ScoreToBeatDriftForward;
                *(int*) (bytePtrT + 0xA8) = ScoreToBeatDriftReverse;
                *(float*) (bytePtrT + 0xAC) = TrackMapCalibrationOffsetX;
                *(float*) (bytePtrT + 0xB0) = TrackMapCalibrationOffsetY;
                *(float*) (bytePtrT + 0xB4) = TrackMapCalibrationWidth;
                *(ushort*) (bytePtrT + 0xB8) = (ushort) (TrackMapCalibrationRotation / 180 * 32768);
                *(ushort*) (bytePtrT + 0xBA) = (ushort) (TrackMapStartgridAngle / 180 * 32768);
                *(ushort*) (bytePtrT + 0xBC) = (ushort) (TrackMapFinishlineAngle / 180 * 32768);
                *(float*) (bytePtrT + 0xC0) = TrackMapCalibrationZoomIn;
                *(int*) (bytePtrT + 0xC4) = (int) _difficultyForward;
                *(int*) (bytePtrT + 0xC8) = (int) _difficultyReverse;
                *(int*) (bytePtrT + 0xCC) = -1;
                *(int*) (bytePtrT + 0xD0) = -1;
                *(int*) (bytePtrT + 0xD4) = -1;
                *(int*) (bytePtrT + 0xD8) = -1;
                *(int*) (bytePtrT + 0xDC) = -1;
                *(int*) (bytePtrT + 0xE0) = -1;
                *(short*) (bytePtrT + 0xE4) = NumSecBeforeShorcutsAllowed;
                *(short*) (bytePtrT + 0xE6) = DriftSecondsMin;
                *(short*) (bytePtrT + 0xE8) = DriftSecondsMax;
                *(bytePtrT + 0xEC) = MaxTrafficCars_0_0;
                *(bytePtrT + 0xED) = MaxTrafficCars_0_1;
                *(bytePtrT + 0xEE) = MaxTrafficCars_1_0;
                *(bytePtrT + 0xEF) = MaxTrafficCars_1_1;
                *(bytePtrT + 0xF0) = MaxTrafficCars_2_0;
                *(bytePtrT + 0xF1) = MaxTrafficCars_2_1;
                *(bytePtrT + 0xF2) = MaxTrafficCars_3_0;
                *(bytePtrT + 0xF3) = MaxTrafficCars_3_1;
                *(bytePtrT + 0xF4) = TrafAllowedNearStartgrid;
                *(bytePtrT + 0xF5) = TrafAllowedNearFinishline;
                *(short*) (bytePtrT + 0xF6) = CarRaceStartConfig;
                *(float*) (bytePtrT + 0xF8) = TrafMinInitDistFromStart;
                *(float*) (bytePtrT + 0xFC) = TrafMinInitDistFromFinish;
                *(float*) (bytePtrT + 0x100) = TrafMinInitDistInbetweenA;
                *(float*) (bytePtrT + 0x104) = TrafMinInitDistInbetweenB;
                *(float*) (bytePtrT + 0x108) = TrafOncomingFraction1;
                *(float*) (bytePtrT + 0x10C) = TrafOncomingFraction2;
                *(float*) (bytePtrT + 0x110) = TrafOncomingFraction3;
                *(float*) (bytePtrT + 0x114) = TrafOncomingFraction4;
                *(float*) (bytePtrT + 0x118) = MenuMapZoomOffsetX;
                *(float*) (bytePtrT + 0x11C) = MenuMapZoomOffsetY;
                *(float*) (bytePtrT + 0x120) = MenuMapZoomWidth;
                *(float*) (bytePtrT + 0x124) = MenuMapStartZoomed;
            }

            return result;
        }
    }
}