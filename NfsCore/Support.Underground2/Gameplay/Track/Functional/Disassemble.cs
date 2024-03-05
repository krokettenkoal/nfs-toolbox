using NfsCore.Global;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
    {
        /// <summary>
        /// Disassembles track block into separate properties.
        /// </summary>
        /// <param name="bytePtrT">Pointer to the track block.</param
        protected unsafe void Disassemble(byte* bytePtrT)
        {
            _raceDescription = ScriptX.NullTerminatedString(bytePtrT, 0x20);
            _trackDirectory = ScriptX.NullTerminatedString(bytePtrT + 0x20, 0x20);
            _regionName = ScriptX.NullTerminatedString(bytePtrT + 0x40, 0x8);
            _regionDirectory = ScriptX.NullTerminatedString(bytePtrT + 0x48, 0x20);
            _locationIndex = *(int*) (bytePtrT + 0x68);
            _locationDirectory = ScriptX.NullTerminatedString(bytePtrT + 0x6C, 0x10);
            _locationType = (eLocationType) (*(int*) (bytePtrT + 0x7C));
            _driftType = (eDriftType) (*(int*) (bytePtrT + 0x80));
            _isValidRace = *(bytePtrT + 0x84) == 0
                ? eBoolean.False
                : eBoolean.True;
            _isLoopingRace = *(bytePtrT + 0x85) == 0
                ? eBoolean.True
                : eBoolean.False;
            _reverseVersionExists = *(bytePtrT + 0x86) == 0
                ? eBoolean.False
                : eBoolean.True;
            _isPerformanceTuning = *(bytePtrT + 0x88) == 0
                ? eBoolean.False
                : eBoolean.True;
            TrackID = *(ushort*) (bytePtrT + 0x8A);
            uint key = *(uint*) (bytePtrT + 0x90);
            _sunInfoName = Map.Lookup(key, true) ?? $"0x{key:X8}";
            _raceGameplayMode = (eRaceGameplayMode) (*(int*) (bytePtrT + 0x94));
            RaceLength = *(uint*) (bytePtrT + 0x98);
            TimeLimitToBeatForward = *(float*) (bytePtrT + 0x9C);
            TimeLimitToBeatReverse = *(float*) (bytePtrT + 0xA0);
            ScoreToBeatDriftForward = *(int*) (bytePtrT + 0xA4);
            ScoreToBeatDriftReverse = *(int*) (bytePtrT + 0xA8);
            TrackMapCalibrationOffsetX = *(float*) (bytePtrT + 0xAC);
            TrackMapCalibrationOffsetY = *(float*) (bytePtrT + 0xB0);
            TrackMapCalibrationWidth = *(float*) (bytePtrT + 0xB4);
            TrackMapCalibrationRotation = (float) *(ushort*) (bytePtrT + 0xB8) * 180 / 32768;
            TrackMapStartgridAngle = (float) *(ushort*) (bytePtrT + 0xBA) * 180 / 32768;
            TrackMapFinishlineAngle = (float) *(ushort*) (bytePtrT + 0xBC) * 180 / 32768;
            TrackMapCalibrationZoomIn = *(float*) (bytePtrT + 0xC0);
            _difficultyForward = (eTrackDifficulty) (*(int*) (bytePtrT + 0xC4));
            _difficultyReverse = (eTrackDifficulty) (*(int*) (bytePtrT + 0xC8));
            NumSecBeforeShorcutsAllowed = *(short*) (bytePtrT + 0xE4);
            DriftSecondsMin = *(short*) (bytePtrT + 0xE6);
            DriftSecondsMax = *(short*) (bytePtrT + 0xE8);
            MaxTrafficCars_0_0 = *(bytePtrT + 0xEC);
            MaxTrafficCars_0_1 = *(bytePtrT + 0xED);
            MaxTrafficCars_1_0 = *(bytePtrT + 0xEE);
            MaxTrafficCars_1_1 = *(bytePtrT + 0xEF);
            MaxTrafficCars_2_0 = *(bytePtrT + 0xF0);
            MaxTrafficCars_2_1 = *(bytePtrT + 0xF1);
            MaxTrafficCars_3_0 = *(bytePtrT + 0xF2);
            MaxTrafficCars_3_1 = *(bytePtrT + 0xF3);
            TrafAllowedNearStartgrid = *(bytePtrT + 0xF4);
            TrafAllowedNearFinishline = *(bytePtrT + 0xF5);
            CarRaceStartConfig = *(short*) (bytePtrT + 0xF6);
            TrafMinInitDistFromStart = *(float*) (bytePtrT + 0xF8);
            TrafMinInitDistFromFinish = *(float*) (bytePtrT + 0xFC);
            TrafMinInitDistInbetweenA = *(float*) (bytePtrT + 0x100);
            TrafMinInitDistInbetweenB = *(float*) (bytePtrT + 0x104);
            TrafOncomingFraction1 = *(float*) (bytePtrT + 0x108);
            TrafOncomingFraction2 = *(float*) (bytePtrT + 0x10C);
            TrafOncomingFraction3 = *(float*) (bytePtrT + 0x110);
            TrafOncomingFraction4 = *(float*) (bytePtrT + 0x114);
            MenuMapZoomOffsetX = *(float*) (bytePtrT + 0x118);
            MenuMapZoomOffsetY = *(float*) (bytePtrT + 0x11C);
            MenuMapZoomWidth = *(float*) (bytePtrT + 0x120);
            MenuMapStartZoomed = *(int*) (bytePtrT + 0x124);
        }
    }
}