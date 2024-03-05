namespace NfsCore.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Checks texture keys and tpk keys for matching.
        /// </summary>
        protected override void CheckKeys()
        {
            _keys.Clear();
            foreach (var t in Textures)
                _keys.Add(t.BinKey);
        }
    }
}