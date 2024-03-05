using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Parts.PresetParts
{
    public class DecalArray : SubPart, ICopyable<DecalArray>
    {
        #region Private Fields

        private string _decalSlot0 = BaseArguments.NULL;
        private string _decalSlot1 = BaseArguments.NULL;
        private string _decalSlot2 = BaseArguments.NULL;
        private string _decalSlot3 = BaseArguments.NULL;
        private string _decalSlot4 = BaseArguments.NULL;
        private string _decalSlot5 = BaseArguments.NULL;
        private string _decalSlot6 = BaseArguments.NULL;
        private string _decalSlot7 = BaseArguments.NULL;

        #endregion

        #region Public Properties

        public string DecalSlot0
        {
            get => _decalSlot0;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot0 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot0 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        public string DecalSlot1
        {
            get => _decalSlot1;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot1 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot1 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        public string DecalSlot2
        {
            get => _decalSlot2;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot2 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot2 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        public string DecalSlot3
        {
            get => _decalSlot3;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot3 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot3 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        public string DecalSlot4
        {
            get => _decalSlot4;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot4 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot4 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        public string DecalSlot5
        {
            get => _decalSlot5;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot5 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot5 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        public string DecalSlot6
        {
            get => _decalSlot6;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot6 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot6 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        public string DecalSlot7
        {
            get => _decalSlot7;
            set
            {
                if (value == BaseArguments.NULL)
                    _decalSlot7 = value;
                else if (ConvertX.ToUInt32(value) != 0)
                    _decalSlot7 = value;
                else
                    throw new Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
            }
        }

        #endregion

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public DecalArray PlainCopy()
        {
            var result = new DecalArray();
            var thisType = GetType();
            var resultType = result.GetType();
            foreach (var thisField in thisType.GetProperties())
            {
                var resultField = resultType.GetProperty(thisField.Name);
                resultField?.SetValue(result, thisField.GetValue(this));
            }

            return result;
        }

        public unsafe void Read(byte* bytePtrT)
        {
            var key = *(uint*) bytePtrT;
            _decalSlot0 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x04);
            _decalSlot1 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x08);
            _decalSlot2 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x0C);
            _decalSlot3 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x10);
            _decalSlot4 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x14);
            _decalSlot5 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x18);
            _decalSlot6 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
            key = *(uint*) (bytePtrT + 0x1C);
            _decalSlot7 = (key == 0) ? BaseArguments.NULL : $"0x{key:X8}";
        }

        public unsafe void Write(byte* bytePtrT)
        {
            *(uint*) bytePtrT = Bin.SmartHash(_decalSlot0);
            *(uint*) (bytePtrT + 0x04) = Bin.SmartHash(_decalSlot1);
            *(uint*) (bytePtrT + 0x08) = Bin.SmartHash(_decalSlot2);
            *(uint*) (bytePtrT + 0x0C) = Bin.SmartHash(_decalSlot3);
            *(uint*) (bytePtrT + 0x10) = Bin.SmartHash(_decalSlot4);
            *(uint*) (bytePtrT + 0x14) = Bin.SmartHash(_decalSlot5);
            *(uint*) (bytePtrT + 0x18) = Bin.SmartHash(_decalSlot6);
            *(uint*) (bytePtrT + 0x1C) = Bin.SmartHash(_decalSlot7);
        }
    }
}