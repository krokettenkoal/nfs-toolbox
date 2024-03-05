using System;
using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new PresetRide(collectionName, Database)
            {
                _aftermarketBodyKit = _aftermarketBodyKit,
                _autosculptFrontBumper = _autosculptFrontBumper,
                _autoSculptRearBumper = _autoSculptRearBumper,
                _autoSculptSkirt = _autoSculptSkirt,
                _brakeLightStyle = _brakeLightStyle,
                _carbonBody = _carbonBody,
                _carbonDoors = _carbonDoors,
                _carbonHood = _carbonHood,
                _carbonTrunk = _carbonTrunk,
                _customHudStyle = _customHudStyle,
                _cvMiscStyle = _cvMiscStyle,
                _decalTypeHood = _decalTypeHood,
                _decalTypeLeftQuarter = _decalTypeLeftQuarter,
                _decalTypeRightQuarter = _decalTypeRightQuarter,
                _decalWideLeftDoor = _decalWideLeftDoor,
                _decalWideLeftQuarter = _decalWideLeftQuarter,
                _decalWideRightDoor = _decalWideRightDoor,
                _decalWideRightQuarter = _decalWideRightQuarter,
                _engineStyle = _engineStyle,
                _exhaustStyle = _exhaustStyle,
                _frontBrakeStyle = _frontBrakeStyle,
                _headlightStyle = _headlightStyle,
                _hoodStyle = _hoodStyle,
                _hudBackingColor = _hudBackingColor,
                _hudCharacterColor = _hudCharacterColor,
                _hudNeedleColor = _hudNeedleColor,
                _isCarbonFibreHood = _isCarbonFibreHood,
                _isCarbonFibreRoofScoop = _isCarbonFibreRoofScoop,
                _isCarbonFibreSpoiler = _isCarbonFibreSpoiler,
                _isDualRoofScoop = _isDualRoofScoop,
                _isOffsetRoofScoop = _isOffsetRoofScoop,
                _isSpinningRim = _isSpinningRim,
                _performanceLevel = _performanceLevel,
                _rearBrakeStyle = _rearBrakeStyle,
                _rimBrand = _rimBrand,
                _rimOuterMax = _rimOuterMax,
                _rimSize = _rimSize,
                _rimStyle = _rimStyle,
                _roofScoopStyle = _roofScoopStyle,
                _spoilerStyle = _spoilerStyle,
                _spoilerType = _spoilerType,
                _trunkAudioStyle = _trunkAudioStyle,
                _underHoodStyle = _underHoodStyle,
                _unknown1 = _unknown1,
                _unknown2 = _unknown2,
                _windowTintType = _windowTintType,
                _wingMirrorStyle = _wingMirrorStyle,
                DECALS_FRONT_WINDOW = DECALS_FRONT_WINDOW.PlainCopy(),
                DECALS_HOOD = DECALS_HOOD.PlainCopy(),
                DECALS_LEFT_DOOR = DECALS_LEFT_DOOR.PlainCopy(),
                DECALS_LEFT_QUARTER = DECALS_LEFT_QUARTER.PlainCopy(),
                DECALS_REAR_WINDOW = DECALS_REAR_WINDOW.PlainCopy(),
                DECALS_RIGHT_DOOR = DECALS_RIGHT_DOOR.PlainCopy(),
                DECALS_RIGHT_QUARTER = DECALS_RIGHT_QUARTER.PlainCopy(),
                AUDIO_COMP = AUDIO_COMP.PlainCopy(),
                PAINT_TYPES = PAINT_TYPES.PlainCopy(),
                SPECIALTIES = SPECIALTIES.PlainCopy(),
                VINYL_SETS = VINYL_SETS.PlainCopy()
            };

            Buffer.BlockCopy(_data, 0, result._data, 0, _data.Length);

            return result;
        }
    }
}