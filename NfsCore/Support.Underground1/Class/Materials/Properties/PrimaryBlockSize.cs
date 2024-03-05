namespace NfsCore.Support.Underground1.Class
{
    public partial class Material
    {
        /// <summary>
        /// Size of one material block.
        /// </summary>
        public int Size { get; } = 0xA0;

        private const uint ClassKey = 0x004114C5;
    }
}