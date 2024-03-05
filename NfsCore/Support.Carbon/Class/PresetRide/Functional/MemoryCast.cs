using System;
using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new PresetRide(collectionName, Database)
            {
                _brightness = _brightness,
                _saturation = _saturation,
                _paintType = _paintType,
                _paintSwatch = _paintSwatch,
                _exhaustStyle = _exhaustStyle,
                _exhaustSize = _exhaustSize,
                _isCenterExhaust = _isCenterExhaust,
                _hoodStyle = _hoodStyle,
                _isAutoSculptHood = _isAutoSculptHood,
                _isCarbonFibreHood = _isCarbonFibreHood,
                _spoilerStyle = _spoilerStyle,
                _spoilerType = _spoilerType,
                _isAutoSculptSpoiler = _isAutoSculptSpoiler,
                _isCarbonFibreSpoiler = _isCarbonFibreSpoiler,
                _autoSculptRearBumper = _autoSculptRearBumper,
                _autoSculptSkirt = _autoSculptSkirt,
                _roofScoopStyle = _roofScoopStyle,
                _isAutoSculptRoofScoop = _isAutoSculptRoofScoop,
                _isDualRoofScoop = _isDualRoofScoop,
                IsCarbonfibreRoofScoop = _isCarbonFibreRoofScoop,
                _rimBrand = _rimBrand,
                _rimStyle = _rimStyle,
                _rimSize = _rimSize,
                _popupHeadlightsExist = _popupHeadlightsExist,
                _popupHeadlightsOn = _popupHeadlightsOn,
                _chopTopIsOn = _chopTopIsOn,
                _chopTopSize = _chopTopSize,
                _windowTintType = _windowTintType,
                _specificVinyl = _specificVinyl,
                _genericVinyl = _genericVinyl,
                _autoSculptFrontBumper = _autoSculptFrontBumper,
                _aftermarketBodyKit = _aftermarketBodyKit,
                MODEL = MODEL,
                Pvehicle = Pvehicle,
                Frontend = Frontend,
                FRONTBUMPER = FRONTBUMPER.PlainCopy(),
                REARBUMPER = REARBUMPER.PlainCopy(),
                SKIRT = SKIRT.PlainCopy(),
                WHEELS = WHEELS.PlainCopy(),
                HOOD = HOOD.PlainCopy(),
                SPOILER = SPOILER.PlainCopy(),
                ROOFSCOOP = ROOFSCOOP.PlainCopy(),
                VINYL01 = VINYL01.PlainCopy(),
                VINYL02 = VINYL02.PlainCopy(),
                VINYL03 = VINYL03.PlainCopy(),
                VINYL04 = VINYL04.PlainCopy(),
                VINYL05 = VINYL05.PlainCopy(),
                VINYL06 = VINYL06.PlainCopy(),
                VINYL07 = VINYL07.PlainCopy(),
                VINYL08 = VINYL08.PlainCopy(),
                VINYL09 = VINYL09.PlainCopy(),
                VINYL10 = VINYL10.PlainCopy(),
                VINYL11 = VINYL11.PlainCopy(),
                VINYL12 = VINYL12.PlainCopy(),
                VINYL13 = VINYL13.PlainCopy(),
                VINYL14 = VINYL14.PlainCopy(),
                VINYL15 = VINYL15.PlainCopy(),
                VINYL16 = VINYL16.PlainCopy(),
                VINYL17 = VINYL17.PlainCopy(),
                VINYL18 = VINYL18.PlainCopy(),
                VINYL19 = VINYL19.PlainCopy(),
                VINYL20 = VINYL20.PlainCopy()
            };

            Buffer.BlockCopy(_data, 0, result._data, 0, _data.Length);

            return result;
        }
    }
}