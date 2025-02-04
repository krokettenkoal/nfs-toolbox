﻿using System;
using NfsCore.Support.Shared.Class;
using NfsCore.Utils.EA;


namespace NfsCore.Support.Shared.Parts.FNGParts
{
    public class FEngColor
    {
        public byte Red    { get; set; } = 0;
        public byte Green  { get; set; } = 0;
        public byte Blue   { get; set; } = 0;
        public byte Alpha  { get; set; } = 0;
        public uint Offset { get; set; } = 0;

        public FNGroup ThisFNGroup { get; set; }

        public FEngColor(FNGroup fng)
        {
            ThisFNGroup = fng;
        }

        public override bool Equals(object obj)
        {
            return obj is FEngColor && this == (FEngColor)obj;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Alpha, Red, Green, Blue, Offset).GetHashCode();
        }

        public static bool operator== (FEngColor c1, FEngColor c2)
        {
            if (ReferenceEquals(c1, null)) return ReferenceEquals(c2, null);
            else if (ReferenceEquals(c2, null)) return false;
            else return c1.Red == c2.Red && c1.Green == c2.Green && c1.Blue == c2.Blue;
        }

        public static bool operator!= (FEngColor c1, FEngColor c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return $"Offset: {Offset:X8} | Color: " +
                $"{SAT.ColorToHex(Alpha, Red, Green, Blue)}";
        }
    }
}
