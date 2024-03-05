using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Class
{
    public partial class PresetRide
    {
        private readonly byte[] _data;
        private uint _unknown1;
        private uint _unknown2;
        private int _performanceLevel;

        [AccessModifiable]
        [StaticModifiable]
        public int PerformanceLevel
        {
            get => _performanceLevel;
            set
            {
                if (value is > 3 or < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The value should be in range 0-3.");
                _performanceLevel = value;
            }
        }

        /// <summary>
        /// Provides info on whether this preset ride already exists in Global data.
        /// </summary>
        public bool Exists { get; }

        /// <summary>
        /// Provides info on whether this cartypeinfo was modified.
        /// </summary>
        public bool Modified { get; private set; }

        /// <summary>
        /// Represents frontend name of the preset ride.
        /// </summary>
        public override string Frontend
        {
            get => BaseArguments.NULL;
        }

        /// <summary>
        /// Represents pvehicle name of the preset ride.
        /// </summary>
        public override string Pvehicle
        {
            get => BaseArguments.NULL;
        }

        /// <summary>
        /// Vault memory hash of the frontend value.
        /// </summary>
        public override uint FrontendKey => 0;

        /// <summary>
        /// Vault memory hash of the pvehicle value.
        /// </summary>
        public override uint PvehicleKey => 0;
    }
}