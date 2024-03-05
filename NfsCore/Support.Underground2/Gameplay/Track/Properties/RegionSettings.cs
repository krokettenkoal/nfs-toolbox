using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;
using NfsCore.Support.Underground2.Framework;
using NfsCore.Utils;

namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class Track
    {
        private string _raceDescription = BaseArguments.NULL;
        private string _trackDirectory;
        private string _regionName;
        private string _regionDirectory;
        private int _locationIndex;
        private string _locationDirectory;

        /// <summary>
        /// Represents debug description of the race.
        /// </summary>
        [AccessModifiable]
        public string RaceDescription
        {
            get => _raceDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value.Length > 0x1F)
                    throw new ArgumentLengthException("This value should be less than 31 characters long.");
                _raceDescription = value;
            }
        }

        /// <summary>
        /// Represents region in which the track and its values are stored.
        /// </summary>
        [AccessModifiable]
        public string RegionName
        {
            get => _regionName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
                if (value.Length > 7)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 7 characters.");
                if (!Validate.TrackRegionName(value))
                    throw new Exception("Value passed cannot be a recognizable game directory.");
                _regionName = value;
                _trackDirectory = Parse.TrackDirectory(value, CollName);
                _regionDirectory = Parse.RegionDirectory(value);
                FormatX.GetInt32(value, "L{X}R#", out _locationIndex);
                _locationDirectory = $"Location{_locationIndex.ToString()}";
            }
        }
    }
}