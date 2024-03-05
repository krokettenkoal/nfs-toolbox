using System;
using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private string _customHudStyle = BaseArguments.STOCK;
        private string _hudBackingColor = BaseArguments.WHITE;
        private string _hudNeedleColor = BaseArguments.WHITE;
        private string _hudCharacterColor = BaseArguments.WHITE;

        [AccessModifiable]
        [StaticModifiable]
        public string CustomHUDStyle
        {
            get => _customHudStyle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (!Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _customHudStyle = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public string HUDBackingColor
        {
            get => _hudBackingColor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (!Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _hudBackingColor = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public string HUDNeedleColor
        {
            get => _hudNeedleColor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (!Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _hudNeedleColor = value;
                Modified = true;
            }
        }

        [AccessModifiable]
        [StaticModifiable]
        public string HUDCharacterColor
        {
            get => _hudCharacterColor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (!Map.BinKeys.ContainsValue(value))
                    throw new MappingFailException();
                _hudCharacterColor = value;
                Modified = true;
            }
        }
    }
}