using NfsCore.Reflection.ID;

namespace NfsCore.Support.Underground2.Class
{
    public partial class FNGroup
    {
        /// <summary>
        /// Assembles frontend group into a byte array.
        /// </summary>
        /// <returns>Byte array of the frontend group.</returns>
        public override unsafe byte[] Assemble()
        {
            fixed (byte* bytePtrT = &_data[0])
            {
                *(uint*) bytePtrT = GlobalId.FEngFiles;
                *(uint*) (bytePtrT + 4) = Size;

                foreach (var color in ColorInfo)
                {
                    *(uint*) (bytePtrT + color.Offset + 4) = color.Blue;
                    *(uint*) (bytePtrT + color.Offset + 8) = color.Green;
                    *(uint*) (bytePtrT + color.Offset + 12) = color.Red;
                    *(uint*) (bytePtrT + color.Offset + 16) = color.Alpha;
                }
            }

            return _data;
        }
    }
}