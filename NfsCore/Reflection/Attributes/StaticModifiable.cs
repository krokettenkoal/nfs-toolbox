﻿using System;

namespace NfsCore.Reflection.Attributes
{
    /// <summary>
    /// Indicates that the field or property can be accessed and modified by user.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class StaticModifiableAttribute : Attribute
    {
    }
}