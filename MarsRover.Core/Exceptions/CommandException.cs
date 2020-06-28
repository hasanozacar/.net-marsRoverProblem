using System;

namespace MarsRover.Core.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(string message) : base(message)
        { }
    }
}
