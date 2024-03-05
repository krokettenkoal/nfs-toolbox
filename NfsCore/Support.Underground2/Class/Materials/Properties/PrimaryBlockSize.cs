namespace NfsCore.Support.Underground2.Class
{
    public partial class Material
    {
        /// <summary>
        /// Size of one material block.
        /// </summary>
        internal int Size { get; } = 0xA0;

        private const uint ClassKey = 0x0041440F;
    }
}