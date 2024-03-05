using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new PresetSkin(collectionName, Database)
            {
                PositionY = PositionY,
                PositionX = PositionX,
                Rotation = Rotation,
                Skew = Skew,
                ScaleY = ScaleY,
                ScaleX = ScaleX,
                Saturation1 = Saturation1,
                Saturation2 = Saturation2,
                Saturation3 = Saturation3,
                Saturation4 = Saturation4,
                Brightness1 = Brightness1,
                Brightness2 = Brightness2,
                Brightness3 = Brightness3,
                Brightness4 = Brightness4,
                _swatch1 = _swatch1,
                _swatch2 = _swatch2,
                _swatch3 = _swatch3,
                _swatch4 = _swatch4,
                _genericVinyl = _genericVinyl,
                _vectorVinyl = _vectorVinyl,
                PaintSwatch = PaintSwatch,
                PaintBrightness = PaintBrightness,
                PaintSaturation = PaintSaturation,
                PaintType = PaintType
            };

            return result;
        }
    }
}