﻿namespace NfsCore.Reflection.Exception
{
    public class MappingFailException : System.Exception
    {
        public MappingFailException()
            : base("Specified argument passed could not be found in the map data.") { }

        public MappingFailException(string message)
            : base(message) { }
    }
}
