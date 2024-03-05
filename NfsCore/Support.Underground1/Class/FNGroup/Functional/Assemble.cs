using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground1.Class
{
    public partial class FNGroup
    {
        /// <summary>
        /// Assembles frontend group into a byte array.
        /// </summary>
        /// <returns>Byte array of the frontend group.</returns>
        public override unsafe byte[] Assemble()
        {
            fixed (byte* bytePtrT = &_DATA[0])
            {
                *(uint*) bytePtrT = GlobalId.FEngFiles;
                *(uint*) (bytePtrT + 4) = Size;

                foreach (var color in ColorInfo)
                {
                    *(uint*) (bytePtrT + color.Offset + 4) = (uint) color.Blue;
                    *(uint*) (bytePtrT + color.Offset + 8) = (uint) color.Green;
                    *(uint*) (bytePtrT + color.Offset + 12) = (uint) color.Red;
                    *(uint*) (bytePtrT + color.Offset + 16) = (uint) color.Alpha;
                }
            }

            return _DATA;
        }
    }
}