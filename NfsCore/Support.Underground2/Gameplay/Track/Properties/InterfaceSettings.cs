using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
    {
        private string _sunInfoName = BaseArguments.NULL;

        /// <summary>
        /// Represents sun type during race.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string SunInfoName
        {
            get => _sunInfoName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                _sunInfoName = value;
            }
        }
    }
}