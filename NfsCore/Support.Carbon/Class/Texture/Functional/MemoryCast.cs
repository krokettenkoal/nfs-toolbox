using System;
using NfsCore.Reflection.Abstract;

namespace NfsCore.Support.Carbon.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="collectionName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string collectionName)
        {
            var result = new Texture(collectionName, ParentTpkName, Database)
            {
                _offsetS = _offsetS,
                _offsetT = _offsetT,
                _scaleS = _scaleS,
                _scaleT = _scaleT,
                _scrollType = _scrollType,
                _scrollTimeStep = _scrollTimeStep,
                _scrollSpeedS = _scrollSpeedS,
                _scrollSpeedT = _scrollSpeedT,
                _area = _area,
                _numPalettes = _numPalettes,
                _applyAlphaSort = _applyAlphaSort,
                _alphaUsageType = _alphaUsageType,
                _alphaBlendType = _alphaBlendType,
                _cubeEnvironment = _cubeEnvironment,
                _biasLevel = _biasLevel,
                _renderingOrder = _renderingOrder,
                _usedFlag = _usedFlag,
                _flags = _flags,
                _padding = _padding,
                _unknown1 = _unknown1,
                _unknown2 = _unknown2,
                _unknown3 = _unknown3,
                _class = _class,
                CompressionId = CompressionId,
                PalComp = PalComp,
                Mipmaps = Mipmaps,
                MipmapBiasType = MipmapBiasType,
                Height = Height,
                Width = Width,
                TileableUV = TileableUV,
                Offset = Offset,
                Size = Size,
                PaletteOffset = PaletteOffset,
                PaletteSize = PaletteSize,
                Data = new byte[Data.Length]
            };

            Buffer.BlockCopy(Data, 0, result.Data, 0, Data.Length);
            return result;
        }
    }
}