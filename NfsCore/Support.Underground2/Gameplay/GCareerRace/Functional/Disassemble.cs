using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace
    {
        protected unsafe void Disassemble(byte* ptrHeader, byte* ptrString)
        {
            // Collection Name
            var pointer = *(ushort*) ptrHeader; // used for reading pointer data
            CollName = ScriptX.NullTerminatedString(ptrString + pointer);

            // Intro Movie
            pointer = *(ushort*) (ptrHeader + 2);
            var str = ScriptX.NullTerminatedString(ptrString + pointer);
            if (!string.IsNullOrWhiteSpace(str)) _introMovie = str;

            // Outro Movie
            pointer = *(ushort*) (ptrHeader + 4);
            str = ScriptX.NullTerminatedString(ptrString + pointer);
            if (!string.IsNullOrWhiteSpace(str)) _outroMovie = str;

            // Event Trigger
            pointer = *(ushort*) (ptrHeader + 6);
            str = ScriptX.NullTerminatedString(ptrString + pointer);
            if (!string.IsNullOrWhiteSpace(str)) _eventTrigger = str;

            // Event behavior
            _unlockMethod = (eUnlockCondition) (*(ptrHeader + 0xC));
            _isSuvRace = (eBoolean) (*(ptrHeader + 0xD));
            _padding0 = *(ptrHeader + 0xE);
            _eventBehavior = (eEventBehaviorType) (*(ptrHeader + 0xF));

            // Unlock conditions
            var key = *(uint*) (ptrHeader + 0x10); // for reading keys and comparison
            if (_unlockMethod == eUnlockCondition.SPECIFIC_RACE_WON)
                _requiredSpecRaceWon = Map.Lookup(key, true) ?? BaseArguments.NULL;
            else
            {
                RequiredSpecificURLWon = *(ptrHeader + 0x10);
                SponsorChosenToUnlock = *(ptrHeader + 0x11);
                RequiredRacesWon = *(ptrHeader + 0x12);
                RequiredURLWon = *(ptrHeader + 0x13);
            }

            // Earnable Respect ?
            EarnableRespect = *(int*) (ptrHeader + 0x14);

            // Stage Values
            _numOfStages = *(ptrHeader + 0x7E);
            TrackID_Stage1 = *(ushort*) (ptrHeader + 0x18);
            TrackID_Stage2 = *(ushort*) (ptrHeader + 0x1C);
            TrackID_Stage3 = *(ushort*) (ptrHeader + 0x20);
            TrackID_Stage4 = *(ushort*) (ptrHeader + 0x24);
            InReverseDirection_Stage1 = (eBoolean) (*(ptrHeader + 0x1A) % 2);
            InReverseDirection_Stage2 = (eBoolean) (*(ptrHeader + 0x1E) % 2);
            InReverseDirection_Stage3 = (eBoolean) (*(ptrHeader + 0x22) % 2);
            InReverseDirection_Stage4 = (eBoolean) (*(ptrHeader + 0x26) % 2);
            NumLaps_Stage1 = *(ptrHeader + 0x1B);
            NumLaps_Stage2 = *(ptrHeader + 0x1F);
            NumLaps_Stage3 = *(ptrHeader + 0x23);
            NumLaps_Stage4 = *(ptrHeader + 0x27);

            // PlayerCarType and CashValue
            key = *(uint*) (ptrHeader + 0x2C);
            _playerCarType = Map.Lookup(key, true) ?? $"0x{key:X8}";
            CashValue = *(int*) (ptrHeader + 0x30);

            // Some UnknownValues
            _eventIconType = (eEventIconType) (*(ptrHeader + 0x34));
            _isDriveToGps = (*(ptrHeader + 0x35) == 0) ? eBoolean.False : eBoolean.True;
            DifficultyLevel = (eTrackDifficulty) (*(ptrHeader + 0x36));
            BelongsToStage = *(ptrHeader + 0x37);

            // Some values
            NumMapItems = *(ptrHeader + 0x38);
            _padding1 = *(ptrHeader + 0x39);
            Unknown0x3A = *(ptrHeader + 0x3A);
            Unknown0x3B = *(ptrHeader + 0x3B);
            _numOfOpponents = *(ptrHeader + 0x7C);
            UnknownDragValue = *(ptrHeader + 0x7D);
            IsHiddenEvent = (eBoolean) (*(ptrHeader + 0x7F));
            _padding2 = *(int*) (ptrHeader + 0x80);
            _padding3 = *(int*) (ptrHeader + 0x84);

            // GPS Destination
            key = *(uint*) (ptrHeader + 0x3C);
            _gpsDestination = Map.Lookup(key, true) ?? $"0x{key:X8}";

            // Determine to which label to go based on event and drift type
            // Downhill drift races have NumOpponents = 0, while opponent data has always 3
            if (DriftTypeIfDriftRace == eDriftType.DOWNHILL)
                goto LABEL_DRIFT_DOWNHILL;

            // If none of the events are drift downhill, read opponent data based on number of the opponents
            if (_numOfOpponents > 0)
            {
                pointer = *(ushort*) (ptrHeader + 0x40);
                str = ScriptX.NullTerminatedString(ptrString + pointer);
                if (!string.IsNullOrWhiteSpace(str)) OPPONENT1.Name = str;
                OPPONENT1.StatsMultiplier = *(ushort*) (ptrHeader + 0x42);
                key = *(uint*) (ptrHeader + 0x44);
                OPPONENT1.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
                OPPONENT1.SkillEasy = *(ptrHeader + 0x48);
                OPPONENT1.SkillMedium = *(ptrHeader + 0x49);
                OPPONENT1.SkillHard = *(ptrHeader + 0x4A);
                OPPONENT1.CatchUp = *(ptrHeader + 0x4B);
            }

            if (_numOfOpponents > 1)
            {
                pointer = *(ushort*) (ptrHeader + 0x4C);
                str = ScriptX.NullTerminatedString(ptrString + pointer);
                if (!string.IsNullOrWhiteSpace(str)) OPPONENT2.Name = str;
                OPPONENT2.StatsMultiplier = *(ushort*) (ptrHeader + 0x4E);
                key = *(uint*) (ptrHeader + 0x50);
                OPPONENT2.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
                OPPONENT2.SkillEasy = *(ptrHeader + 0x54);
                OPPONENT2.SkillMedium = *(ptrHeader + 0x55);
                OPPONENT2.SkillHard = *(ptrHeader + 0x56);
                OPPONENT2.CatchUp = *(ptrHeader + 0x57);
            }

            if (_numOfOpponents > 2)
            {
                pointer = *(ushort*) (ptrHeader + 0x58);
                str = ScriptX.NullTerminatedString(ptrString + pointer);
                if (!string.IsNullOrWhiteSpace(str)) OPPONENT3.Name = str;
                OPPONENT3.StatsMultiplier = *(ushort*) (ptrHeader + 0x5A);
                key = *(uint*) (ptrHeader + 0x5C);
                OPPONENT3.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
                OPPONENT3.SkillEasy = *(ptrHeader + 0x60);
                OPPONENT3.SkillMedium = *(ptrHeader + 0x61);
                OPPONENT3.SkillHard = *(ptrHeader + 0x62);
                OPPONENT3.CatchUp = *(ptrHeader + 0x63);
            }

            if (_numOfOpponents > 3)
            {
                pointer = *(ushort*) (ptrHeader + 0x64);
                str = ScriptX.NullTerminatedString(ptrString + pointer);
                if (!string.IsNullOrWhiteSpace(str)) OPPONENT4.Name = str;
                OPPONENT4.StatsMultiplier = *(ushort*) (ptrHeader + 0x66);
                key = *(uint*) (ptrHeader + 0x68);
                OPPONENT4.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
                OPPONENT4.SkillEasy = *(ptrHeader + 0x6C);
                OPPONENT4.SkillMedium = *(ptrHeader + 0x6D);
                OPPONENT4.SkillHard = *(ptrHeader + 0x6E);
                OPPONENT4.CatchUp = *(ptrHeader + 0x6F);
            }

            if (_numOfOpponents <= 4) return;
            pointer = *(ushort*) (ptrHeader + 0x70);
            str = ScriptX.NullTerminatedString(ptrString + pointer);
            if (!string.IsNullOrWhiteSpace(str)) OPPONENT5.Name = str;
            OPPONENT5.StatsMultiplier = *(ushort*) (ptrHeader + 0x72);
            key = *(uint*) (ptrHeader + 0x74);
            OPPONENT5.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
            OPPONENT5.SkillEasy = *(ptrHeader + 0x78);
            OPPONENT5.SkillMedium = *(ptrHeader + 0x79);
            OPPONENT5.SkillHard = *(ptrHeader + 0x7A);
            OPPONENT5.CatchUp = *(ptrHeader + 0x7B);

            return;

            // If at least one of the events is downhill drift, read only 3 opponents
            LABEL_DRIFT_DOWNHILL:
            pointer = *(ushort*) (ptrHeader + 0x40);
            str = ScriptX.NullTerminatedString(ptrString + pointer);
            if (!string.IsNullOrWhiteSpace(str)) OPPONENT1.Name = str;
            OPPONENT1.StatsMultiplier = *(ushort*) (ptrHeader + 0x42);
            key = *(uint*) (ptrHeader + 0x44);
            OPPONENT1.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
            OPPONENT1.SkillEasy = *(ptrHeader + 0x48);
            OPPONENT1.SkillMedium = *(ptrHeader + 0x49);
            OPPONENT1.SkillHard = *(ptrHeader + 0x4A);
            OPPONENT1.CatchUp = *(ptrHeader + 0x4B);

            pointer = *(ushort*) (ptrHeader + 0x4C);
            str = ScriptX.NullTerminatedString(ptrString + pointer);
            if (!string.IsNullOrWhiteSpace(str)) OPPONENT2.Name = str;
            OPPONENT2.StatsMultiplier = *(ushort*) (ptrHeader + 0x4E);
            key = *(uint*) (ptrHeader + 0x50);
            OPPONENT2.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
            OPPONENT2.SkillEasy = *(ptrHeader + 0x54);
            OPPONENT2.SkillMedium = *(ptrHeader + 0x55);
            OPPONENT2.SkillHard = *(ptrHeader + 0x56);
            OPPONENT2.CatchUp = *(ptrHeader + 0x57);

            pointer = *(ushort*) (ptrHeader + 0x58);
            str = ScriptX.NullTerminatedString(ptrString + pointer);
            if (!string.IsNullOrWhiteSpace(str)) OPPONENT3.Name = str;
            OPPONENT3.StatsMultiplier = *(ushort*) (ptrHeader + 0x5A);
            key = *(uint*) (ptrHeader + 0x5C);
            OPPONENT3.PresetRide = Map.Lookup(key, true) ?? $"0x{key:X8}";
            OPPONENT3.SkillEasy = *(ptrHeader + 0x60);
            OPPONENT3.SkillMedium = *(ptrHeader + 0x61);
            OPPONENT3.SkillHard = *(ptrHeader + 0x62);
            OPPONENT3.CatchUp = *(ptrHeader + 0x63);
        }
    }
}