using NfsCore.Reflection;
using NfsCore.Reflection.Enum;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace
    {
        public unsafe void Assemble(byte* bytePtrT, MemoryWriter mw)
        {
            var pointer = (ushort) mw.Position;
            mw.WriteNullTerminated(CollectionName);
            *(ushort*) bytePtrT = pointer;

            if (_introMovie != BaseArguments.NULL)
            {
                pointer = (ushort) mw.Position;
                mw.WriteNullTerminated(_introMovie);
                *(ushort*) (bytePtrT + 0x02) = pointer;
            }

            if (_outroMovie != BaseArguments.NULL)
            {
                pointer = (ushort) mw.Position;
                mw.WriteNullTerminated(_outroMovie);
                *(ushort*) (bytePtrT + 0x04) = pointer;
            }

            if (_eventTrigger != BaseArguments.NULL)
            {
                pointer = (ushort) mw.Position;
                mw.WriteNullTerminated(_eventTrigger);
                *(ushort*) (bytePtrT + 0x06) = pointer;
            }

            *(uint*) (bytePtrT + 0x08) = BinKey;
            *(bytePtrT + 0x0C) = (byte) _unlockMethod;
            *(bytePtrT + 0x0D) = (byte) _isSuvRace;
            *(bytePtrT + 0x0E) = _padding0;
            *(bytePtrT + 0x0F) = (byte) _eventBehavior;

            if (_unlockMethod == eUnlockCondition.SPECIFIC_RACE_WON)
                *(uint*) (bytePtrT + 0x10) = Bin.SmartHash(_requiredSpecRaceWon);
            else
            {
                *(bytePtrT + 0x10) = RequiredSpecificURLWon;
                *(bytePtrT + 0x11) = SponsorChosenToUnlock;
                *(bytePtrT + 0x12) = RequiredRacesWon;
                *(bytePtrT + 0x13) = RequiredURLWon;
            }

            *(int*) (bytePtrT + 0x14) = EarnableRespect;
            *(ushort*) (bytePtrT + 0x18) = TrackID_Stage1;
            *(ushort*) (bytePtrT + 0x1C) = TrackID_Stage2;
            *(ushort*) (bytePtrT + 0x20) = TrackID_Stage3;
            *(ushort*) (bytePtrT + 0x24) = TrackID_Stage4;
            *(bytePtrT + 0x1A) = (byte) InReverseDirection_Stage1;
            *(bytePtrT + 0x1E) = (byte) InReverseDirection_Stage2;
            *(bytePtrT + 0x22) = (byte) InReverseDirection_Stage3;
            *(bytePtrT + 0x26) = (byte) InReverseDirection_Stage4;
            *(bytePtrT + 0x1B) = NumLaps_Stage1;
            *(bytePtrT + 0x1F) = NumLaps_Stage2;
            *(bytePtrT + 0x23) = NumLaps_Stage3;
            *(bytePtrT + 0x27) = NumLaps_Stage4;

            *(uint*) (bytePtrT + 0x28) = Bin.Hash(_eventTrigger);
            *(uint*) (bytePtrT + 0x2C) = Bin.SmartHash(_playerCarType);
            *(int*) (bytePtrT + 0x30) = CashValue;
            *(bytePtrT + 0x34) = (byte) _eventIconType;
            *(bytePtrT + 0x35) = (byte) _isDriveToGps;
            *(bytePtrT + 0x36) = (byte) _difficultyLevel;
            *(bytePtrT + 0x37) = BelongsToStage;
            *(bytePtrT + 0x38) = NumMapItems;
            *(bytePtrT + 0x39) = _padding1;
            *(bytePtrT + 0x3A) = Unknown0x3A;
            *(bytePtrT + 0x3B) = Unknown0x3B;
            *(uint*) (bytePtrT + 0x3C) = Bin.SmartHash(_gpsDestination);

            *(bytePtrT + 0x7C) = _numOfOpponents;
            *(bytePtrT + 0x7D) = UnknownDragValue;
            *(bytePtrT + 0x7E) = _numOfStages;
            *(bytePtrT + 0x7F) = (byte) _isHiddenEvent;
            *(int*) (bytePtrT + 0x80) = _padding2;
            *(int*) (bytePtrT + 0x84) = _padding3;

            // Goto based on whether event is a drift downhill
            if (DriftTypeIfDriftRace == eDriftType.DOWNHILL)
                goto LABEL_DRIFT_DOWNHILL;

            // If none of the events are drift downhill, write opponent data based on number of the opponents
            if (_numOfOpponents > 0)
            {
                if (OPPONENT1.Name != BaseArguments.NULL)
                {
                    pointer = (ushort) mw.Position;
                    mw.WriteNullTerminated(OPPONENT1.Name);
                    *(ushort*) (bytePtrT + 0x40) = pointer;
                }

                *(ushort*) (bytePtrT + 0x42) = OPPONENT1.StatsMultiplier;
                *(uint*) (bytePtrT + 0x44) = Bin.SmartHash(OPPONENT1.PresetRide);
                *(bytePtrT + 0x48) = OPPONENT1.SkillEasy;
                *(bytePtrT + 0x49) = OPPONENT1.SkillMedium;
                *(bytePtrT + 0x4A) = OPPONENT1.SkillHard;
                *(bytePtrT + 0x4B) = OPPONENT1.CatchUp;
            }

            if (_numOfOpponents > 1)
            {
                if (OPPONENT2.Name != BaseArguments.NULL)
                {
                    pointer = (ushort) mw.Position;
                    mw.WriteNullTerminated(OPPONENT2.Name);
                    *(ushort*) (bytePtrT + 0x4C) = pointer;
                }

                *(ushort*) (bytePtrT + 0x4E) = OPPONENT2.StatsMultiplier;
                *(uint*) (bytePtrT + 0x50) = Bin.SmartHash(OPPONENT2.PresetRide);
                *(bytePtrT + 0x54) = OPPONENT2.SkillEasy;
                *(bytePtrT + 0x55) = OPPONENT2.SkillMedium;
                *(bytePtrT + 0x56) = OPPONENT2.SkillHard;
                *(bytePtrT + 0x57) = OPPONENT2.CatchUp;
            }

            if (_numOfOpponents > 2)
            {
                if (OPPONENT3.Name != BaseArguments.NULL)
                {
                    pointer = (ushort) mw.Position;
                    mw.WriteNullTerminated(OPPONENT3.Name);
                    *(ushort*) (bytePtrT + 0x58) = pointer;
                }

                *(ushort*) (bytePtrT + 0x5A) = OPPONENT3.StatsMultiplier;
                *(uint*) (bytePtrT + 0x5C) = Bin.SmartHash(OPPONENT3.PresetRide);
                *(bytePtrT + 0x60) = OPPONENT3.SkillEasy;
                *(bytePtrT + 0x61) = OPPONENT3.SkillMedium;
                *(bytePtrT + 0x62) = OPPONENT3.SkillHard;
                *(bytePtrT + 0x63) = OPPONENT3.CatchUp;
            }

            if (_numOfOpponents > 3)
            {
                if (OPPONENT4.Name != BaseArguments.NULL)
                {
                    pointer = (ushort) mw.Position;
                    mw.WriteNullTerminated(OPPONENT4.Name);
                    *(ushort*) (bytePtrT + 0x64) = pointer;
                }

                *(ushort*) (bytePtrT + 0x66) = OPPONENT4.StatsMultiplier;
                *(uint*) (bytePtrT + 0x68) = Bin.SmartHash(OPPONENT4.PresetRide);
                *(bytePtrT + 0x6C) = OPPONENT4.SkillEasy;
                *(bytePtrT + 0x6D) = OPPONENT4.SkillMedium;
                *(bytePtrT + 0x6E) = OPPONENT4.SkillHard;
                *(bytePtrT + 0x6F) = OPPONENT4.CatchUp;
            }

            if (_numOfOpponents > 4)
            {
                if (OPPONENT5.Name != BaseArguments.NULL)
                {
                    pointer = (ushort) mw.Position;
                    mw.WriteNullTerminated(OPPONENT5.Name);
                    *(ushort*) (bytePtrT + 0x70) = pointer;
                }

                *(ushort*) (bytePtrT + 0x72) = OPPONENT5.StatsMultiplier;
                *(uint*) (bytePtrT + 0x74) = Bin.SmartHash(OPPONENT5.PresetRide);
                *(bytePtrT + 0x78) = OPPONENT5.SkillEasy;
                *(bytePtrT + 0x79) = OPPONENT5.SkillMedium;
                *(bytePtrT + 0x7A) = OPPONENT5.SkillHard;
                *(bytePtrT + 0x7B) = OPPONENT5.CatchUp;
            }

            return;

            // If at least one of the events is drift downhill, write at least 3 opponents
            LABEL_DRIFT_DOWNHILL:
            if (OPPONENT1.Name != BaseArguments.NULL)
            {
                pointer = (ushort) mw.Position;
                mw.WriteNullTerminated(OPPONENT1.Name);
                *(ushort*) (bytePtrT + 0x40) = pointer;
            }

            *(ushort*) (bytePtrT + 0x42) = OPPONENT1.StatsMultiplier;
            *(uint*) (bytePtrT + 0x44) = Bin.SmartHash(OPPONENT1.PresetRide);
            *(bytePtrT + 0x48) = OPPONENT1.SkillEasy;
            *(bytePtrT + 0x49) = OPPONENT1.SkillMedium;
            *(bytePtrT + 0x4A) = OPPONENT1.SkillHard;
            *(bytePtrT + 0x4B) = OPPONENT1.CatchUp;

            if (OPPONENT2.Name != BaseArguments.NULL)
            {
                pointer = (ushort) mw.Position;
                mw.WriteNullTerminated(OPPONENT2.Name);
                *(ushort*) (bytePtrT + 0x4C) = pointer;
            }

            *(ushort*) (bytePtrT + 0x4E) = OPPONENT2.StatsMultiplier;
            *(uint*) (bytePtrT + 0x50) = Bin.SmartHash(OPPONENT2.PresetRide);
            *(bytePtrT + 0x54) = OPPONENT2.SkillEasy;
            *(bytePtrT + 0x55) = OPPONENT2.SkillMedium;
            *(bytePtrT + 0x56) = OPPONENT2.SkillHard;
            *(bytePtrT + 0x57) = OPPONENT2.CatchUp;

            if (OPPONENT3.Name != BaseArguments.NULL)
            {
                pointer = (ushort) mw.Position;
                mw.WriteNullTerminated(OPPONENT3.Name);
                *(ushort*) (bytePtrT + 0x58) = pointer;
            }

            *(ushort*) (bytePtrT + 0x5A) = OPPONENT3.StatsMultiplier;
            *(uint*) (bytePtrT + 0x5C) = Bin.SmartHash(OPPONENT3.PresetRide);
            *(bytePtrT + 0x60) = OPPONENT3.SkillEasy;
            *(bytePtrT + 0x61) = OPPONENT3.SkillMedium;
            *(bytePtrT + 0x62) = OPPONENT3.SkillHard;
            *(bytePtrT + 0x63) = OPPONENT3.CatchUp;

            if (_numOfOpponents > 3)
            {
                if (OPPONENT4.Name != BaseArguments.NULL)
                {
                    pointer = (ushort) mw.Position;
                    mw.WriteNullTerminated(OPPONENT4.Name);
                    *(ushort*) (bytePtrT + 0x64) = pointer;
                }

                *(ushort*) (bytePtrT + 0x66) = OPPONENT4.StatsMultiplier;
                *(uint*) (bytePtrT + 0x68) = Bin.SmartHash(OPPONENT4.PresetRide);
                *(bytePtrT + 0x6C) = OPPONENT4.SkillEasy;
                *(bytePtrT + 0x6D) = OPPONENT4.SkillMedium;
                *(bytePtrT + 0x6E) = OPPONENT4.SkillHard;
                *(bytePtrT + 0x6F) = OPPONENT4.CatchUp;
            }

            if (_numOfOpponents <= 4) return;
            if (OPPONENT5.Name != BaseArguments.NULL)
            {
                pointer = (ushort) mw.Position;
                mw.WriteNullTerminated(OPPONENT5.Name);
                *(ushort*) (bytePtrT + 0x70) = pointer;
            }

            *(ushort*) (bytePtrT + 0x72) = OPPONENT5.StatsMultiplier;
            *(uint*) (bytePtrT + 0x74) = Bin.SmartHash(OPPONENT5.PresetRide);
            *(bytePtrT + 0x78) = OPPONENT5.SkillEasy;
            *(bytePtrT + 0x79) = OPPONENT5.SkillMedium;
            *(bytePtrT + 0x7A) = OPPONENT5.SkillHard;
            *(bytePtrT + 0x7B) = OPPONENT5.CatchUp;
        }
    }
}