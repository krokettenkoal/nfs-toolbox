using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private readonly byte[] _data;
        private uint _frontendHash;
        private uint _pVehicleHash;

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
        [AccessModifiable]
        public override string Frontend
        {
            get => base.Frontend;
            set => base.Frontend = value;
        }

        /// <summary>
        /// Represents pvehicle name of the preset ride.
        /// </summary>
        [AccessModifiable]
        public override string Pvehicle
        {
            get => base.Pvehicle;
            set => base.Pvehicle = value;
        }
    }
}