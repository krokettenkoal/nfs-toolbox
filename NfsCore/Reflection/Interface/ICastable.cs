﻿namespace NfsCore.Reflection.Interface
{
    public interface ICastable<TypeID>
    {
        unsafe TypeID MemoryCast(string CName);
    }
}