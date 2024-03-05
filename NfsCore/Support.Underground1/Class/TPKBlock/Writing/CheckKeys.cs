namespace NfsCore.Support.Underground1.Class
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