using NfsCore.Support.Carbon.Parts.PresetParts;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Returns autosculpt part of the preset ride using length of the name of the part.
        /// </summary>
        /// <param name="length">Length of the name of the part.</param>
        /// <returns>Autosculpt part class of the preset ride.</returns>
        public Autosculpt AutoByParameter(int length)
        {
            return length switch
            {
                4 => HOOD,
                5 => SKIRT,
                6 => WHEELS,
                7 => SPOILER,
                9 => ROOFSCOOP,
                10 => REARBUMPER,
                11 => FRONTBUMPER,
                _ => null
            };
        }

        /// <summary>
        /// Returns autosculpt part of the preset ride using name of the part.
        /// </summary>
        /// <param name="name">Name of the part.</param>
        /// <returns>Autosculpt part class of the preset ride.</returns>
        public Autosculpt AutoByParameter(string name)
        {
            return name switch
            {
                "HOOD" => HOOD,
                "SKIRT" => SKIRT,
                "WHEELS" => WHEELS,
                "SPOILER" => SPOILER,
                "ROOFSCOOP" => ROOFSCOOP,
                "REARBUMPER" => REARBUMPER,
                "FRONTBUMPER" => FRONTBUMPER,
                _ => null
            };
        }
    }
}