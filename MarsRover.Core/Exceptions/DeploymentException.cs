using System;

namespace MarsRover.Core.Exceptions
{
    public class RoverDeploymentException : Exception
    {
        public RoverDeploymentException(string message) : base(message)
        { }
    }
}
