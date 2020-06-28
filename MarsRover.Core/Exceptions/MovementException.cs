using System;

namespace MarsRover.Core.Exceptions
{
    public class MovementException : Exception
    {
        public MovementException(string message) : base(message)
        { }
    }
}
