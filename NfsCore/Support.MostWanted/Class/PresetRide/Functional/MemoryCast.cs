using System;
using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.MostWanted.Class
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
                _hoodStyle = _hoodStyle,
                _isCarbonFibreHood = _isCarbonFibreHood,
                _spoilerStyle = _spoilerStyle,
                _spoilerType = _spoilerType,
                _isCarbonFibreSpoiler = _isCarbonFibreSpoiler,
                _roofScoopStyle = _roofScoopStyle,
                _isOffsetRoofScoop = _isOffsetRoofScoop,
                _isDualRoofScoop = _isDualRoofScoop,
                IsCarbonfibreRoofScoop = _isCarbonFibreRoofScoop,
                _rimBrand = _rimBrand,
                _rimStyle = _rimStyle,
                _rimSize = _rimSize,
                _windowTintType = _windowTintType,
                _aftermarketBodyKit = _aftermarketBodyKit,
                _bodyPaint = _bodyPaint,
                _rimPaint = _rimPaint,
                _vinylName = _vinylName,
                _vinylColor1 = _vinylColor1,
                _vinylColor2 = _vinylColor2,
                _vinylColor3 = _vinylColor3,
                _vinylColor4 = _vinylColor4,
                MODEL = MODEL,
                Pvehicle = Pvehicle,
                Frontend = Frontend
            };

            Buffer.BlockCopy(_data, 0, result._data, 0, _data.Length);

            return result;
        }
    }
}