using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Exception;
using NfsCore.Reflection.Interface;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Parts.PresetParts
{
    public class AudioBuffers : SubPart, ICopyable<AudioBuffers>
    {
        #region Private Fields

        private string _audioComp00 = BaseArguments.NULL;
        private string _audioComp01 = BaseArguments.NULL;
        private string _audioComp02 = BaseArguments.NULL;
        private string _audioComp03 = BaseArguments.NULL;
        private string _audioComp04 = BaseArguments.NULL;
        private string _audioComp05 = BaseArguments.NULL;
        private string _audioComp06 = BaseArguments.NULL;
        private string _audioComp07 = BaseArguments.NULL;
        private string _audioComp08 = BaseArguments.NULL;
        private string _audioComp09 = BaseArguments.NULL;
        private string _audioComp10 = BaseArguments.NULL;
        private string _audioComp11 = BaseArguments.NULL;

        #endregion

        #region Public Properties

        public string AudioCompSmall00
        {
            get => _audioComp00;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp00 = value;
            }
        }

        public string AudioCompSmall01
        {
            get => _audioComp01;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp01 = value;
            }
        }

        public string AudioCompMedium02
        {
            get => _audioComp02;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp02 = value;
            }
        }

        public string AudioCompMedium03
        {
            get => _audioComp03;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp03 = value;
            }
        }

        public string AudioCompLarge04
        {
            get => _audioComp04;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp04 = value;
            }
        }

        public string AudioCompLarge05
        {
            get => _audioComp05;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp05 = value;
            }
        }

        public string AudioCompSmall06
        {
            get => _audioComp06;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp06 = value;
            }
        }

        public string AudioCompSmall07
        {
            get => _audioComp07;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp07 = value;
            }
        }

        public string AudioCompSmall08
        {
            get => _audioComp08;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp08 = value;
            }
        }

        public string AudioCompSmall09
        {
            get => _audioComp09;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp09 = value;
            }
        }

        public string AudioCompMedium10
        {
            get => _audioComp10;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp10 = value;
            }
        }

        public string AudioCompMedium11
        {
            get => _audioComp11;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
                    throw new MappingFailException();
                _audioComp11 = value;
            }
        }

        #endregion

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public AudioBuffers PlainCopy()
        {
            var result = new AudioBuffers();
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
            _audioComp00 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x04);
            _audioComp01 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x08);
            _audioComp02 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x0C);
            _audioComp03 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x10);
            _audioComp04 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x14);
            _audioComp05 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x18);
            _audioComp06 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x1C);
            _audioComp07 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x20);
            _audioComp08 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x24);
            _audioComp09 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x28);
            _audioComp10 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*) (bytePtrT + 0x2C);
            _audioComp11 = Map.Lookup(key, true) ?? BaseArguments.NULL;
        }

        public unsafe void Write(byte* bytePtrT)
        {
            *(uint*) bytePtrT = Bin.SmartHash(_audioComp00);
            *(uint*) (bytePtrT + 0x04) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x08) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x0C) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x10) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x14) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x18) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x1C) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x20) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x24) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x28) = Bin.SmartHash(_audioComp01);
            *(uint*) (bytePtrT + 0x2C) = Bin.SmartHash(_audioComp01);
        }
    }
}