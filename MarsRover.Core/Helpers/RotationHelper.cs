using MarsRover.Core.Models;
using System;

namespace MarsRover.Core.Helpers
{
    public static class RotationHelper
    {
        public static CompassDirection Rotate(CompassDirection compassDirection, RotationDirection rotationDirection)
        {
            return Enum.Equals(rotationDirection, RotationDirection.Clockwise)
                ? RotateClockwise(compassDirection)
                : RotateCounterClockwise(compassDirection);
        }

        static CompassDirection RotateClockwise(CompassDirection compassDirection)
        {
            return (CompassDirection)(((int)compassDirection + 3) % 4);
        }

        static CompassDirection RotateCounterClockwise(CompassDirection compassDirection)
        {
            return (CompassDirection)(((int)compassDirection + 1) % 4);
        }
    }
}
