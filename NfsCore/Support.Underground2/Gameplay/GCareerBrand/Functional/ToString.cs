﻿namespace NfsCore.Support.Underground2.Gameplay
{
    public partial class GCareerBrand
    {
        public override string ToString()
        {
            return $"Collection Name: {CollectionName} | " +
                   $"BinKey: {BinKey:X8} | Game: {GameSTR}";
        }
    }
}