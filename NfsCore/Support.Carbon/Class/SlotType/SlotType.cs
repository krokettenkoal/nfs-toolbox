﻿using System.Collections.Generic;
using NfsCore.Support.Carbon.Parts.CarParts;

namespace NfsCore.Support.Carbon.Class
{
    public class SlotType : Shared.Class.SlotType
    {
        public List<Part56> Part56 { get; set; }
        public Spoilers Spoilers { get; set; }
        public Dictionary<uint, Collision> Collisions { get; set; }

        public override string ToString()
        {
            return $"Part56 Count: {Part56.Count} | Collisions Count: {Collisions.Count}";
        }
    }
}