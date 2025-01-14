﻿using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.Interface;

namespace NfsCore.Support.Underground2.Parts.InfoParts
{
    public class Transmission : SubPart, ICopyable<Transmission>
    {
        public float ClutchSlip { get; set; }
        public float OptimalShift { get; set; }
        public float FinalDriveRatio { get; set; }
        public float FinalDriveRatio2 { get; set; }
        public float TorqueSplit { get; set; }
        public float BurnoutStrength { get; set; }
        public int NumberOfGears { get; set; }
        public float GearEfficiency { get; set; }
        public float GearRatioR { get; set; }
        public float GearRatioN { get; set; }
        public float GearRatio1 { get; set; }
        public float GearRatio2 { get; set; }
        public float GearRatio3 { get; set; }
        public float GearRatio4 { get; set; }
        public float GearRatio5 { get; set; }
        public float GearRatio6 { get; set; }

        public Transmission()
        {
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Transmission PlainCopy()
        {
            var result = new Transmission();
            var thisType = GetType();
            var resultType = result.GetType();
            foreach (var thisProperty in thisType.GetProperties())
            {
                var resultField = resultType.GetProperty(thisProperty.Name);
                resultField?.SetValue(result, thisProperty.GetValue(this));
            }

            return result;
        }
    }
}