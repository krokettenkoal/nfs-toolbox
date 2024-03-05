using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerRace
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new GCareerRace(collectionName, Database)
            {
                _introMovie = _introMovie,
                _outroMovie = _outroMovie,
                _eventTrigger = _eventTrigger,
                _unlockMethod = _unlockMethod,
                _isSuvRace = _isSuvRace,
                _isHiddenEvent = _isHiddenEvent,
                _isDriveToGps = _isDriveToGps,
                _eventBehavior = _eventBehavior,
                _requiredSpecRaceWon = _requiredSpecRaceWon,
                RequiredRacesWon = RequiredRacesWon,
                RequiredSpecificURLWon = RequiredSpecificURLWon,
                RequiredURLWon = RequiredURLWon,
                SponsorChosenToUnlock = SponsorChosenToUnlock,
                EarnableRespect = EarnableRespect,
                TrackID_Stage1 = TrackID_Stage1,
                TrackID_Stage2 = TrackID_Stage2,
                TrackID_Stage3 = TrackID_Stage3,
                TrackID_Stage4 = TrackID_Stage4,
                _inReverseStage1 = _inReverseStage1,
                _inReverseStage2 = _inReverseStage2,
                _inReverseStage3 = _inReverseStage3,
                _inReverseStage4 = _inReverseStage4,
                NumLaps_Stage1 = NumLaps_Stage1,
                NumLaps_Stage2 = NumLaps_Stage2,
                NumLaps_Stage3 = NumLaps_Stage3,
                NumLaps_Stage4 = NumLaps_Stage4,
                _playerCarType = _playerCarType,
                CashValue = CashValue,
                _eventIconType = _eventIconType,
                DifficultyLevel = DifficultyLevel,
                BelongsToStage = BelongsToStage,
                NumMapItems = NumMapItems,
                Unknown0x3A = Unknown0x3A,
                Unknown0x3B = Unknown0x3B,
                _numOfOpponents = _numOfOpponents,
                _numOfStages = _numOfStages,
                UnknownDragValue = UnknownDragValue,
                _gpsDestination = _gpsDestination,
                OPPONENT1 = OPPONENT1.PlainCopy(),
                OPPONENT2 = OPPONENT2.PlainCopy(),
                OPPONENT3 = OPPONENT3.PlainCopy(),
                OPPONENT4 = OPPONENT4.PlainCopy(),
                OPPONENT5 = OPPONENT5.PlainCopy(),
                _padding0 = _padding0,
                _padding1 = _padding1,
                _padding2 = _padding2,
                _padding3 = _padding3
            };
            return result;
        }
    }
}