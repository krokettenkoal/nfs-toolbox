using GlobalLib.Reflection.Abstract;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            var result = new Texture(CName, _parent_TPK, Database)
            {
                _offsetS = _offsetS,
                _offsetT = _offsetT,
                _scaleS = _scaleS,
                _scaleT = _scaleT,
                _scroll_type = _scroll_type,
                _scroll_timestep = _scroll_timestep,
                _scroll_speedS = _scroll_speedS,
                _scroll_speedT = _scroll_speedT,
                _area = _area,
                _num_palettes = _num_palettes,
                _apply_alpha_sort = _apply_alpha_sort,
                _alpha_usage_type = _alpha_usage_type,
                _alpha_blend_type = _alpha_blend_type,
                _cube_environment = _cube_environment,
                _bias_level = _bias_level,
                _rendering_order = _rendering_order,
                _used_flag = _used_flag,
                _flags = _flags,
                _padding = _padding,
                _unknown1 = _unknown1,
                _unknown2 = _unknown2,
                _unknown3 = _unknown3,
                _class = _class,
                CompressionId = CompressionId,
                _pal_comp = _pal_comp,
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