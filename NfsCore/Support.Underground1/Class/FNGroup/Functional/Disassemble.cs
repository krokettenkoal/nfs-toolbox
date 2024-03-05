namespace NfsCore.Support.Underground1.Class
{
    public partial class FNGroup
    {
        protected override unsafe void Disassemble(byte[] data)
        {
            _DATA = new byte[data.Length];
            System.Buffer.BlockCopy(data, 0, _DATA, 0, data.Length);

            fixed (byte* bytePtrT = &_DATA[0])
            {
                Size = *(uint*) (bytePtrT + 4);

                // For some reason HUFF compression has the same ID as FEng files
                if (*(uint*) (bytePtrT + 8) == 0x46465548)
                {
                    Destroy = true;
                    return;
                }

                // Read CollectionName
                CollectionName = Utils.ScriptX.NullTerminatedString(bytePtrT + 0x30, _DATA.Length - 0x30);
                if (CollectionName.EndsWith(".fng"))
                    CollectionName = Utils.FormatX.GetString(CollectionName, "{X}.fng");

                for (uint offset = 0x30; offset < _DATA.Length; offset += 4)
                {
                    var b1 = *(bytePtrT + offset);
                    var b2 = *(bytePtrT + offset + 1);
                    var b3 = *(bytePtrT + offset + 2);
                    var b4 = *(bytePtrT + offset + 3);

                    // SAT, SAD, SA(0x90) or 1111
                    if ((b1 != 'S' || b2 != 'A') && (b1 != 0xFF || b2 != 0xFF || b3 != 0xFF || b4 != 0xFF)) continue;
                    var blueVal = *(uint*) (bytePtrT + offset + 4);
                    var greenVal = *(uint*) (bytePtrT + offset + 8);
                    var redVal = *(uint*) (bytePtrT + offset + 12);
                    var alphaVal = *(uint*) (bytePtrT + offset + 16);

                    // If it is a color, add to the list
                    if (Utils.EA.Resolve.IsColor(alphaVal, redVal, greenVal, blueVal))
                    {
                        var tempColor = new Shared.Parts.FNGParts.FEngColor(this)
                        {
                            Offset = offset,
                            Alpha = (byte) alphaVal,
                            Red = (byte) redVal,
                            Green = (byte) greenVal,
                            Blue = (byte) blueVal
                        };
                        ColorInfo.Add(tempColor);
                    }

                    offset += 0x14;
                }
            }
        }
    }
}